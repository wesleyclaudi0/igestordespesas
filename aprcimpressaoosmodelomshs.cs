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
using GeneXus.Printer;
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
   public class aprcimpressaoosmodelomshs : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV41GestaoServicoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV105Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcimpressaoosmodelomshs( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcimpressaoosmodelomshs( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           short aP1_Tela )
      {
         this.AV41GestaoServicoId = aP0_GestaoServicoId;
         this.AV105Tela = aP1_Tela;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_Tela )
      {
         this.AV41GestaoServicoId = aP0_GestaoServicoId;
         this.AV105Tela = aP1_Tela;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("RelatorioOSMSHS.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11448, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV58SDTContexto.FromJSonString(AV79WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV78UsuarioId = AV58SDTContexto.gxTpr_Usuarioid;
            AV23EmpresaId = AV58SDTContexto.gxTpr_Empresaid;
            AV57PerfilUsuario = AV58SDTContexto.gxTpr_Usuarioperfil;
            AV16DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00C02 */
            pr_default.execute(0, new Object[] {AV41GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00C02_A36ServicoSetorId[0];
               A81GestaoServicoUsuarioId = P00C02_A81GestaoServicoUsuarioId[0];
               A38GestaoServicoId = P00C02_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00C02_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00C02_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00C02_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00C02_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00C02_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00C02_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00C02_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00C02_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00C02_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00C02_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00C02_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00C02_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00C02_n53ServicoNaturezaId[0];
               A129EnderecoId = P00C02_A129EnderecoId[0];
               n129EnderecoId = P00C02_n129EnderecoId[0];
               A34ServicoClienteId = P00C02_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00C02_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P00C02_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P00C02_n420GestaoServicoTipoHH[0];
               A82GestaoServicoUsuarioNome = P00C02_A82GestaoServicoUsuarioNome[0];
               A37ServicoSetorNome = P00C02_A37ServicoSetorNome[0];
               A82GestaoServicoUsuarioNome = P00C02_A82GestaoServicoUsuarioNome[0];
               A54ServicoNaturezaNome = P00C02_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00C02_A35ServicoClienteNome[0];
               AV61ServicoEmpresaId = A77ServicoEmpresaId;
               AV42GestaoServicoNumero = A79GestaoServicoNumero;
               AV36GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV60ServicoClienteNome = A35ServicoClienteNome;
               AV67ServicoSetorNome = A37ServicoSetorNome;
               AV65ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV13AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV14AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               AV38GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
               AV37GestaoServicoDtHora = A39GestaoServicoDtHora;
               AV44GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
               AV45GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
               AV64ServicoNaturezaId = A53ServicoNaturezaId;
               AV25EnderecoId = A129EnderecoId;
               AV59ServicoClienteId = A34ServicoClienteId;
               AV10TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               AV47GestaoServicoStatus = A42GestaoServicoStatus;
               AV100GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               AV93ResponsavelNome = A82GestaoServicoUsuarioNome;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00C03 */
            pr_default.execute(1, new Object[] {AV59ServicoClienteId, AV25EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00C03_A106ClienteEnderecoId[0];
               A17ClienteId = P00C03_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00C03_A107ClienteEnderecoLocal[0];
               AV26EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00C04 */
            pr_default.execute(2, new Object[] {AV59ServicoClienteId, AV25EnderecoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A106ClienteEnderecoId = P00C04_A106ClienteEnderecoId[0];
               A17ClienteId = P00C04_A17ClienteId[0];
               A119ClienteContatoNome = P00C04_A119ClienteContatoNome[0];
               A120ClienteContatoTelefone = P00C04_A120ClienteContatoTelefone[0];
               A121ClienteContatoEmail = P00C04_A121ClienteContatoEmail[0];
               A122ClienteContatoId = P00C04_A122ClienteContatoId[0];
               AV94ClienteContatoNome = A119ClienteContatoNome;
               AV95ClienteContatoTelefone = A120ClienteContatoTelefone;
               AV96ClienteContatoEmail = A121ClienteContatoEmail;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Using cursor P00C05 */
            pr_default.execute(3, new Object[] {AV61ServicoEmpresaId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A1EmpresaId = P00C05_A1EmpresaId[0];
               A2EmpresaNome = P00C05_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00C05_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00C05_A40000EmpresaFoto_GXI[0];
               AV17Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV24EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV18EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV22EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV75Url = StringUtil.StringReplace( AV22EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV112Empresafoto_GXI = AV75Url;
               AV21EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            HC00( false, 417) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Número da OS:", ""), 292, Gx_line+100, 407, Gx_line+118, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 410, Gx_line+100, 502, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV37GestaoServicoDtHora, "99/99/9999 99:99:99"), 317, Gx_line+167, 417, Gx_line+184, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60ServicoClienteNome, "")), 283, Gx_line+218, 541, Gx_line+233, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AuxGestaoServicoStatus, "")), 83, Gx_line+167, 225, Gx_line+182, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+400, 675, Gx_line+417, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado", ""), 283, Gx_line+400, 416, Gx_line+416, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Término Previsto", ""), 500, Gx_line+400, 633, Gx_line+416, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Serviço", ""), 67, Gx_line+400, 200, Gx_line+415, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(275, Gx_line+400, 483, Gx_line+417, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaFoto)) ? AV112Empresafoto_GXI : AV21EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 258, Gx_line+17, 483, Gx_line+84) ;
            getPrinter().GxDrawRect(58, Gx_line+133, 675, Gx_line+150, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Status da OS", ""), 333, Gx_line+133, 408, Gx_line+149, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+150, 675, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status", ""), 133, Gx_line+151, 165, Gx_line+165, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data", ""), 350, Gx_line+150, 375, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Responsável", ""), 525, Gx_line+150, 591, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+167, 675, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93ResponsavelNome, "")), 475, Gx_line+167, 642, Gx_line+182, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+200, 675, Gx_line+217, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+150, 275, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+167, 275, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(400, Gx_line+150, 467, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(400, Gx_line+167, 467, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Informações da OS", ""), 300, Gx_line+200, 444, Gx_line+216, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+233, 675, Gx_line+250, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+250, 675, Gx_line+267, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 75, Gx_line+251, 150, Gx_line+265, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data Programada:", ""), 75, Gx_line+234, 175, Gx_line+248, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 75, Gx_line+218, 112, Gx_line+232, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13AuxGestaoServicoPrioridade, "")), 283, Gx_line+251, 425, Gx_line+266, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV38GestaoServicoDtProgramada, "99/99/99"), 283, Gx_line+234, 416, Gx_line+251, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+217, 275, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+233, 275, Gx_line+250, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+250, 275, Gx_line+267, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+217, 675, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+267, 675, Gx_line+284, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Informações do Cliente", ""), 292, Gx_line+267, 436, Gx_line+283, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+283, 675, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+317, 675, Gx_line+334, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+300, 675, Gx_line+317, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email:", ""), 75, Gx_line+317, 105, Gx_line+331, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Telefone:", ""), 75, Gx_line+300, 123, Gx_line+314, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Contato:", ""), 75, Gx_line+283, 118, Gx_line+297, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+317, 275, Gx_line+334, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+300, 275, Gx_line+317, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(200, Gx_line+283, 275, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(208, Gx_line+350, 275, Gx_line+400, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoDescricao, "")), 283, Gx_line+355, 658, Gx_line+388, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 83, Gx_line+367, 166, Gx_line+381, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+350, 675, Gx_line+400, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+333, 675, Gx_line+350, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição do Serviço", ""), 283, Gx_line+333, 427, Gx_line+349, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96ClienteContatoEmail, "")), 283, Gx_line+317, 633, Gx_line+332, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95ClienteContatoTelefone, "")), 283, Gx_line+300, 541, Gx_line+315, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94ClienteContatoNome, "")), 283, Gx_line+283, 541, Gx_line+298, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+417);
            /* Using cursor P00C06 */
            pr_default.execute(4, new Object[] {AV41GestaoServicoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A38GestaoServicoId = P00C06_A38GestaoServicoId[0];
               A326TipoServicoNome = P00C06_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00C06_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00C06_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00C06_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00C06_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00C06_A329TipoServicoEstimado[0];
               AV65ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV69TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
               AV107TerminoDateTime = DateTimeUtil.ResetTime( AV38GestaoServicoDtProgramada ) ;
               AV70TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV107TerminoDateTime, 3600*(A329TipoServicoEstimado)));
               AV82ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               HC00( false, 17) ;
               getPrinter().GxDrawRect(275, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65ServicoNaturezaNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TempoEstimado, "")), 283, Gx_line+0, 441, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV70TerminoDate, "99/99/99"), 500, Gx_line+0, 633, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( AV57PerfilUsuario != 4 )
            {
               if ( AV44GestaoServicoPrecificacao == 2 )
               {
                  AV114GXV1 = 1;
                  while ( AV114GXV1 <= AV82ServicoNaturezaIdCollection.Count )
                  {
                     AV64ServicoNaturezaId = (long)(AV82ServicoNaturezaIdCollection.GetNumeric(AV114GXV1));
                     /* Using cursor P00C07 */
                     pr_default.execute(5, new Object[] {AV64ServicoNaturezaId});
                     while ( (pr_default.getStatus(5) != 101) )
                     {
                        A25NaturezaId = P00C07_A25NaturezaId[0];
                        A162NaturezaValor = P00C07_A162NaturezaValor[0];
                        A289NaturezaCusto = P00C07_A289NaturezaCusto[0];
                        AV54NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                        AV53NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                        AV72Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                        AV74TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV72Total, 18, 2));
                        HC00( false, 17) ;
                        getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(400, Gx_line+0, 525, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TotalVarChar, "")), 533, Gx_line+0, 658, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53NaturezaCustoVarChar, "")), 408, Gx_line+0, 525, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54NaturezaValorVarChar, "")), 275, Gx_line+0, 392, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TipoServicoNome, "")), 67, Gx_line+0, 225, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(5);
                     AV114GXV1 = (int)(AV114GXV1+1);
                  }
                  HC00( false, 17) ;
                  getPrinter().GxDrawRect(400, Gx_line+0, 525, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Total2VarChar, "")), 533, Gx_line+0, 658, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Total", ""), 483, Gx_line+0, 516, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
               }
               else
               {
                  if ( AV44GestaoServicoPrecificacao == 1 )
                  {
                     /* Using cursor P00C08 */
                     pr_default.execute(6, new Object[] {AV41GestaoServicoId});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A38GestaoServicoId = P00C08_A38GestaoServicoId[0];
                        A55ServicoExecutanteId = P00C08_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P00C08_n55ServicoExecutanteId[0];
                        A131GestaoServicoExecutanteId = P00C08_A131GestaoServicoExecutanteId[0];
                        AV117GXV2 = 1;
                        while ( AV117GXV2 <= AV62ServicoExecutanteIdCollection.Count )
                        {
                           AV8ServicoExecutanteId = (long)(AV62ServicoExecutanteIdCollection.GetNumeric(AV117GXV2));
                           if ( AV8ServicoExecutanteId == A55ServicoExecutanteId )
                           {
                              AV102IsExiste = true;
                           }
                           else
                           {
                              AV102IsExiste = false;
                           }
                           AV117GXV2 = (int)(AV117GXV2+1);
                        }
                        if ( ! AV102IsExiste )
                        {
                           AV62ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                        }
                        pr_default.readNext(6);
                     }
                     pr_default.close(6);
                     AV118GXV3 = 1;
                     while ( AV118GXV3 <= AV62ServicoExecutanteIdCollection.Count )
                     {
                        AV8ServicoExecutanteId = (long)(AV62ServicoExecutanteIdCollection.GetNumeric(AV118GXV3));
                        /* Using cursor P00C09 */
                        pr_default.execute(7, new Object[] {AV8ServicoExecutanteId});
                        while ( (pr_default.getStatus(7) != 101) )
                        {
                           A9UsuarioId = P00C09_A9UsuarioId[0];
                           A173UsuarioFuncaoId = P00C09_A173UsuarioFuncaoId[0];
                           n173UsuarioFuncaoId = P00C09_n173UsuarioFuncaoId[0];
                           A10UsuarioNome = P00C09_A10UsuarioNome[0];
                           AV77UsuarioFuncaoId = A173UsuarioFuncaoId;
                           AV9TecnicoNome = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(7);
                        HC00( false, 34) ;
                        getPrinter().GxDrawRect(58, Gx_line+17, 675, Gx_line+34, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9TecnicoNome, "")), 233, Gx_line+0, 500, Gx_line+15, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor por Hora", ""), 408, Gx_line+17, 508, Gx_line+33, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Qtd Horas", ""), 275, Gx_line+17, 383, Gx_line+33, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(267, Gx_line+17, 400, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo de Horas", ""), 67, Gx_line+17, 200, Gx_line+33, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+34);
                        if ( AV100GestaoServicoTipoHH == 2 )
                        {
                           /* Using cursor P00C010 */
                           pr_default.execute(8, new Object[] {AV77UsuarioFuncaoId});
                           while ( (pr_default.getStatus(8) != 101) )
                           {
                              A341FuncaoTipoHHId = P00C010_A341FuncaoTipoHHId[0];
                              A163FuncaoId = P00C010_A163FuncaoId[0];
                              A343FuncaoTipoHHDescricao = P00C010_A343FuncaoTipoHHDescricao[0];
                              A338FuncaoTipoHoraValor = P00C010_A338FuncaoTipoHoraValor[0];
                              A343FuncaoTipoHHDescricao = P00C010_A343FuncaoTipoHHDescricao[0];
                              AV97FuncaoTipoHoraDescricao = A343FuncaoTipoHHDescricao;
                              AV99FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                              HC00( false, 17) ;
                              getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97FuncaoTipoHoraDescricao, "")), 67, Gx_line+0, 225, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99FuncaoTipoHoraValorDescricao, "")), 408, Gx_line+0, 666, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV98QtdHoras), "ZZZ9")), 275, Gx_line+0, 383, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              pr_default.readNext(8);
                           }
                           pr_default.close(8);
                        }
                        else
                        {
                           /* Using cursor P00C011 */
                           pr_default.execute(9, new Object[] {AV8ServicoExecutanteId, AV41GestaoServicoId});
                           while ( (pr_default.getStatus(9) != 101) )
                           {
                              A55ServicoExecutanteId = P00C011_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P00C011_n55ServicoExecutanteId[0];
                              A38GestaoServicoId = P00C011_A38GestaoServicoId[0];
                              A423ExecutanteTipoHoraDescricao = P00C011_A423ExecutanteTipoHoraDescricao[0];
                              A424GestaoServicoExecutanteQtdHora = P00C011_A424GestaoServicoExecutanteQtdHora[0];
                              A422ExecutanteTipoHoraId = P00C011_A422ExecutanteTipoHoraId[0];
                              n422ExecutanteTipoHoraId = P00C011_n422ExecutanteTipoHoraId[0];
                              A131GestaoServicoExecutanteId = P00C011_A131GestaoServicoExecutanteId[0];
                              A423ExecutanteTipoHoraDescricao = P00C011_A423ExecutanteTipoHoraDescricao[0];
                              AV97FuncaoTipoHoraDescricao = A423ExecutanteTipoHoraDescricao;
                              AV98QtdHoras = A424GestaoServicoExecutanteQtdHora;
                              AV104ExecutanteTipoHoraId = A422ExecutanteTipoHoraId;
                              /* Using cursor P00C012 */
                              pr_default.execute(10, new Object[] {AV77UsuarioFuncaoId, AV104ExecutanteTipoHoraId});
                              while ( (pr_default.getStatus(10) != 101) )
                              {
                                 A341FuncaoTipoHHId = P00C012_A341FuncaoTipoHHId[0];
                                 A163FuncaoId = P00C012_A163FuncaoId[0];
                                 A338FuncaoTipoHoraValor = P00C012_A338FuncaoTipoHoraValor[0];
                                 AV99FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(10);
                              HC00( false, 17) ;
                              getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97FuncaoTipoHoraDescricao, "")), 67, Gx_line+0, 225, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99FuncaoTipoHoraValorDescricao, "")), 408, Gx_line+0, 666, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV98QtdHoras), "ZZZ9")), 275, Gx_line+0, 383, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              pr_default.readNext(9);
                           }
                           pr_default.close(9);
                        }
                        AV118GXV3 = (int)(AV118GXV3+1);
                     }
                  }
               }
            }
            if ( AV105Tela == 1 )
            {
               HC00( false, 18) ;
               getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 67, Gx_line+0, 150, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 375, Gx_line+0, 458, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término", ""), 275, Gx_line+0, 358, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Início", ""), 175, Gx_line+0, 258, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 600, Gx_line+0, 683, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(231, Gx_line+0, 266, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(367, Gx_line+0, 369, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(592, Gx_line+0, 594, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(142, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV123GXLvl131 = 0;
               /* Using cursor P00C013 */
               pr_default.execute(11, new Object[] {AV41GestaoServicoId});
               while ( (pr_default.getStatus(11) != 101) )
               {
                  A133OrdemExecutanteUsuarioId = P00C013_A133OrdemExecutanteUsuarioId[0];
                  A145OrdemGestaoServicoId = P00C013_A145OrdemGestaoServicoId[0];
                  A134OrdemExecutanteUsuarioNome = P00C013_A134OrdemExecutanteUsuarioNome[0];
                  A137OrdemExecutanteHrInicio = P00C013_A137OrdemExecutanteHrInicio[0];
                  A136OrdemExecutanteDtInicio = P00C013_A136OrdemExecutanteDtInicio[0];
                  A139OrdemExecutanteHrConclusao = P00C013_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P00C013_A140OrdemExecutanteComentario[0];
                  A142OrdemExecutanteValor = P00C013_A142OrdemExecutanteValor[0];
                  A135OrdemExecutanteId = P00C013_A135OrdemExecutanteId[0];
                  A134OrdemExecutanteUsuarioNome = P00C013_A134OrdemExecutanteUsuarioNome[0];
                  AV123GXLvl131 = 1;
                  AV63ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                  AV80Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                  AV81Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                  AV33GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                  if ( AV57PerfilUsuario != 4 )
                  {
                     AV48GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                  }
                  HC00( false, 17) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63ServicoExecutanteNome, "")), 67, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(542, Gx_line+0, 592, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(317, Gx_line+0, 369, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoComentario, "")), 375, Gx_line+0, 550, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48GestaoServicoValor, "")), 600, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(217, Gx_line+0, 267, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 275, Gx_line+0, 367, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  pr_default.readNext(11);
               }
               pr_default.close(11);
               if ( AV123GXLvl131 == 0 )
               {
                  /* Using cursor P00C014 */
                  pr_default.execute(12, new Object[] {AV41GestaoServicoId});
                  while ( (pr_default.getStatus(12) != 101) )
                  {
                     A55ServicoExecutanteId = P00C014_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P00C014_n55ServicoExecutanteId[0];
                     A38GestaoServicoId = P00C014_A38GestaoServicoId[0];
                     A56ServicoExecutanteNome = P00C014_A56ServicoExecutanteNome[0];
                     A131GestaoServicoExecutanteId = P00C014_A131GestaoServicoExecutanteId[0];
                     A56ServicoExecutanteNome = P00C014_A56ServicoExecutanteNome[0];
                     AV63ServicoExecutanteNome = A56ServicoExecutanteNome;
                     HC00( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63ServicoExecutanteNome, "")), 67, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(542, Gx_line+0, 592, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(317, Gx_line+0, 369, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoComentario, "")), 375, Gx_line+0, 550, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48GestaoServicoValor, "")), 600, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(217, Gx_line+0, 267, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 275, Gx_line+0, 367, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(12);
                  }
                  pr_default.close(12);
               }
            }
            if ( AV100GestaoServicoTipoHH == 2 )
            {
               AV106MsgVarChar = context.GetMessage( "OBS: A ordem de serviço está marcada como HH por DEMANDA. O orçamento completo será exibido no final da OS.", "");
            }
            HC00( false, 32) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106MsgVarChar, "")), 58, Gx_line+17, 675, Gx_line+32, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+32);
            HC00( false, 166) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 458, Gx_line+83, 593, Gx_line+97, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 142, Gx_line+83, 246, Gx_line+97, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(408, Gx_line+67, 658, Gx_line+67, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(75, Gx_line+67, 325, Gx_line+67, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+166);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC00( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void HC00( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 908, Gx_line+0, 947, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV16DateTime, "99/99/99 99:99"), 258, Gx_line+33, 441, Gx_line+48, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 633, Gx_line+33, 672, Gx_line+48, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+61);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
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
         AV58SDTContexto = new SdtSDTContexto(context);
         AV79WebSession = context.GetSession();
         AV16DateTime = (DateTime)(DateTime.MinValue);
         P00C02_A36ServicoSetorId = new long[1] ;
         P00C02_A81GestaoServicoUsuarioId = new long[1] ;
         P00C02_A38GestaoServicoId = new long[1] ;
         P00C02_A77ServicoEmpresaId = new long[1] ;
         P00C02_A79GestaoServicoNumero = new long[1] ;
         P00C02_A40GestaoServicoDescricao = new string[] {""} ;
         P00C02_A35ServicoClienteNome = new string[] {""} ;
         P00C02_A37ServicoSetorNome = new string[] {""} ;
         P00C02_A54ServicoNaturezaNome = new string[] {""} ;
         P00C02_A41GestaoServicoPrioridade = new short[1] ;
         P00C02_A42GestaoServicoStatus = new short[1] ;
         P00C02_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00C02_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00C02_A157GestaoServicoPrecificacao = new short[1] ;
         P00C02_A53ServicoNaturezaId = new long[1] ;
         P00C02_n53ServicoNaturezaId = new bool[] {false} ;
         P00C02_A129EnderecoId = new long[1] ;
         P00C02_n129EnderecoId = new bool[] {false} ;
         P00C02_A34ServicoClienteId = new long[1] ;
         P00C02_A322GestaoServicoTipoDemanda = new short[1] ;
         P00C02_A420GestaoServicoTipoHH = new short[1] ;
         P00C02_n420GestaoServicoTipoHH = new bool[] {false} ;
         P00C02_A82GestaoServicoUsuarioNome = new string[] {""} ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         A82GestaoServicoUsuarioNome = "";
         AV36GestaoServicoDescricao = "";
         AV60ServicoClienteNome = "";
         AV67ServicoSetorNome = "";
         AV65ServicoNaturezaNome = "";
         AV13AuxGestaoServicoPrioridade = "";
         AV14AuxGestaoServicoStatus = "";
         AV38GestaoServicoDtProgramada = DateTime.MinValue;
         AV37GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV45GestaoServicoPrecificacaoVarChar = "";
         AV10TipoDemandaVarChar = "";
         AV93ResponsavelNome = "";
         P00C03_A106ClienteEnderecoId = new long[1] ;
         P00C03_A17ClienteId = new long[1] ;
         P00C03_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV26EnderecoLocal = "";
         P00C04_A106ClienteEnderecoId = new long[1] ;
         P00C04_A17ClienteId = new long[1] ;
         P00C04_A119ClienteContatoNome = new string[] {""} ;
         P00C04_A120ClienteContatoTelefone = new string[] {""} ;
         P00C04_A121ClienteContatoEmail = new string[] {""} ;
         P00C04_A122ClienteContatoId = new long[1] ;
         A119ClienteContatoNome = "";
         A120ClienteContatoTelefone = "";
         A121ClienteContatoEmail = "";
         AV94ClienteContatoNome = "";
         AV95ClienteContatoTelefone = "";
         AV96ClienteContatoEmail = "";
         P00C05_A1EmpresaId = new long[1] ;
         P00C05_A2EmpresaNome = new string[] {""} ;
         P00C05_A3EmpresaCNPJ = new string[] {""} ;
         P00C05_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV17Descricao = "";
         AV24EmpresaNome = "";
         AV18EmpresaCNPJ = "";
         AV22EmpresaFotoUrl = "";
         AV75Url = "";
         AV112Empresafoto_GXI = "";
         AV21EmpresaFoto = "";
         AV21EmpresaFoto = "";
         sImgUrl = "";
         P00C06_A38GestaoServicoId = new long[1] ;
         P00C06_A326TipoServicoNome = new string[] {""} ;
         P00C06_A329TipoServicoEstimado = new short[1] ;
         P00C06_A325TipoServicoId = new long[1] ;
         P00C06_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV69TempoEstimado = "";
         AV107TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV70TerminoDate = DateTime.MinValue;
         AV82ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00C07_A25NaturezaId = new long[1] ;
         P00C07_A162NaturezaValor = new decimal[1] ;
         P00C07_A289NaturezaCusto = new decimal[1] ;
         AV54NaturezaValorVarChar = "";
         AV53NaturezaCustoVarChar = "";
         AV74TotalVarChar = "";
         AV71TipoServicoNome = "";
         AV73Total2VarChar = "";
         P00C08_A38GestaoServicoId = new long[1] ;
         P00C08_A55ServicoExecutanteId = new long[1] ;
         P00C08_n55ServicoExecutanteId = new bool[] {false} ;
         P00C08_A131GestaoServicoExecutanteId = new long[1] ;
         AV62ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P00C09_A9UsuarioId = new long[1] ;
         P00C09_A173UsuarioFuncaoId = new long[1] ;
         P00C09_n173UsuarioFuncaoId = new bool[] {false} ;
         P00C09_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV9TecnicoNome = "";
         P00C010_A341FuncaoTipoHHId = new long[1] ;
         P00C010_A163FuncaoId = new long[1] ;
         P00C010_A343FuncaoTipoHHDescricao = new string[] {""} ;
         P00C010_A338FuncaoTipoHoraValor = new decimal[1] ;
         A343FuncaoTipoHHDescricao = "";
         AV97FuncaoTipoHoraDescricao = "";
         AV99FuncaoTipoHoraValorDescricao = "";
         P00C011_A55ServicoExecutanteId = new long[1] ;
         P00C011_n55ServicoExecutanteId = new bool[] {false} ;
         P00C011_A38GestaoServicoId = new long[1] ;
         P00C011_A423ExecutanteTipoHoraDescricao = new string[] {""} ;
         P00C011_A424GestaoServicoExecutanteQtdHora = new short[1] ;
         P00C011_A422ExecutanteTipoHoraId = new long[1] ;
         P00C011_n422ExecutanteTipoHoraId = new bool[] {false} ;
         P00C011_A131GestaoServicoExecutanteId = new long[1] ;
         A423ExecutanteTipoHoraDescricao = "";
         P00C012_A341FuncaoTipoHHId = new long[1] ;
         P00C012_A163FuncaoId = new long[1] ;
         P00C012_A338FuncaoTipoHoraValor = new decimal[1] ;
         P00C013_A133OrdemExecutanteUsuarioId = new long[1] ;
         P00C013_A145OrdemGestaoServicoId = new long[1] ;
         P00C013_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P00C013_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P00C013_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P00C013_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P00C013_A140OrdemExecutanteComentario = new string[] {""} ;
         P00C013_A142OrdemExecutanteValor = new decimal[1] ;
         P00C013_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV63ServicoExecutanteNome = "";
         AV80Inicio = "";
         AV81Termino = "";
         AV33GestaoServicoComentario = "";
         AV48GestaoServicoValor = "";
         P00C014_A55ServicoExecutanteId = new long[1] ;
         P00C014_n55ServicoExecutanteId = new bool[] {false} ;
         P00C014_A38GestaoServicoId = new long[1] ;
         P00C014_A56ServicoExecutanteNome = new string[] {""} ;
         P00C014_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV106MsgVarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcimpressaoosmodelomshs__default(),
            new Object[][] {
                new Object[] {
               P00C02_A36ServicoSetorId, P00C02_A81GestaoServicoUsuarioId, P00C02_A38GestaoServicoId, P00C02_A77ServicoEmpresaId, P00C02_A79GestaoServicoNumero, P00C02_A40GestaoServicoDescricao, P00C02_A35ServicoClienteNome, P00C02_A37ServicoSetorNome, P00C02_A54ServicoNaturezaNome, P00C02_A41GestaoServicoPrioridade,
               P00C02_A42GestaoServicoStatus, P00C02_A43GestaoServicoDtProgramada, P00C02_A39GestaoServicoDtHora, P00C02_A157GestaoServicoPrecificacao, P00C02_A53ServicoNaturezaId, P00C02_n53ServicoNaturezaId, P00C02_A129EnderecoId, P00C02_n129EnderecoId, P00C02_A34ServicoClienteId, P00C02_A322GestaoServicoTipoDemanda,
               P00C02_A420GestaoServicoTipoHH, P00C02_n420GestaoServicoTipoHH, P00C02_A82GestaoServicoUsuarioNome
               }
               , new Object[] {
               P00C03_A106ClienteEnderecoId, P00C03_A17ClienteId, P00C03_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00C04_A106ClienteEnderecoId, P00C04_A17ClienteId, P00C04_A119ClienteContatoNome, P00C04_A120ClienteContatoTelefone, P00C04_A121ClienteContatoEmail, P00C04_A122ClienteContatoId
               }
               , new Object[] {
               P00C05_A1EmpresaId, P00C05_A2EmpresaNome, P00C05_A3EmpresaCNPJ, P00C05_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00C06_A38GestaoServicoId, P00C06_A326TipoServicoNome, P00C06_A329TipoServicoEstimado, P00C06_A325TipoServicoId, P00C06_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00C07_A25NaturezaId, P00C07_A162NaturezaValor, P00C07_A289NaturezaCusto
               }
               , new Object[] {
               P00C08_A38GestaoServicoId, P00C08_A55ServicoExecutanteId, P00C08_n55ServicoExecutanteId, P00C08_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00C09_A9UsuarioId, P00C09_A173UsuarioFuncaoId, P00C09_n173UsuarioFuncaoId, P00C09_A10UsuarioNome
               }
               , new Object[] {
               P00C010_A341FuncaoTipoHHId, P00C010_A163FuncaoId, P00C010_A343FuncaoTipoHHDescricao, P00C010_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P00C011_A55ServicoExecutanteId, P00C011_n55ServicoExecutanteId, P00C011_A38GestaoServicoId, P00C011_A423ExecutanteTipoHoraDescricao, P00C011_A424GestaoServicoExecutanteQtdHora, P00C011_A422ExecutanteTipoHoraId, P00C011_n422ExecutanteTipoHoraId, P00C011_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00C012_A341FuncaoTipoHHId, P00C012_A163FuncaoId, P00C012_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P00C013_A133OrdemExecutanteUsuarioId, P00C013_A145OrdemGestaoServicoId, P00C013_A134OrdemExecutanteUsuarioNome, P00C013_A137OrdemExecutanteHrInicio, P00C013_A136OrdemExecutanteDtInicio, P00C013_A139OrdemExecutanteHrConclusao, P00C013_A140OrdemExecutanteComentario, P00C013_A142OrdemExecutanteValor, P00C013_A135OrdemExecutanteId
               }
               , new Object[] {
               P00C014_A55ServicoExecutanteId, P00C014_n55ServicoExecutanteId, P00C014_A38GestaoServicoId, P00C014_A56ServicoExecutanteNome, P00C014_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV105Tela ;
      private short GxWebError ;
      private short AV57PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV44GestaoServicoPrecificacao ;
      private short AV47GestaoServicoStatus ;
      private short AV100GestaoServicoTipoHH ;
      private short A329TipoServicoEstimado ;
      private short AV98QtdHoras ;
      private short A424GestaoServicoExecutanteQtdHora ;
      private short AV123GXLvl131 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV114GXV1 ;
      private int AV117GXV2 ;
      private int AV118GXV3 ;
      private long AV41GestaoServicoId ;
      private long AV78UsuarioId ;
      private long AV23EmpresaId ;
      private long A36ServicoSetorId ;
      private long A81GestaoServicoUsuarioId ;
      private long A38GestaoServicoId ;
      private long A77ServicoEmpresaId ;
      private long A79GestaoServicoNumero ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long A34ServicoClienteId ;
      private long AV61ServicoEmpresaId ;
      private long AV42GestaoServicoNumero ;
      private long AV64ServicoNaturezaId ;
      private long AV25EnderecoId ;
      private long AV59ServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A122ClienteContatoId ;
      private long A1EmpresaId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV8ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV77UsuarioFuncaoId ;
      private long A341FuncaoTipoHHId ;
      private long A163FuncaoId ;
      private long A422ExecutanteTipoHoraId ;
      private long AV104ExecutanteTipoHoraId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV72Total ;
      private decimal A338FuncaoTipoHoraValor ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string A82GestaoServicoUsuarioNome ;
      private string AV60ServicoClienteNome ;
      private string AV67ServicoSetorNome ;
      private string AV65ServicoNaturezaNome ;
      private string AV13AuxGestaoServicoPrioridade ;
      private string AV14AuxGestaoServicoStatus ;
      private string AV93ResponsavelNome ;
      private string A107ClienteEnderecoLocal ;
      private string AV26EnderecoLocal ;
      private string A119ClienteContatoNome ;
      private string A120ClienteContatoTelefone ;
      private string AV94ClienteContatoNome ;
      private string AV95ClienteContatoTelefone ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV24EmpresaNome ;
      private string AV18EmpresaCNPJ ;
      private string sImgUrl ;
      private string A326TipoServicoNome ;
      private string AV71TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV9TecnicoNome ;
      private string A343FuncaoTipoHHDescricao ;
      private string AV97FuncaoTipoHoraDescricao ;
      private string A423ExecutanteTipoHoraDescricao ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV63ServicoExecutanteNome ;
      private string AV80Inicio ;
      private string AV81Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV16DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV37GestaoServicoDtHora ;
      private DateTime AV107TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV38GestaoServicoDtProgramada ;
      private DateTime AV70TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n420GestaoServicoTipoHH ;
      private bool n55ServicoExecutanteId ;
      private bool AV102IsExiste ;
      private bool n173UsuarioFuncaoId ;
      private bool n422ExecutanteTipoHoraId ;
      private string A40GestaoServicoDescricao ;
      private string AV36GestaoServicoDescricao ;
      private string AV45GestaoServicoPrecificacaoVarChar ;
      private string AV10TipoDemandaVarChar ;
      private string A121ClienteContatoEmail ;
      private string AV96ClienteContatoEmail ;
      private string A40000EmpresaFoto_GXI ;
      private string AV17Descricao ;
      private string AV22EmpresaFotoUrl ;
      private string AV75Url ;
      private string AV112Empresafoto_GXI ;
      private string AV69TempoEstimado ;
      private string AV54NaturezaValorVarChar ;
      private string AV53NaturezaCustoVarChar ;
      private string AV74TotalVarChar ;
      private string AV73Total2VarChar ;
      private string AV99FuncaoTipoHoraValorDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV33GestaoServicoComentario ;
      private string AV48GestaoServicoValor ;
      private string AV106MsgVarChar ;
      private string AV21EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV79WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV58SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00C02_A36ServicoSetorId ;
      private long[] P00C02_A81GestaoServicoUsuarioId ;
      private long[] P00C02_A38GestaoServicoId ;
      private long[] P00C02_A77ServicoEmpresaId ;
      private long[] P00C02_A79GestaoServicoNumero ;
      private string[] P00C02_A40GestaoServicoDescricao ;
      private string[] P00C02_A35ServicoClienteNome ;
      private string[] P00C02_A37ServicoSetorNome ;
      private string[] P00C02_A54ServicoNaturezaNome ;
      private short[] P00C02_A41GestaoServicoPrioridade ;
      private short[] P00C02_A42GestaoServicoStatus ;
      private DateTime[] P00C02_A43GestaoServicoDtProgramada ;
      private DateTime[] P00C02_A39GestaoServicoDtHora ;
      private short[] P00C02_A157GestaoServicoPrecificacao ;
      private long[] P00C02_A53ServicoNaturezaId ;
      private bool[] P00C02_n53ServicoNaturezaId ;
      private long[] P00C02_A129EnderecoId ;
      private bool[] P00C02_n129EnderecoId ;
      private long[] P00C02_A34ServicoClienteId ;
      private short[] P00C02_A322GestaoServicoTipoDemanda ;
      private short[] P00C02_A420GestaoServicoTipoHH ;
      private bool[] P00C02_n420GestaoServicoTipoHH ;
      private string[] P00C02_A82GestaoServicoUsuarioNome ;
      private long[] P00C03_A106ClienteEnderecoId ;
      private long[] P00C03_A17ClienteId ;
      private string[] P00C03_A107ClienteEnderecoLocal ;
      private long[] P00C04_A106ClienteEnderecoId ;
      private long[] P00C04_A17ClienteId ;
      private string[] P00C04_A119ClienteContatoNome ;
      private string[] P00C04_A120ClienteContatoTelefone ;
      private string[] P00C04_A121ClienteContatoEmail ;
      private long[] P00C04_A122ClienteContatoId ;
      private long[] P00C05_A1EmpresaId ;
      private string[] P00C05_A2EmpresaNome ;
      private string[] P00C05_A3EmpresaCNPJ ;
      private string[] P00C05_A40000EmpresaFoto_GXI ;
      private long[] P00C06_A38GestaoServicoId ;
      private string[] P00C06_A326TipoServicoNome ;
      private short[] P00C06_A329TipoServicoEstimado ;
      private long[] P00C06_A325TipoServicoId ;
      private long[] P00C06_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV82ServicoNaturezaIdCollection ;
      private long[] P00C07_A25NaturezaId ;
      private decimal[] P00C07_A162NaturezaValor ;
      private decimal[] P00C07_A289NaturezaCusto ;
      private long[] P00C08_A38GestaoServicoId ;
      private long[] P00C08_A55ServicoExecutanteId ;
      private bool[] P00C08_n55ServicoExecutanteId ;
      private long[] P00C08_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV62ServicoExecutanteIdCollection ;
      private long[] P00C09_A9UsuarioId ;
      private long[] P00C09_A173UsuarioFuncaoId ;
      private bool[] P00C09_n173UsuarioFuncaoId ;
      private string[] P00C09_A10UsuarioNome ;
      private long[] P00C010_A341FuncaoTipoHHId ;
      private long[] P00C010_A163FuncaoId ;
      private string[] P00C010_A343FuncaoTipoHHDescricao ;
      private decimal[] P00C010_A338FuncaoTipoHoraValor ;
      private long[] P00C011_A55ServicoExecutanteId ;
      private bool[] P00C011_n55ServicoExecutanteId ;
      private long[] P00C011_A38GestaoServicoId ;
      private string[] P00C011_A423ExecutanteTipoHoraDescricao ;
      private short[] P00C011_A424GestaoServicoExecutanteQtdHora ;
      private long[] P00C011_A422ExecutanteTipoHoraId ;
      private bool[] P00C011_n422ExecutanteTipoHoraId ;
      private long[] P00C011_A131GestaoServicoExecutanteId ;
      private long[] P00C012_A341FuncaoTipoHHId ;
      private long[] P00C012_A163FuncaoId ;
      private decimal[] P00C012_A338FuncaoTipoHoraValor ;
      private long[] P00C013_A133OrdemExecutanteUsuarioId ;
      private long[] P00C013_A145OrdemGestaoServicoId ;
      private string[] P00C013_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P00C013_A137OrdemExecutanteHrInicio ;
      private DateTime[] P00C013_A136OrdemExecutanteDtInicio ;
      private DateTime[] P00C013_A139OrdemExecutanteHrConclusao ;
      private string[] P00C013_A140OrdemExecutanteComentario ;
      private decimal[] P00C013_A142OrdemExecutanteValor ;
      private long[] P00C013_A135OrdemExecutanteId ;
      private long[] P00C014_A55ServicoExecutanteId ;
      private bool[] P00C014_n55ServicoExecutanteId ;
      private long[] P00C014_A38GestaoServicoId ;
      private string[] P00C014_A56ServicoExecutanteNome ;
      private long[] P00C014_A131GestaoServicoExecutanteId ;
   }

   public class aprcimpressaoosmodelomshs__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C02;
          prmP00C02 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C03;
          prmP00C03 = new Object[] {
          new ParDef("@AV59ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV25EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C04;
          prmP00C04 = new Object[] {
          new ParDef("@AV59ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV25EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C05;
          prmP00C05 = new Object[] {
          new ParDef("@AV61ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00C06;
          prmP00C06 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C07;
          prmP00C07 = new Object[] {
          new ParDef("@AV64ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00C08;
          prmP00C08 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C09;
          prmP00C09 = new Object[] {
          new ParDef("@AV8ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00C010;
          prmP00C010 = new Object[] {
          new ParDef("@AV77UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C011;
          prmP00C011 = new Object[] {
          new ParDef("@AV8ServicoExecutanteId",GXType.Decimal,18,0) ,
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C012;
          prmP00C012 = new Object[] {
          new ParDef("@AV77UsuarioFuncaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV104ExecutanteTipoHoraId",GXType.Decimal,18,0)
          };
          Object[] prmP00C013;
          prmP00C013 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C014;
          prmP00C014 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C02", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoUsuarioId] AS GestaoServicoUsuarioId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T5.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T4.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH], T3.[UsuarioNome] AS GestaoServicoUsuarioNome FROM (((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T1.[GestaoServicoUsuarioId]) LEFT JOIN [Natureza] T4 ON T4.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T5 ON T5.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C03", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV59ServicoClienteId and [ClienteEnderecoId] = @AV25EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C03,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C04", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteContatoNome], [ClienteContatoTelefone], [ClienteContatoEmail], [ClienteContatoId] FROM [ClienteContato] WHERE [ClienteId] = @AV59ServicoClienteId and [ClienteEnderecoId] = @AV25EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C04,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C05", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV61ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C05,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C06", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C06,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C07", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV64ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C07,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C08", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV41GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C08,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C09", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV8ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C09,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C010", "SELECT T1.[FuncaoTipoHHId] AS FuncaoTipoHHId, T1.[FuncaoId], T2.[TipoHoraDescricao] AS FuncaoTipoHHDescricao, T1.[FuncaoTipoHoraValor] FROM ([FuncaoTipoHora] T1 INNER JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[FuncaoTipoHHId]) WHERE T1.[FuncaoId] = @AV77UsuarioFuncaoId ORDER BY T1.[FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C010,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C011", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[TipoHoraDescricao] AS ExecutanteTipoHoraDescricao, T1.[GestaoServicoExecutanteQtdHora], T1.[ExecutanteTipoHoraId] AS ExecutanteTipoHoraId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[ExecutanteTipoHoraId]) WHERE (T1.[ServicoExecutanteId] = @AV8ServicoExecutanteId) AND (T1.[GestaoServicoId] = @AV41GestaoServicoId) ORDER BY T1.[ServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C011,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C012", "SELECT [FuncaoTipoHHId] AS FuncaoTipoHHId, [FuncaoId], [FuncaoTipoHoraValor] FROM [FuncaoTipoHora] WHERE [FuncaoId] = @AV77UsuarioFuncaoId and [FuncaoTipoHHId] = @AV104ExecutanteTipoHoraId ORDER BY [FuncaoId], [FuncaoTipoHHId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C012,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C013", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C013,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C014", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C014,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((string[]) buf[8])[0] = rslt.getString(9, 60);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((long[]) buf[14])[0] = rslt.getLong(15);
                ((bool[]) buf[15])[0] = rslt.wasNull(15);
                ((long[]) buf[16])[0] = rslt.getLong(16);
                ((bool[]) buf[17])[0] = rslt.wasNull(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((short[]) buf[20])[0] = rslt.getShort(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 60);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 18);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
