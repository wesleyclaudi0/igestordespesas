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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprcgamlogin : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "EventName");
            if ( ! entryPointCalled )
            {
               AV8EventName = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9jsonIn = GetPar( "jsonIn");
                  AV10jsonOut = GetPar( "jsonOut");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcgamlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcgamlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventName ,
                           string aP1_jsonIn ,
                           out string aP2_jsonOut )
      {
         this.AV8EventName = aP0_EventName;
         this.AV9jsonIn = aP1_jsonIn;
         this.AV10jsonOut = "" ;
         initialize();
         ExecutePrivate();
         aP2_jsonOut=this.AV10jsonOut;
      }

      public string executeUdp( string aP0_EventName ,
                                string aP1_jsonIn )
      {
         execute(aP0_EventName, aP1_jsonIn, out aP2_jsonOut);
         return AV10jsonOut ;
      }

      public void executeSubmit( string aP0_EventName ,
                                 string aP1_jsonIn ,
                                 out string aP2_jsonOut )
      {
         this.AV8EventName = aP0_EventName;
         this.AV9jsonIn = aP1_jsonIn;
         this.AV10jsonOut = "" ;
         SubmitImpl();
         aP2_jsonOut=this.AV10jsonOut;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GAMSession.fromjsonstring( AV9jsonIn);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GAMSession.gxTpr_User.gxTpr_Externalid))) )
         {
            AV30GXLvl5 = 0;
            /* Using cursor P00AZ2 */
            pr_default.execute(0, new Object[] {AV12GAMSession.gxTpr_User.gxTpr_Externalid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A14UsuarioAtivo = P00AZ2_A14UsuarioAtivo[0];
               A429UsuarioIsExterno = P00AZ2_A429UsuarioIsExterno[0];
               A428UsuarioGUID = P00AZ2_A428UsuarioGUID[0];
               A9UsuarioId = P00AZ2_A9UsuarioId[0];
               A10UsuarioNome = P00AZ2_A10UsuarioNome[0];
               A11UsuarioPerfil = P00AZ2_A11UsuarioPerfil[0];
               A71UsuarioAdministrador = P00AZ2_A71UsuarioAdministrador[0];
               A7UsuarioEmpresaId = P00AZ2_A7UsuarioEmpresaId[0];
               n7UsuarioEmpresaId = P00AZ2_n7UsuarioEmpresaId[0];
               A8UsuarioEmpresaNome = P00AZ2_A8UsuarioEmpresaNome[0];
               A8UsuarioEmpresaNome = P00AZ2_A8UsuarioEmpresaNome[0];
               AV30GXLvl5 = 1;
               AV11SDTContexto = new SdtSDTContexto(context);
               AV11SDTContexto.gxTpr_Usuarioid = A9UsuarioId;
               AV11SDTContexto.gxTpr_Usuarionome = A10UsuarioNome;
               AV11SDTContexto.gxTpr_Usuarioperfil = A11UsuarioPerfil;
               AV11SDTContexto.gxTpr_Usuarioadministrador = A71UsuarioAdministrador;
               AV11SDTContexto.gxTpr_Empresaid = A7UsuarioEmpresaId;
               AV11SDTContexto.gxTpr_Empresanome = A8UsuarioEmpresaNome;
               AV13WebSession.Set(context.GetMessage( "SDTContexto", ""), AV11SDTContexto.ToJSonString(false, true));
               AV13WebSession.Set(context.GetMessage( "IsLogado", ""), context.GetMessage( "True", ""));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV30GXLvl5 == 0 )
            {
               if ( GxRegex.IsMatch(AV12GAMSession.gxTpr_User.gxTpr_Login,context.GetMessage( "google", "")) )
               {
                  AV29UsuarioEmail = AV12GAMSession.gxTpr_User.gxTpr_Email;
               }
               AV15isCadastrado = false;
               /* Using cursor P00AZ3 */
               pr_default.execute(1, new Object[] {AV29UsuarioEmail});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A14UsuarioAtivo = P00AZ3_A14UsuarioAtivo[0];
                  A16UsuarioEmail = P00AZ3_A16UsuarioEmail[0];
                  A9UsuarioId = P00AZ3_A9UsuarioId[0];
                  A10UsuarioNome = P00AZ3_A10UsuarioNome[0];
                  A11UsuarioPerfil = P00AZ3_A11UsuarioPerfil[0];
                  A71UsuarioAdministrador = P00AZ3_A71UsuarioAdministrador[0];
                  A7UsuarioEmpresaId = P00AZ3_A7UsuarioEmpresaId[0];
                  n7UsuarioEmpresaId = P00AZ3_n7UsuarioEmpresaId[0];
                  A8UsuarioEmpresaNome = P00AZ3_A8UsuarioEmpresaNome[0];
                  A8UsuarioEmpresaNome = P00AZ3_A8UsuarioEmpresaNome[0];
                  AV16UsuarioId = A9UsuarioId;
                  AV15isCadastrado = true;
                  AV11SDTContexto = new SdtSDTContexto(context);
                  AV11SDTContexto.gxTpr_Usuarioid = A9UsuarioId;
                  AV11SDTContexto.gxTpr_Usuarionome = A10UsuarioNome;
                  AV11SDTContexto.gxTpr_Usuarioperfil = A11UsuarioPerfil;
                  AV11SDTContexto.gxTpr_Usuarioadministrador = A71UsuarioAdministrador;
                  AV11SDTContexto.gxTpr_Empresaid = A7UsuarioEmpresaId;
                  AV11SDTContexto.gxTpr_Empresanome = A8UsuarioEmpresaNome;
                  AV13WebSession.Set(context.GetMessage( "SDTContexto", ""), AV11SDTContexto.ToJSonString(false, true));
                  AV13WebSession.Set(context.GetMessage( "IsLogado", ""), context.GetMessage( "True", ""));
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV15isCadastrado )
               {
                  AV18Usuario.Load(AV16UsuarioId);
                  AV18Usuario.gxTpr_Usuarioisexterno = true;
                  AV18Usuario.gxTpr_Usuarioguid = AV12GAMSession.gxTpr_User.gxTpr_Externalid;
                  AV18Usuario.Save();
                  if ( AV18Usuario.Success() )
                  {
                     context.CommitDataStores("prcgamlogin",pr_default);
                  }
                  else
                  {
                     AV17Messages = AV18Usuario.GetMessages();
                     new prcinseremsg(context ).execute(  AV17Messages.ToJSonString(false)) ;
                  }
               }
               else
               {
                  AV13WebSession.Set(context.GetMessage( "ErroGAM", ""), context.GetMessage( "Usuário não cadastrado ou desativado. Faça o primeiro acesso ou fale com seu administrador.", ""));
               }
            }
         }
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
         AV10jsonOut = "";
         AV12GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         P00AZ2_A14UsuarioAtivo = new bool[] {false} ;
         P00AZ2_A429UsuarioIsExterno = new bool[] {false} ;
         P00AZ2_A428UsuarioGUID = new string[] {""} ;
         P00AZ2_A9UsuarioId = new long[1] ;
         P00AZ2_A10UsuarioNome = new string[] {""} ;
         P00AZ2_A11UsuarioPerfil = new short[1] ;
         P00AZ2_A71UsuarioAdministrador = new bool[] {false} ;
         P00AZ2_A7UsuarioEmpresaId = new long[1] ;
         P00AZ2_n7UsuarioEmpresaId = new bool[] {false} ;
         P00AZ2_A8UsuarioEmpresaNome = new string[] {""} ;
         A428UsuarioGUID = "";
         A10UsuarioNome = "";
         A8UsuarioEmpresaNome = "";
         AV11SDTContexto = new SdtSDTContexto(context);
         AV13WebSession = context.GetSession();
         AV29UsuarioEmail = "";
         P00AZ3_A14UsuarioAtivo = new bool[] {false} ;
         P00AZ3_A16UsuarioEmail = new string[] {""} ;
         P00AZ3_A9UsuarioId = new long[1] ;
         P00AZ3_A10UsuarioNome = new string[] {""} ;
         P00AZ3_A11UsuarioPerfil = new short[1] ;
         P00AZ3_A71UsuarioAdministrador = new bool[] {false} ;
         P00AZ3_A7UsuarioEmpresaId = new long[1] ;
         P00AZ3_n7UsuarioEmpresaId = new bool[] {false} ;
         P00AZ3_A8UsuarioEmpresaNome = new string[] {""} ;
         A16UsuarioEmail = "";
         AV18Usuario = new SdtUsuarioBC(context);
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprcgamlogin__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcgamlogin__default(),
            new Object[][] {
                new Object[] {
               P00AZ2_A14UsuarioAtivo, P00AZ2_A429UsuarioIsExterno, P00AZ2_A428UsuarioGUID, P00AZ2_A9UsuarioId, P00AZ2_A10UsuarioNome, P00AZ2_A11UsuarioPerfil, P00AZ2_A71UsuarioAdministrador, P00AZ2_A7UsuarioEmpresaId, P00AZ2_n7UsuarioEmpresaId, P00AZ2_A8UsuarioEmpresaNome
               }
               , new Object[] {
               P00AZ3_A14UsuarioAtivo, P00AZ3_A16UsuarioEmail, P00AZ3_A9UsuarioId, P00AZ3_A10UsuarioNome, P00AZ3_A11UsuarioPerfil, P00AZ3_A71UsuarioAdministrador, P00AZ3_A7UsuarioEmpresaId, P00AZ3_n7UsuarioEmpresaId, P00AZ3_A8UsuarioEmpresaNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV30GXLvl5 ;
      private short A11UsuarioPerfil ;
      private long A9UsuarioId ;
      private long A7UsuarioEmpresaId ;
      private long AV16UsuarioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV8EventName ;
      private string A428UsuarioGUID ;
      private string A10UsuarioNome ;
      private string A8UsuarioEmpresaNome ;
      private bool entryPointCalled ;
      private bool A14UsuarioAtivo ;
      private bool A429UsuarioIsExterno ;
      private bool A71UsuarioAdministrador ;
      private bool n7UsuarioEmpresaId ;
      private bool AV15isCadastrado ;
      private string AV9jsonIn ;
      private string AV10jsonOut ;
      private string AV29UsuarioEmail ;
      private string A16UsuarioEmail ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV12GAMSession ;
      private IDataStoreProvider pr_default ;
      private bool[] P00AZ2_A14UsuarioAtivo ;
      private bool[] P00AZ2_A429UsuarioIsExterno ;
      private string[] P00AZ2_A428UsuarioGUID ;
      private long[] P00AZ2_A9UsuarioId ;
      private string[] P00AZ2_A10UsuarioNome ;
      private short[] P00AZ2_A11UsuarioPerfil ;
      private bool[] P00AZ2_A71UsuarioAdministrador ;
      private long[] P00AZ2_A7UsuarioEmpresaId ;
      private bool[] P00AZ2_n7UsuarioEmpresaId ;
      private string[] P00AZ2_A8UsuarioEmpresaNome ;
      private SdtSDTContexto AV11SDTContexto ;
      private bool[] P00AZ3_A14UsuarioAtivo ;
      private string[] P00AZ3_A16UsuarioEmail ;
      private long[] P00AZ3_A9UsuarioId ;
      private string[] P00AZ3_A10UsuarioNome ;
      private short[] P00AZ3_A11UsuarioPerfil ;
      private bool[] P00AZ3_A71UsuarioAdministrador ;
      private long[] P00AZ3_A7UsuarioEmpresaId ;
      private bool[] P00AZ3_n7UsuarioEmpresaId ;
      private string[] P00AZ3_A8UsuarioEmpresaNome ;
      private SdtUsuarioBC AV18Usuario ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private string aP2_jsonOut ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprcgamlogin__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class aprcgamlogin__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00AZ2;
        prmP00AZ2 = new Object[] {
        new ParDef("@AV12GAMS_1User_1Externalid",GXType.VarChar,100,60)
        };
        Object[] prmP00AZ3;
        prmP00AZ3 = new Object[] {
        new ParDef("@AV29UsuarioEmail",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00AZ2", "SELECT TOP 1 T1.[UsuarioAtivo], T1.[UsuarioIsExterno], T1.[UsuarioGUID], T1.[UsuarioId], T1.[UsuarioNome], T1.[UsuarioPerfil], T1.[UsuarioAdministrador], T1.[UsuarioEmpresaId] AS UsuarioEmpresaId, T2.[EmpresaNome] AS UsuarioEmpresaNome FROM ([Usuario] T1 LEFT JOIN [Empresa] T2 ON T2.[EmpresaId] = T1.[UsuarioEmpresaId]) WHERE (RTRIM(LTRIM(T1.[UsuarioGUID])) = RTRIM(LTRIM(@AV12GAMS_1User_1Externalid))) AND (T1.[UsuarioIsExterno] = 1) AND (T1.[UsuarioAtivo] = 1) ORDER BY T1.[UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00AZ3", "SELECT T1.[UsuarioAtivo], T1.[UsuarioEmail], T1.[UsuarioId], T1.[UsuarioNome], T1.[UsuarioPerfil], T1.[UsuarioAdministrador], T1.[UsuarioEmpresaId] AS UsuarioEmpresaId, T2.[EmpresaNome] AS UsuarioEmpresaNome FROM ([Usuario] T1 LEFT JOIN [Empresa] T2 ON T2.[EmpresaId] = T1.[UsuarioEmpresaId]) WHERE (RTRIM(LTRIM(LOWER(T1.[UsuarioEmail]))) = RTRIM(LTRIM(LOWER(@AV29UsuarioEmail)))) AND (T1.[UsuarioAtivo] = 1) ORDER BY T1.[UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ3,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 40);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 60);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 60);
              return;
           case 1 :
              ((bool[]) buf[0])[0] = rslt.getBool(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 60);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 60);
              return;
     }
  }

}

}
