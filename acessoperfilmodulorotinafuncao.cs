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
   public class acessoperfilmodulorotinafuncao : GXProcedure
   {
      public acessoperfilmodulorotinafuncao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public acessoperfilmodulorotinafuncao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           string aP1_ModuloNome ,
                           string aP2_RotinaNome ,
                           out GxSimpleCollection<short> aP3_RotinaFuncaoCollection )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9ModuloNome = aP1_ModuloNome;
         this.AV13RotinaNome = aP2_RotinaNome;
         this.AV16RotinaFuncaoCollection = new GxSimpleCollection<short>() ;
         initialize();
         ExecutePrivate();
         aP3_RotinaFuncaoCollection=this.AV16RotinaFuncaoCollection;
      }

      public GxSimpleCollection<short> executeUdp( long aP0_UsuarioId ,
                                                   string aP1_ModuloNome ,
                                                   string aP2_RotinaNome )
      {
         execute(aP0_UsuarioId, aP1_ModuloNome, aP2_RotinaNome, out aP3_RotinaFuncaoCollection);
         return AV16RotinaFuncaoCollection ;
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 string aP1_ModuloNome ,
                                 string aP2_RotinaNome ,
                                 out GxSimpleCollection<short> aP3_RotinaFuncaoCollection )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV9ModuloNome = aP1_ModuloNome;
         this.AV13RotinaNome = aP2_RotinaNome;
         this.AV16RotinaFuncaoCollection = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP3_RotinaFuncaoCollection=this.AV16RotinaFuncaoCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11TemPermissao = false;
         /* Using cursor P00I52 */
         pr_default.execute(0, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9UsuarioId = P00I52_A9UsuarioId[0];
            A763UsuarioPerfilId = P00I52_A763UsuarioPerfilId[0];
            n763UsuarioPerfilId = P00I52_n763UsuarioPerfilId[0];
            AV12UsuarioPerfilId = A763UsuarioPerfilId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00I53 */
         pr_default.execute(1, new Object[] {AV9ModuloNome});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A748ModuloNome = P00I53_A748ModuloNome[0];
            A754ModuloId = P00I53_A754ModuloId[0];
            AV14ModuloId = A754ModuloId;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00I54 */
         pr_default.execute(2, new Object[] {AV9ModuloNome, AV13RotinaNome});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A754ModuloId = P00I54_A754ModuloId[0];
            A752ModuloRotinaNome = P00I54_A752ModuloRotinaNome[0];
            A748ModuloNome = P00I54_A748ModuloNome[0];
            A751ModuloRotinaId = P00I54_A751ModuloRotinaId[0];
            A748ModuloNome = P00I54_A748ModuloNome[0];
            AV15RotinaId = A751ModuloRotinaId;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00I55 */
         pr_default.execute(3, new Object[] {AV12UsuarioPerfilId, AV14ModuloId, AV15RotinaId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A767PMRRotinaId = P00I55_A767PMRRotinaId[0];
            A766PMRModuloId = P00I55_A766PMRModuloId[0];
            A765PMRPerfilId = P00I55_A765PMRPerfilId[0];
            A769PMRRotinaFuncao = P00I55_A769PMRRotinaFuncao[0];
            A768PMRFuncaoId = P00I55_A768PMRFuncaoId[0];
            AV16RotinaFuncaoCollection.Add(A769PMRRotinaFuncao, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         AV16RotinaFuncaoCollection = new GxSimpleCollection<short>();
         P00I52_A9UsuarioId = new long[1] ;
         P00I52_A763UsuarioPerfilId = new long[1] ;
         P00I52_n763UsuarioPerfilId = new bool[] {false} ;
         P00I53_A748ModuloNome = new string[] {""} ;
         P00I53_A754ModuloId = new long[1] ;
         A748ModuloNome = "";
         P00I54_A754ModuloId = new long[1] ;
         P00I54_A752ModuloRotinaNome = new string[] {""} ;
         P00I54_A748ModuloNome = new string[] {""} ;
         P00I54_A751ModuloRotinaId = new long[1] ;
         A752ModuloRotinaNome = "";
         P00I55_A767PMRRotinaId = new long[1] ;
         P00I55_A766PMRModuloId = new long[1] ;
         P00I55_A765PMRPerfilId = new long[1] ;
         P00I55_A769PMRRotinaFuncao = new short[1] ;
         P00I55_A768PMRFuncaoId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acessoperfilmodulorotinafuncao__default(),
            new Object[][] {
                new Object[] {
               P00I52_A9UsuarioId, P00I52_A763UsuarioPerfilId, P00I52_n763UsuarioPerfilId
               }
               , new Object[] {
               P00I53_A748ModuloNome, P00I53_A754ModuloId
               }
               , new Object[] {
               P00I54_A754ModuloId, P00I54_A752ModuloRotinaNome, P00I54_A748ModuloNome, P00I54_A751ModuloRotinaId
               }
               , new Object[] {
               P00I55_A767PMRRotinaId, P00I55_A766PMRModuloId, P00I55_A765PMRPerfilId, P00I55_A769PMRRotinaFuncao, P00I55_A768PMRFuncaoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A769PMRRotinaFuncao ;
      private long AV8UsuarioId ;
      private long A9UsuarioId ;
      private long A763UsuarioPerfilId ;
      private long AV12UsuarioPerfilId ;
      private long A754ModuloId ;
      private long AV14ModuloId ;
      private long A751ModuloRotinaId ;
      private long AV15RotinaId ;
      private long A767PMRRotinaId ;
      private long A766PMRModuloId ;
      private long A765PMRPerfilId ;
      private long A768PMRFuncaoId ;
      private string AV9ModuloNome ;
      private string AV13RotinaNome ;
      private string A748ModuloNome ;
      private string A752ModuloRotinaNome ;
      private bool AV11TemPermissao ;
      private bool n763UsuarioPerfilId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV16RotinaFuncaoCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00I52_A9UsuarioId ;
      private long[] P00I52_A763UsuarioPerfilId ;
      private bool[] P00I52_n763UsuarioPerfilId ;
      private string[] P00I53_A748ModuloNome ;
      private long[] P00I53_A754ModuloId ;
      private long[] P00I54_A754ModuloId ;
      private string[] P00I54_A752ModuloRotinaNome ;
      private string[] P00I54_A748ModuloNome ;
      private long[] P00I54_A751ModuloRotinaId ;
      private long[] P00I55_A767PMRRotinaId ;
      private long[] P00I55_A766PMRModuloId ;
      private long[] P00I55_A765PMRPerfilId ;
      private short[] P00I55_A769PMRRotinaFuncao ;
      private long[] P00I55_A768PMRFuncaoId ;
      private GxSimpleCollection<short> aP3_RotinaFuncaoCollection ;
   }

   public class acessoperfilmodulorotinafuncao__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00I52;
          prmP00I52 = new Object[] {
          new ParDef("@AV8UsuarioId",GXType.Decimal,18,0)
          };
          Object[] prmP00I53;
          prmP00I53 = new Object[] {
          new ParDef("@AV9ModuloNome",GXType.NChar,60,0)
          };
          Object[] prmP00I54;
          prmP00I54 = new Object[] {
          new ParDef("@AV9ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@AV13RotinaNome",GXType.NChar,60,0)
          };
          Object[] prmP00I55;
          prmP00I55 = new Object[] {
          new ParDef("@AV12UsuarioPerfilId",GXType.Decimal,18,0) ,
          new ParDef("@AV14ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@AV15RotinaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00I52", "SELECT [UsuarioId], [UsuarioPerfilId] FROM [Usuario] WHERE [UsuarioId] = @AV8UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I52,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00I53", "SELECT [ModuloNome], [ModuloId] FROM [Modulo] WHERE RTRIM(LTRIM([ModuloNome])) = RTRIM(LTRIM(@AV9ModuloNome)) ORDER BY [ModuloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I53,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00I54", "SELECT T1.[ModuloId], T1.[ModuloRotinaNome], T2.[ModuloNome], T1.[ModuloRotinaId] FROM ([ModuloRotina] T1 INNER JOIN [Modulo] T2 ON T2.[ModuloId] = T1.[ModuloId]) WHERE (RTRIM(LTRIM(T2.[ModuloNome])) = RTRIM(LTRIM(@AV9ModuloNome))) AND (RTRIM(LTRIM(T1.[ModuloRotinaNome])) = RTRIM(LTRIM(@AV13RotinaNome))) ORDER BY T1.[ModuloId], T1.[ModuloRotinaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I54,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00I55", "SELECT [PMRRotinaId], [PMRModuloId], [PMRPerfilId], [PMRRotinaFuncao], [PMRFuncaoId] FROM [PMRFuncao] WHERE ([PMRPerfilId] = @AV12UsuarioPerfilId) AND ([PMRModuloId] = @AV14ModuloId) AND ([PMRRotinaId] = @AV15RotinaId) ORDER BY [PMRFuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I55,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 60);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
