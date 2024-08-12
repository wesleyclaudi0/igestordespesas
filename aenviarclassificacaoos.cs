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
   public class aenviarclassificacaoos : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "GestaoServicoId");
            if ( ! entryPointCalled )
            {
               AV8GestaoServicoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12VarChar = GetPar( "VarChar");
                  AV9GestaoServicoQtdEstrelaCliente = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoQtdEstrelaCliente"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aenviarclassificacaoos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aenviarclassificacaoos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           string aP1_VarChar ,
                           short aP2_GestaoServicoQtdEstrelaCliente )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV12VarChar = aP1_VarChar;
         this.AV9GestaoServicoQtdEstrelaCliente = aP2_GestaoServicoQtdEstrelaCliente;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 string aP1_VarChar ,
                                 short aP2_GestaoServicoQtdEstrelaCliente )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV12VarChar = aP1_VarChar;
         this.AV9GestaoServicoQtdEstrelaCliente = aP2_GestaoServicoQtdEstrelaCliente;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P004M2 */
         pr_default.execute(0, new Object[] {AV9GestaoServicoQtdEstrelaCliente, AV8GestaoServicoId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("GestaoServico");
         /* End optimized UPDATE. */
         AV13Url = context.GetMessage( "http://iservices-app.sa-east-1.elasticbeanstalk.com/static/Resources/iservicelogologin.png", "");
         AV11AuxEmail = context.GetMessage( "<html>", "");
         AV11AuxEmail += context.GetMessage( "<body>", "");
         AV11AuxEmail += context.GetMessage( "<center><br><br>", "");
         AV11AuxEmail += context.GetMessage( "<style> ", "");
         AV11AuxEmail += context.GetMessage( "body {", "");
         AV11AuxEmail += context.GetMessage( "background-repeat: no-repeat;", "");
         AV11AuxEmail += context.GetMessage( "background-attachment: fixed;", "");
         AV11AuxEmail += context.GetMessage( "background-size: cover;", "");
         AV11AuxEmail += context.GetMessage( "background-color:#D3D3D3;", "");
         AV11AuxEmail += "}";
         AV11AuxEmail += context.GetMessage( "#top {", "");
         AV11AuxEmail += context.GetMessage( "float:center;", "");
         AV11AuxEmail += context.GetMessage( "width:180px;", "");
         AV11AuxEmail += context.GetMessage( "background-color:Transparent;", "");
         AV11AuxEmail += "}";
         AV11AuxEmail += context.GetMessage( "#tudo {", "");
         AV11AuxEmail += context.GetMessage( "border: 2px solid #DCDCDC;", "");
         AV11AuxEmail += context.GetMessage( "height:370px;", "");
         AV11AuxEmail += context.GetMessage( "width:350px;", "");
         AV11AuxEmail += context.GetMessage( "float:center;", "");
         AV11AuxEmail += context.GetMessage( "background-color:white;", "");
         AV11AuxEmail += context.GetMessage( "border-radius: 8px;", "");
         AV11AuxEmail += context.GetMessage( "box-shadow: 0px 0px 5px 5px #888888;", "");
         AV11AuxEmail += "}";
         AV11AuxEmail += context.GetMessage( "#link {", "");
         AV11AuxEmail += context.GetMessage( "float:center;", "");
         AV11AuxEmail += context.GetMessage( "width:200px;", "");
         AV11AuxEmail += context.GetMessage( "border: 1px solid #C0C0C0;", "");
         AV11AuxEmail += context.GetMessage( "border-radius: 50px;", "");
         AV11AuxEmail += context.GetMessage( "box-shadow: 0px 1px 0px 0px #C0C0C0;", "");
         AV11AuxEmail += context.GetMessage( "padding: 8px;", "");
         AV11AuxEmail += context.GetMessage( "background-color:#ffffff;", "");
         AV11AuxEmail += "}";
         AV11AuxEmail += context.GetMessage( "#baixo {", "");
         AV11AuxEmail += context.GetMessage( "float:center;", "");
         AV11AuxEmail += context.GetMessage( "width:180px;", "");
         AV11AuxEmail += context.GetMessage( "background-color:Transparent;", "");
         AV11AuxEmail += "}";
         AV11AuxEmail += context.GetMessage( "</style>", "");
         AV11AuxEmail += context.GetMessage( "<div id=\"top\">", "");
         AV11AuxEmail += context.GetMessage( "<img src=\"", "") + StringUtil.Trim( AV12VarChar) + context.GetMessage( "\"  style=\"width:180px; \"/><br>", "");
         AV11AuxEmail += context.GetMessage( "<br>", "");
         AV11AuxEmail += context.GetMessage( "</div>", "");
         AV11AuxEmail += context.GetMessage( "<div id=\"tudo\">", "");
         AV11AuxEmail += context.GetMessage( "<br>", "");
         if ( AV9GestaoServicoQtdEstrelaCliente == 1 )
         {
            AV11AuxEmail += context.GetMessage( "<img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><br><br>", "");
         }
         else
         {
            if ( AV9GestaoServicoQtdEstrelaCliente == 2 )
            {
               AV11AuxEmail += context.GetMessage( "<img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><br><br>", "");
            }
            else
            {
               if ( AV9GestaoServicoQtdEstrelaCliente == 3 )
               {
                  AV11AuxEmail += context.GetMessage( "<img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><br><br>", "");
               }
               else
               {
                  if ( AV9GestaoServicoQtdEstrelaCliente == 4 )
                  {
                     AV11AuxEmail += context.GetMessage( "<img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><br><br>", "");
                  }
                  else
                  {
                     if ( AV9GestaoServicoQtdEstrelaCliente == 5 )
                     {
                        AV11AuxEmail += context.GetMessage( "<img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><img src=\"", "") + context.convertURL( (string)(context.GetImagePath( "6f38015a-95d7-4cf4-b69e-c5b6a70688ef", "", context.GetTheme( )))) + context.GetMessage( "\" style=\"width:40px; height:40px; \"/><br><br>", "");
                     }
                  }
               }
            }
         }
         AV11AuxEmail += context.GetMessage( "<p style=\"float:center;  background-color:none\"><font face=\"Verdana\"><b>Classificação enviada com sucesso!</b></font></p><br><br>", "");
         AV11AuxEmail += context.GetMessage( "<p style=\"float:center;  background-color:none\"><font face=\"Verdana\">Você pode fechar está página.</font></p><br><br><br>", "");
         AV11AuxEmail += context.GetMessage( "<div id=\"voltar\">", "");
         AV11AuxEmail += context.GetMessage( "<div id=\"link\">", "");
         AV11AuxEmail += context.GetMessage( "<font color=\"#000000\"; font face=\"Verdana\"; font size:7px>iServices</color>", "");
         AV11AuxEmail += context.GetMessage( "</div>", "");
         AV11AuxEmail += context.GetMessage( "</div>", "");
         AV11AuxEmail += context.GetMessage( "</div>", "");
         AV11AuxEmail += context.GetMessage( "</div>", "");
         AV11AuxEmail += context.GetMessage( "<br><img src=\"", "") + StringUtil.Trim( AV13Url) + context.GetMessage( "\"  style=\"width:200px; height:60px\"/>", "");
         AV11AuxEmail += context.GetMessage( "</body>", "");
         AV11AuxEmail += context.GetMessage( "</html>", "");
         AV10HttpResponse.AddString(AV11AuxEmail);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("enviarclassificacaoos",pr_default);
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
         AV13Url = "";
         AV11AuxEmail = "";
         AV10HttpResponse = new GxHttpResponse( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aenviarclassificacaoos__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9GestaoServicoQtdEstrelaCliente ;
      private short GxWebError ;
      private short A161GestaoServicoQtdEstrelaCliente ;
      private long AV8GestaoServicoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private string AV12VarChar ;
      private string AV13Url ;
      private string AV11AuxEmail ;
      private GxHttpResponse AV10HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class aenviarclassificacaoos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          new ParDef("@GestaoServicoQtdEstrelaCliente",GXType.Int16,1,0) ,
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "UPDATE [GestaoServico] SET [GestaoServicoQtdEstrelaCliente]=@GestaoServicoQtdEstrelaCliente, [GestaoServicoClassificacaoClie]=CONVERT(BIT, 1)  WHERE [GestaoServicoId] = @AV8GestaoServicoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004M2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
