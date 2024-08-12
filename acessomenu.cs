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
   public class acessomenu : GXProcedure
   {
      public acessomenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public acessomenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           string aP1_ModuloNome ,
                           out bool aP2_TemPermissao )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9ModuloNome = aP1_ModuloNome;
         this.AV11TemPermissao = false ;
         initialize();
         ExecutePrivate();
         aP2_TemPermissao=this.AV11TemPermissao;
      }

      public bool executeUdp( long aP0_UsuarioId ,
                              string aP1_ModuloNome )
      {
         execute(aP0_UsuarioId, aP1_ModuloNome, out aP2_TemPermissao);
         return AV11TemPermissao ;
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 string aP1_ModuloNome ,
                                 out bool aP2_TemPermissao )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9ModuloNome = aP1_ModuloNome;
         this.AV11TemPermissao = false ;
         SubmitImpl();
         aP2_TemPermissao=this.AV11TemPermissao;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11TemPermissao = false;
         /* Using cursor P00I12 */
         pr_default.execute(0, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9UsuarioId = P00I12_A9UsuarioId[0];
            A763UsuarioPerfilId = P00I12_A763UsuarioPerfilId[0];
            n763UsuarioPerfilId = P00I12_n763UsuarioPerfilId[0];
            AV12UsuarioPerfilId = A763UsuarioPerfilId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00I13 */
         pr_default.execute(1, new Object[] {AV12UsuarioPerfilId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A754ModuloId = P00I13_A754ModuloId[0];
            A748ModuloNome = P00I13_A748ModuloNome[0];
            A755PerfilId = P00I13_A755PerfilId[0];
            A747PerfilModuloId = P00I13_A747PerfilModuloId[0];
            A748ModuloNome = P00I13_A748ModuloNome[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A748ModuloNome), context.GetMessage( "Gestão de Serviços", "")) == 0 )
            {
               AV11TemPermissao = true;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00I12_A9UsuarioId = new long[1] ;
         P00I12_A763UsuarioPerfilId = new long[1] ;
         P00I12_n763UsuarioPerfilId = new bool[] {false} ;
         P00I13_A754ModuloId = new long[1] ;
         P00I13_A748ModuloNome = new string[] {""} ;
         P00I13_A755PerfilId = new long[1] ;
         P00I13_A747PerfilModuloId = new long[1] ;
         A748ModuloNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acessomenu__default(),
            new Object[][] {
                new Object[] {
               P00I12_A9UsuarioId, P00I12_A763UsuarioPerfilId, P00I12_n763UsuarioPerfilId
               }
               , new Object[] {
               P00I13_A754ModuloId, P00I13_A748ModuloNome, P00I13_A755PerfilId, P00I13_A747PerfilModuloId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8UsuarioId ;
      private long A9UsuarioId ;
      private long A763UsuarioPerfilId ;
      private long AV12UsuarioPerfilId ;
      private long A754ModuloId ;
      private long A755PerfilId ;
      private long A747PerfilModuloId ;
      private string AV9ModuloNome ;
      private string A748ModuloNome ;
      private bool AV11TemPermissao ;
      private bool n763UsuarioPerfilId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00I12_A9UsuarioId ;
      private long[] P00I12_A763UsuarioPerfilId ;
      private bool[] P00I12_n763UsuarioPerfilId ;
      private long[] P00I13_A754ModuloId ;
      private string[] P00I13_A748ModuloNome ;
      private long[] P00I13_A755PerfilId ;
      private long[] P00I13_A747PerfilModuloId ;
      private bool aP2_TemPermissao ;
   }

   public class acessomenu__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00I12;
          prmP00I12 = new Object[] {
          new ParDef("@AV8UsuarioId",GXType.Decimal,18,0)
          };
          Object[] prmP00I13;
          prmP00I13 = new Object[] {
          new ParDef("@AV12UsuarioPerfilId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00I12", "SELECT [UsuarioId], [UsuarioPerfilId] FROM [Usuario] WHERE [UsuarioId] = @AV8UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00I13", "SELECT T1.[ModuloId], T2.[ModuloNome], T1.[PerfilId], T1.[PerfilModuloId] FROM ([PerfilModulo] T1 INNER JOIN [Modulo] T2 ON T2.[ModuloId] = T1.[ModuloId]) WHERE T1.[PerfilId] = @AV12UsuarioPerfilId ORDER BY T1.[PerfilId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I13,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
