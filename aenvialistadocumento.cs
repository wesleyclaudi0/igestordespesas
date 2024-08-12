using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aenvialistadocumento : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aenvialistadocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aenvialistadocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HM2 */
         pr_default.execute(0, new Object[] {Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A715DocumentoStatus = P00HM2_A715DocumentoStatus[0];
            A705DocumentoVencimento = P00HM2_A705DocumentoVencimento[0];
            A706DocumentoNotificar = P00HM2_A706DocumentoNotificar[0];
            A707DocumentoDiasNoticacao = P00HM2_A707DocumentoDiasNoticacao[0];
            A702DocumentoId = P00HM2_A702DocumentoId[0];
            AV16Dias = (short)(DateTimeUtil.DDiff(A705DocumentoVencimento,Gx_date));
            if ( AV16Dias <= A707DocumentoDiasNoticacao )
            {
               AV18VencerDocumentoIdCollection.Add(A702DocumentoId, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00HM3 */
         pr_default.execute(1, new Object[] {Gx_date});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A715DocumentoStatus = P00HM3_A715DocumentoStatus[0];
            A705DocumentoVencimento = P00HM3_A705DocumentoVencimento[0];
            A702DocumentoId = P00HM3_A702DocumentoId[0];
            AV19VencidoDocumentoIdCollection.Add(A702DocumentoId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         new prchtmldocumentolista(context ).execute(  AV18VencerDocumentoIdCollection,  AV19VencidoDocumentoIdCollection) ;
         AV22HttpResponse.AddString(context.GetMessage( "Documentos enviados com sucesso.", ""));
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         Gx_date = DateTime.MinValue;
         P00HM2_A715DocumentoStatus = new short[1] ;
         P00HM2_A705DocumentoVencimento = new DateTime[] {DateTime.MinValue} ;
         P00HM2_A706DocumentoNotificar = new bool[] {false} ;
         P00HM2_A707DocumentoDiasNoticacao = new short[1] ;
         P00HM2_A702DocumentoId = new long[1] ;
         A705DocumentoVencimento = DateTime.MinValue;
         AV18VencerDocumentoIdCollection = new GxSimpleCollection<long>();
         P00HM3_A715DocumentoStatus = new short[1] ;
         P00HM3_A705DocumentoVencimento = new DateTime[] {DateTime.MinValue} ;
         P00HM3_A702DocumentoId = new long[1] ;
         AV19VencidoDocumentoIdCollection = new GxSimpleCollection<long>();
         AV22HttpResponse = new GxHttpResponse( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aenvialistadocumento__default(),
            new Object[][] {
                new Object[] {
               P00HM2_A715DocumentoStatus, P00HM2_A705DocumentoVencimento, P00HM2_A706DocumentoNotificar, P00HM2_A707DocumentoDiasNoticacao, P00HM2_A702DocumentoId
               }
               , new Object[] {
               P00HM3_A715DocumentoStatus, P00HM3_A705DocumentoVencimento, P00HM3_A702DocumentoId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A715DocumentoStatus ;
      private short A707DocumentoDiasNoticacao ;
      private short AV16Dias ;
      private long A702DocumentoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime Gx_date ;
      private DateTime A705DocumentoVencimento ;
      private bool entryPointCalled ;
      private bool A706DocumentoNotificar ;
      private GxHttpResponse AV22HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00HM2_A715DocumentoStatus ;
      private DateTime[] P00HM2_A705DocumentoVencimento ;
      private bool[] P00HM2_A706DocumentoNotificar ;
      private short[] P00HM2_A707DocumentoDiasNoticacao ;
      private long[] P00HM2_A702DocumentoId ;
      private GxSimpleCollection<long> AV18VencerDocumentoIdCollection ;
      private short[] P00HM3_A715DocumentoStatus ;
      private DateTime[] P00HM3_A705DocumentoVencimento ;
      private long[] P00HM3_A702DocumentoId ;
      private GxSimpleCollection<long> AV19VencidoDocumentoIdCollection ;
   }

   public class aenvialistadocumento__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00HM2;
          prmP00HM2 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0)
          };
          Object[] prmP00HM3;
          prmP00HM3 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HM2", "SELECT [DocumentoStatus], [DocumentoVencimento], [DocumentoNotificar], [DocumentoDiasNoticacao], [DocumentoId] FROM [Documento] WHERE (Not ([DocumentoVencimento] = convert( DATETIME, '17530101', 112 ))) AND ([DocumentoVencimento] >= @Gx_date) AND ([DocumentoStatus] <> 0) AND ([DocumentoNotificar] = 1) ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HM2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00HM3", "SELECT [DocumentoStatus], [DocumentoVencimento], [DocumentoId] FROM [Documento] WHERE (Not ([DocumentoVencimento] = convert( DATETIME, '17530101', 112 ))) AND ([DocumentoVencimento] < @Gx_date) AND ([DocumentoStatus] <> 0) ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HM3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
