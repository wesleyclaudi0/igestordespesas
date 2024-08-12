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
   public class acargainicial : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public acargainicial( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public acargainicial( IGxContext context )
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
         /*
            INSERT RECORD ON TABLE Usuario

         */
         A10UsuarioNome = context.GetMessage( "Administrador", "");
         A16UsuarioEmail = context.GetMessage( "admin@ideiastecnologia.com.br", "");
         A12UsuarioLogin = context.GetMessage( "admin", "");
         A13UsuarioSenha = "123";
         A11UsuarioPerfil = 1;
         A71UsuarioAdministrador = true;
         A7UsuarioEmpresaId = 0;
         n7UsuarioEmpresaId = false;
         n7UsuarioEmpresaId = true;
         A173UsuarioFuncaoId = 0;
         n173UsuarioFuncaoId = false;
         n173UsuarioFuncaoId = true;
         A14UsuarioAtivo = true;
         /* Using cursor P00212 */
         pr_default.execute(0, new Object[] {A10UsuarioNome, A11UsuarioPerfil, A12UsuarioLogin, A13UsuarioSenha, n7UsuarioEmpresaId, A7UsuarioEmpresaId, A14UsuarioAtivo, A16UsuarioEmail, A71UsuarioAdministrador, n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         A9UsuarioId = P00212_A9UsuarioId[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Usuario");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Usuario

         */
         A10UsuarioNome = context.GetMessage( "Fabio", "");
         A16UsuarioEmail = context.GetMessage( "fabio@ideiastecnologia.com.br", "");
         A12UsuarioLogin = context.GetMessage( "fabio", "");
         A13UsuarioSenha = "123";
         A11UsuarioPerfil = 1;
         A71UsuarioAdministrador = false;
         A7UsuarioEmpresaId = 0;
         n7UsuarioEmpresaId = false;
         n7UsuarioEmpresaId = true;
         A173UsuarioFuncaoId = 0;
         n173UsuarioFuncaoId = false;
         n173UsuarioFuncaoId = true;
         A14UsuarioAtivo = true;
         /* Using cursor P00213 */
         pr_default.execute(1, new Object[] {A10UsuarioNome, A11UsuarioPerfil, A12UsuarioLogin, A13UsuarioSenha, n7UsuarioEmpresaId, A7UsuarioEmpresaId, A14UsuarioAtivo, A16UsuarioEmail, A71UsuarioAdministrador, n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         A9UsuarioId = P00213_A9UsuarioId[0];
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Usuario");
         if ( (pr_default.getStatus(1) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Empresa

         */
         A2EmpresaNome = context.GetMessage( "IDEIAS TECNOLOGIA", "");
         A3EmpresaCNPJ = "00000000000000";
         A4EmpresaContato = "2199999-9999";
         A5EmpresaEndereco = context.GetMessage( "Rua Beneditinos, 16 - Centro, RJ", "");
         A15EmpresaEmail = context.GetMessage( "empresa@ideiastecnologia.com.br", "");
         A6EmpresaAtivo = true;
         A321EmpresaTipoRelatorio = 3;
         A102EmpresaAdministradorId = 2;
         n102EmpresaAdministradorId = false;
         A430EmpresaDominio = context.GetMessage( "ideias-tecnologia", "");
         /* Using cursor P00214 */
         pr_default.execute(2, new Object[] {A2EmpresaNome, A3EmpresaCNPJ, A4EmpresaContato, A5EmpresaEndereco, A6EmpresaAtivo, A15EmpresaEmail, n102EmpresaAdministradorId, A102EmpresaAdministradorId, A321EmpresaTipoRelatorio, A430EmpresaDominio});
         A1EmpresaId = P00214_A1EmpresaId[0];
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Empresa");
         if ( (pr_default.getStatus(2) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Parametro

         */
         A61ParametroNome = context.GetMessage( "Logo", "");
         A62ParametroDescricao = context.GetMessage( "Logo do Login.", "");
         A63ParametroValor = "";
         /* Using cursor P00215 */
         pr_default.execute(3, new Object[] {A61ParametroNome, A62ParametroDescricao, A63ParametroValor});
         A59ParametroId = P00215_A59ParametroId[0];
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Parametro");
         if ( (pr_default.getStatus(3) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Parametro

         */
         A61ParametroNome = context.GetMessage( "LogoMenu", "");
         A62ParametroDescricao = context.GetMessage( "Imagem do menu do sistema.", "");
         A63ParametroValor = "";
         /* Using cursor P00216 */
         pr_default.execute(4, new Object[] {A61ParametroNome, A62ParametroDescricao, A63ParametroValor});
         A59ParametroId = P00216_A59ParametroId[0];
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("Parametro");
         if ( (pr_default.getStatus(4) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Parametro

         */
         A61ParametroNome = context.GetMessage( "FundoLogin", "");
         A62ParametroDescricao = context.GetMessage( "Imagem de fundo no login do sistema.", "");
         A63ParametroValor = "";
         /* Using cursor P00217 */
         pr_default.execute(5, new Object[] {A61ParametroNome, A62ParametroDescricao, A63ParametroValor});
         A59ParametroId = P00217_A59ParametroId[0];
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("Parametro");
         if ( (pr_default.getStatus(5) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         AV9HttpResponse.AddString(context.GetMessage( "Carga inicial executada com sucesso.", ""));
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("cargainicial",pr_default);
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
         A10UsuarioNome = "";
         A16UsuarioEmail = "";
         A12UsuarioLogin = "";
         A13UsuarioSenha = "";
         P00212_A9UsuarioId = new long[1] ;
         Gx_emsg = "";
         P00213_A9UsuarioId = new long[1] ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A4EmpresaContato = "";
         A5EmpresaEndereco = "";
         A15EmpresaEmail = "";
         A430EmpresaDominio = "";
         P00214_A1EmpresaId = new long[1] ;
         A61ParametroNome = "";
         A62ParametroDescricao = "";
         A63ParametroValor = "";
         P00215_A59ParametroId = new long[1] ;
         P00216_A59ParametroId = new long[1] ;
         P00217_A59ParametroId = new long[1] ;
         AV9HttpResponse = new GxHttpResponse( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acargainicial__default(),
            new Object[][] {
                new Object[] {
               P00212_A9UsuarioId
               }
               , new Object[] {
               P00213_A9UsuarioId
               }
               , new Object[] {
               P00214_A1EmpresaId
               }
               , new Object[] {
               P00215_A59ParametroId
               }
               , new Object[] {
               P00216_A59ParametroId
               }
               , new Object[] {
               P00217_A59ParametroId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A11UsuarioPerfil ;
      private short A321EmpresaTipoRelatorio ;
      private int GX_INS2 ;
      private int GX_INS1 ;
      private int GX_INS7 ;
      private long A7UsuarioEmpresaId ;
      private long A173UsuarioFuncaoId ;
      private long A9UsuarioId ;
      private long A102EmpresaAdministradorId ;
      private long A1EmpresaId ;
      private long A59ParametroId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A10UsuarioNome ;
      private string A12UsuarioLogin ;
      private string A13UsuarioSenha ;
      private string Gx_emsg ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string A4EmpresaContato ;
      private string A63ParametroValor ;
      private bool entryPointCalled ;
      private bool A71UsuarioAdministrador ;
      private bool n7UsuarioEmpresaId ;
      private bool n173UsuarioFuncaoId ;
      private bool A14UsuarioAtivo ;
      private bool A6EmpresaAtivo ;
      private bool n102EmpresaAdministradorId ;
      private string A16UsuarioEmail ;
      private string A5EmpresaEndereco ;
      private string A15EmpresaEmail ;
      private string A430EmpresaDominio ;
      private string A61ParametroNome ;
      private string A62ParametroDescricao ;
      private GxHttpResponse AV9HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00212_A9UsuarioId ;
      private long[] P00213_A9UsuarioId ;
      private long[] P00214_A1EmpresaId ;
      private long[] P00215_A59ParametroId ;
      private long[] P00216_A59ParametroId ;
      private long[] P00217_A59ParametroId ;
   }

   public class acargainicial__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00212;
          prmP00212 = new Object[] {
          new ParDef("@UsuarioNome",GXType.NChar,60,0) ,
          new ParDef("@UsuarioPerfil",GXType.Int16,4,0) ,
          new ParDef("@UsuarioLogin",GXType.NChar,100,0) ,
          new ParDef("@UsuarioSenha",GXType.NChar,20,0) ,
          new ParDef("@UsuarioEmpresaId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@UsuarioAtivo",GXType.Boolean,4,0) ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioAdministrador",GXType.Boolean,4,0) ,
          new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmP00213;
          prmP00213 = new Object[] {
          new ParDef("@UsuarioNome",GXType.NChar,60,0) ,
          new ParDef("@UsuarioPerfil",GXType.Int16,4,0) ,
          new ParDef("@UsuarioLogin",GXType.NChar,100,0) ,
          new ParDef("@UsuarioSenha",GXType.NChar,20,0) ,
          new ParDef("@UsuarioEmpresaId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@UsuarioAtivo",GXType.Boolean,4,0) ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioAdministrador",GXType.Boolean,4,0) ,
          new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmP00214;
          prmP00214 = new Object[] {
          new ParDef("@EmpresaNome",GXType.NChar,60,0) ,
          new ParDef("@EmpresaCNPJ",GXType.NChar,18,0) ,
          new ParDef("@EmpresaContato",GXType.NChar,20,0) ,
          new ParDef("@EmpresaEndereco",GXType.NVarChar,1024,0) ,
          new ParDef("@EmpresaAtivo",GXType.Boolean,4,0) ,
          new ParDef("@EmpresaEmail",GXType.NVarChar,100,0) ,
          new ParDef("@EmpresaAdministradorId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@EmpresaTipoRelatorio",GXType.Int16,4,0) ,
          new ParDef("@EmpresaDominio",GXType.NVarChar,50,0)
          };
          Object[] prmP00215;
          prmP00215 = new Object[] {
          new ParDef("@ParametroNome",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroValor",GXType.NChar,20,0)
          };
          Object[] prmP00216;
          prmP00216 = new Object[] {
          new ParDef("@ParametroNome",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroValor",GXType.NChar,20,0)
          };
          Object[] prmP00217;
          prmP00217 = new Object[] {
          new ParDef("@ParametroNome",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroValor",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00212", "INSERT INTO [Usuario]([UsuarioNome], [UsuarioPerfil], [UsuarioLogin], [UsuarioSenha], [UsuarioEmpresaId], [UsuarioAtivo], [UsuarioEmail], [UsuarioAdministrador], [UsuarioFuncaoId], [UsuarioFoto], [UsuarioFoto_GXI], [UsuarioCusto], [UsuarioQtdOSRetorno], [UsuarioGUID], [UsuarioIsExterno], [UsuarioCelular], [UsuarioPontoWpp], [UsuarioJornadaTrabalho], [UsuarioJornadaInicio], [UsuarioJornadaFim], [UsuarioCodigoPonto], [UsuarioPerfilId]) VALUES(@UsuarioNome, @UsuarioPerfil, @UsuarioLogin, @UsuarioSenha, @UsuarioEmpresaId, @UsuarioAtivo, @UsuarioEmail, @UsuarioAdministrador, @UsuarioFuncaoId, CONVERT(varbinary(1), ''), '', convert(int, 0), convert(int, 0), '', convert(bit, 0), '', convert(bit, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00213", "INSERT INTO [Usuario]([UsuarioNome], [UsuarioPerfil], [UsuarioLogin], [UsuarioSenha], [UsuarioEmpresaId], [UsuarioAtivo], [UsuarioEmail], [UsuarioAdministrador], [UsuarioFuncaoId], [UsuarioFoto], [UsuarioFoto_GXI], [UsuarioCusto], [UsuarioQtdOSRetorno], [UsuarioGUID], [UsuarioIsExterno], [UsuarioCelular], [UsuarioPontoWpp], [UsuarioJornadaTrabalho], [UsuarioJornadaInicio], [UsuarioJornadaFim], [UsuarioCodigoPonto], [UsuarioPerfilId]) VALUES(@UsuarioNome, @UsuarioPerfil, @UsuarioLogin, @UsuarioSenha, @UsuarioEmpresaId, @UsuarioAtivo, @UsuarioEmail, @UsuarioAdministrador, @UsuarioFuncaoId, CONVERT(varbinary(1), ''), '', convert(int, 0), convert(int, 0), '', convert(bit, 0), '', convert(bit, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00214", "INSERT INTO [Empresa]([EmpresaNome], [EmpresaCNPJ], [EmpresaContato], [EmpresaEndereco], [EmpresaAtivo], [EmpresaEmail], [EmpresaAdministradorId], [EmpresaTipoRelatorio], [EmpresaDominio], [EmpresaFoto], [EmpresaFoto_GXI], [EmpresaFundoLogin], [EmpresaFundoLogin_GXI]) VALUES(@EmpresaNome, @EmpresaCNPJ, @EmpresaContato, @EmpresaEndereco, @EmpresaAtivo, @EmpresaEmail, @EmpresaAdministradorId, @EmpresaTipoRelatorio, @EmpresaDominio, CONVERT(varbinary(1), ''), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00215", "INSERT INTO [Parametro]([ParametroNome], [ParametroDescricao], [ParametroValor], [ParametroImage], [ParametroImage_GXI]) VALUES(@ParametroNome, @ParametroDescricao, @ParametroValor, CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00216", "INSERT INTO [Parametro]([ParametroNome], [ParametroDescricao], [ParametroValor], [ParametroImage], [ParametroImage_GXI]) VALUES(@ParametroNome, @ParametroDescricao, @ParametroValor, CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00217", "INSERT INTO [Parametro]([ParametroNome], [ParametroDescricao], [ParametroValor], [ParametroImage], [ParametroImage_GXI]) VALUES(@ParametroNome, @ParametroDescricao, @ParametroValor, CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00217,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
