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
   public class aprcimpressaoosmodelo4 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

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
               AV29GestaoServicoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV87Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcimpressaoosmodelo4( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcimpressaoosmodelo4( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           short aP1_Tela )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
         this.AV87Tela = aP1_Tela;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_Tela )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
         this.AV87Tela = aP1_Tela;
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
         setOutputFileName("ImpressaoM4.pdf");
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
            AV71SDTContexto.FromJSonString(AV72WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV54UsuarioId = AV71SDTContexto.gxTpr_Usuarioid;
            AV73EmpresaId = AV71SDTContexto.gxTpr_Empresaid;
            AV40PerfilUsuario = AV71SDTContexto.gxTpr_Usuarioperfil;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P008A2 */
            pr_default.execute(0, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P008A2_A36ServicoSetorId[0];
               A38GestaoServicoId = P008A2_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P008A2_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P008A2_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P008A2_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P008A2_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P008A2_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P008A2_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P008A2_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P008A2_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P008A2_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P008A2_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P008A2_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P008A2_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P008A2_n53ServicoNaturezaId[0];
               A129EnderecoId = P008A2_A129EnderecoId[0];
               n129EnderecoId = P008A2_n129EnderecoId[0];
               A34ServicoClienteId = P008A2_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P008A2_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P008A2_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P008A2_n420GestaoServicoTipoHH[0];
               A37ServicoSetorNome = P008A2_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P008A2_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P008A2_A35ServicoClienteNome[0];
               AV43ServicoEmpresaId = A77ServicoEmpresaId;
               AV30GestaoServicoNumero = A79GestaoServicoNumero;
               AV24GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV42ServicoClienteNome = A35ServicoClienteNome;
               AV49ServicoSetorNome = A37ServicoSetorNome;
               AV47ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV10AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV11AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               AV26GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
               AV25GestaoServicoDtHora = A39GestaoServicoDtHora;
               AV32GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
               AV33GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
               AV46ServicoNaturezaId = A53ServicoNaturezaId;
               AV19EnderecoId = A129EnderecoId;
               AV41ServicoClienteId = A34ServicoClienteId;
               AV74TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               AV35GestaoServicoStatus = A42GestaoServicoStatus;
               AV85GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P008A3 */
            pr_default.execute(1, new Object[] {AV41ServicoClienteId, AV19EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P008A3_A106ClienteEnderecoId[0];
               A17ClienteId = P008A3_A17ClienteId[0];
               A107ClienteEnderecoLocal = P008A3_A107ClienteEnderecoLocal[0];
               AV20EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P008A4 */
            pr_default.execute(2, new Object[] {AV43ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P008A4_A1EmpresaId[0];
               A2EmpresaNome = P008A4_A2EmpresaNome[0];
               A3EmpresaCNPJ = P008A4_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P008A4_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV97Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H8A0( false, 234) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 128, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 197, Gx_line+0, 547, Gx_line+33, 1, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16EmpresaFoto)) ? AV97Empresafoto_GXI : AV16EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 133, Gx_line+35, 298, Gx_line+98) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15EmpresaCNPJ, "")), 75, Gx_line+118, 317, Gx_line+133, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpresaNome, "")), 75, Gx_line+101, 317, Gx_line+116, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "O.S Nº: ", ""), 408, Gx_line+33, 464, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 475, Gx_line+33, 567, Gx_line+50, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data:", ""), 408, Gx_line+50, 450, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25GestaoServicoDtHora, "99/99/9999 99:99:99"), 446, Gx_line+51, 546, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+33, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(358, Gx_line+33, 683, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+150, 684, Gx_line+167, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+133, 684, Gx_line+150, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+117, 684, Gx_line+134, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+100, 684, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+33, 684, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+33, 358, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76EmpresaContato, "")), 75, Gx_line+151, 450, Gx_line+166, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77EmpresaEndereco, "")), 75, Gx_line+134, 650, Gx_line+149, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(358, Gx_line+50, 683, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(358, Gx_line+67, 683, Gx_line+84, 1, 192, 192, 192, 1, 0, 128, 0, 1, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 492, Gx_line+67, 550, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ServicoClienteNome, "")), 408, Gx_line+84, 666, Gx_line+99, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EnderecoLocal, "")), 433, Gx_line+118, 683, Gx_line+133, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49ServicoSetorNome, "")), 408, Gx_line+101, 675, Gx_line+116, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(358, Gx_line+100, 683, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(358, Gx_line+117, 683, Gx_line+134, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+167, 684, Gx_line+184, 1, 192, 192, 192, 1, 0, 128, 0, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status", ""), 542, Gx_line+167, 600, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade", ""), 333, Gx_line+167, 425, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição", ""), 75, Gx_line+167, 158, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AuxGestaoServicoPrioridade, "")), 333, Gx_line+184, 475, Gx_line+199, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoStatus, "")), 542, Gx_line+184, 684, Gx_line+199, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24GestaoServicoDescricao, "")), 75, Gx_line+183, 325, Gx_line+200, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+183, 325, Gx_line+200, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+183, 533, Gx_line+200, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+183, 683, Gx_line+200, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+167, 325, Gx_line+184, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+167, 533, Gx_line+184, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nome:", ""), 367, Gx_line+83, 409, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 367, Gx_line+100, 409, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 367, Gx_line+117, 434, Gx_line+135, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+217, 684, Gx_line+234, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado", ""), 333, Gx_line+217, 466, Gx_line+233, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+200, 684, Gx_line+217, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Término Previsto", ""), 542, Gx_line+217, 675, Gx_line+233, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Serviço", ""), 75, Gx_line+217, 208, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+217, 533, Gx_line+234, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+200, 533, Gx_line+217, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+234);
            /* Using cursor P008A5 */
            pr_default.execute(3, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P008A5_A38GestaoServicoId[0];
               A326TipoServicoNome = P008A5_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P008A5_A329TipoServicoEstimado[0];
               A325TipoServicoId = P008A5_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P008A5_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P008A5_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P008A5_A329TipoServicoEstimado[0];
               AV47ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV69TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
               AV93TerminoDateTime = DateTimeUtil.ResetTime( AV26GestaoServicoDtProgramada ) ;
               AV68TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV93TerminoDateTime, 3600*(A329TipoServicoEstimado)));
               AV82ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H8A0( false, 17) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TempoEstimado, "")), 333, Gx_line+0, 491, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV68TerminoDate, "99/99/99"), 542, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV40PerfilUsuario != 4 )
            {
               if ( AV32GestaoServicoPrecificacao == 2 )
               {
                  AV99GXV1 = 1;
                  while ( AV99GXV1 <= AV82ServicoNaturezaIdCollection.Count )
                  {
                     AV46ServicoNaturezaId = (long)(AV82ServicoNaturezaIdCollection.GetNumeric(AV99GXV1));
                     /* Using cursor P008A6 */
                     pr_default.execute(4, new Object[] {AV46ServicoNaturezaId});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A25NaturezaId = P008A6_A25NaturezaId[0];
                        A162NaturezaValor = P008A6_A162NaturezaValor[0];
                        A289NaturezaCusto = P008A6_A289NaturezaCusto[0];
                        AV39NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                        AV38NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                        AV51Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                        AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
                        H8A0( false, 17) ;
                        getPrinter().GxDrawRect(275, Gx_line+0, 408, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(408, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TotalVarChar, "")), 542, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 417, Gx_line+0, 534, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 283, Gx_line+0, 400, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TipoServicoNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     AV99GXV1 = (int)(AV99GXV1+1);
                  }
                  H8A0( false, 17) ;
                  getPrinter().GxDrawRect(408, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Total2VarChar, "")), 542, Gx_line+1, 667, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+1, 525, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(275, Gx_line+0, 408, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
               }
               else
               {
                  AV89GestaoServicoIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GestaoServicoId), 18, 0));
                  if ( AV32GestaoServicoPrecificacao == 1 )
                  {
                     /* Using cursor P008A7 */
                     pr_default.execute(5, new Object[] {AV89GestaoServicoIdVarChar});
                     while ( (pr_default.getStatus(5) != 101) )
                     {
                        A38GestaoServicoId = P008A7_A38GestaoServicoId[0];
                        A55ServicoExecutanteId = P008A7_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P008A7_n55ServicoExecutanteId[0];
                        A131GestaoServicoExecutanteId = P008A7_A131GestaoServicoExecutanteId[0];
                        AV102GXV2 = 1;
                        while ( AV102GXV2 <= AV44ServicoExecutanteIdCollection.Count )
                        {
                           AV79ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV102GXV2));
                           if ( AV79ServicoExecutanteId == A55ServicoExecutanteId )
                           {
                              AV90IsExiste = true;
                           }
                           else
                           {
                              AV90IsExiste = false;
                           }
                           AV102GXV2 = (int)(AV102GXV2+1);
                        }
                        if ( ! AV90IsExiste )
                        {
                           AV44ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                        }
                        pr_default.readNext(5);
                     }
                     pr_default.close(5);
                     AV103GXV3 = 1;
                     while ( AV103GXV3 <= AV44ServicoExecutanteIdCollection.Count )
                     {
                        AV79ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV103GXV3));
                        AV91ServicoExecutanteIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV79ServicoExecutanteId), 18, 0));
                        /* Using cursor P008A8 */
                        pr_default.execute(6, new Object[] {AV79ServicoExecutanteId});
                        while ( (pr_default.getStatus(6) != 101) )
                        {
                           A9UsuarioId = P008A8_A9UsuarioId[0];
                           A173UsuarioFuncaoId = P008A8_A173UsuarioFuncaoId[0];
                           n173UsuarioFuncaoId = P008A8_n173UsuarioFuncaoId[0];
                           A10UsuarioNome = P008A8_A10UsuarioNome[0];
                           AV62UsuarioFuncaoId = A173UsuarioFuncaoId;
                           AV75TecnicoNome = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(6);
                        H8A0( false, 51) ;
                        getPrinter().GxDrawRect(67, Gx_line+33, 684, Gx_line+50, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo de Hora", ""), 75, Gx_line+33, 183, Gx_line+51, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor por Hora", ""), 392, Gx_line+33, 517, Gx_line+51, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(192, Gx_line+33, 284, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TecnicoNome, "")), 200, Gx_line+14, 514, Gx_line+29, 1+256, 0, 0, 0) ;
                        getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+33, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(383, Gx_line+33, 475, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Qtd de Horas", ""), 200, Gx_line+33, 325, Gx_line+51, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+51);
                        if ( AV85GestaoServicoTipoHH == 2 )
                        {
                           /* Using cursor P008A9 */
                           pr_default.execute(7, new Object[] {AV62UsuarioFuncaoId});
                           while ( (pr_default.getStatus(7) != 101) )
                           {
                              A341FuncaoTipoHHId = P008A9_A341FuncaoTipoHHId[0];
                              A163FuncaoId = P008A9_A163FuncaoId[0];
                              A343FuncaoTipoHHDescricao = P008A9_A343FuncaoTipoHHDescricao[0];
                              A338FuncaoTipoHoraValor = P008A9_A338FuncaoTipoHoraValor[0];
                              A343FuncaoTipoHHDescricao = P008A9_A343FuncaoTipoHHDescricao[0];
                              AV84FuncaoTipoHoraDescricao = A343FuncaoTipoHHDescricao;
                              AV83FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                              H8A0( false, 18) ;
                              getPrinter().GxDrawRect(192, Gx_line+0, 284, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83FuncaoTipoHoraValorDescricao, "")), 392, Gx_line+0, 592, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84FuncaoTipoHoraDescricao, "")), 75, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(383, Gx_line+0, 475, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV86QtdHoras), "ZZZ9")), 200, Gx_line+0, 400, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+18);
                              pr_default.readNext(7);
                           }
                           pr_default.close(7);
                        }
                        else
                        {
                           /* Using cursor P008A10 */
                           pr_default.execute(8, new Object[] {AV89GestaoServicoIdVarChar, AV91ServicoExecutanteIdVarChar});
                           while ( (pr_default.getStatus(8) != 101) )
                           {
                              A55ServicoExecutanteId = P008A10_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008A10_n55ServicoExecutanteId[0];
                              A38GestaoServicoId = P008A10_A38GestaoServicoId[0];
                              A423ExecutanteTipoHoraDescricao = P008A10_A423ExecutanteTipoHoraDescricao[0];
                              A424GestaoServicoExecutanteQtdHora = P008A10_A424GestaoServicoExecutanteQtdHora[0];
                              A422ExecutanteTipoHoraId = P008A10_A422ExecutanteTipoHoraId[0];
                              n422ExecutanteTipoHoraId = P008A10_n422ExecutanteTipoHoraId[0];
                              A131GestaoServicoExecutanteId = P008A10_A131GestaoServicoExecutanteId[0];
                              A423ExecutanteTipoHoraDescricao = P008A10_A423ExecutanteTipoHoraDescricao[0];
                              AV84FuncaoTipoHoraDescricao = A423ExecutanteTipoHoraDescricao;
                              AV86QtdHoras = A424GestaoServicoExecutanteQtdHora;
                              AV92ExecutanteTipoHoraId = A422ExecutanteTipoHoraId;
                              /* Using cursor P008A11 */
                              pr_default.execute(9, new Object[] {AV62UsuarioFuncaoId, AV92ExecutanteTipoHoraId});
                              while ( (pr_default.getStatus(9) != 101) )
                              {
                                 A341FuncaoTipoHHId = P008A11_A341FuncaoTipoHHId[0];
                                 A163FuncaoId = P008A11_A163FuncaoId[0];
                                 A338FuncaoTipoHoraValor = P008A11_A338FuncaoTipoHoraValor[0];
                                 AV83FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(9);
                              H8A0( false, 18) ;
                              getPrinter().GxDrawRect(192, Gx_line+0, 284, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83FuncaoTipoHoraValorDescricao, "")), 392, Gx_line+0, 592, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84FuncaoTipoHoraDescricao, "")), 75, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(383, Gx_line+0, 475, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV86QtdHoras), "ZZZ9")), 200, Gx_line+0, 400, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+18);
                              pr_default.readNext(8);
                           }
                           pr_default.close(8);
                        }
                        AV103GXV3 = (int)(AV103GXV3+1);
                     }
                  }
               }
            }
            if ( AV87Tela == 1 )
            {
               H8A0( false, 18) ;
               getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 75, Gx_line+0, 158, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 383, Gx_line+0, 466, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término", ""), 283, Gx_line+0, 366, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Início", ""), 183, Gx_line+0, 266, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 583, Gx_line+0, 666, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(275, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(375, Gx_line+0, 377, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(575, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(150, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV108GXLvl124 = 0;
               /* Using cursor P008A12 */
               pr_default.execute(10, new Object[] {AV29GestaoServicoId});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A133OrdemExecutanteUsuarioId = P008A12_A133OrdemExecutanteUsuarioId[0];
                  A145OrdemGestaoServicoId = P008A12_A145OrdemGestaoServicoId[0];
                  A134OrdemExecutanteUsuarioNome = P008A12_A134OrdemExecutanteUsuarioNome[0];
                  A137OrdemExecutanteHrInicio = P008A12_A137OrdemExecutanteHrInicio[0];
                  A136OrdemExecutanteDtInicio = P008A12_A136OrdemExecutanteDtInicio[0];
                  A139OrdemExecutanteHrConclusao = P008A12_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P008A12_A140OrdemExecutanteComentario[0];
                  A142OrdemExecutanteValor = P008A12_A142OrdemExecutanteValor[0];
                  A135OrdemExecutanteId = P008A12_A135OrdemExecutanteId[0];
                  A134OrdemExecutanteUsuarioNome = P008A12_A134OrdemExecutanteUsuarioNome[0];
                  AV108GXLvl124 = 1;
                  AV45ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                  AV80Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                  AV81Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                  AV21GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                  if ( AV40PerfilUsuario != 4 )
                  {
                     AV36GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                  }
                  H8A0( false, 17) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 75, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(527, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(326, Gx_line+0, 376, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 383, Gx_line+0, 558, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 583, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 183, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 283, Gx_line+0, 375, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(227, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  pr_default.readNext(10);
               }
               pr_default.close(10);
               if ( AV108GXLvl124 == 0 )
               {
                  /* Using cursor P008A13 */
                  pr_default.execute(11, new Object[] {AV89GestaoServicoIdVarChar});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A55ServicoExecutanteId = P008A13_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P008A13_n55ServicoExecutanteId[0];
                     A38GestaoServicoId = P008A13_A38GestaoServicoId[0];
                     A56ServicoExecutanteNome = P008A13_A56ServicoExecutanteNome[0];
                     A131GestaoServicoExecutanteId = P008A13_A131GestaoServicoExecutanteId[0];
                     A56ServicoExecutanteNome = P008A13_A56ServicoExecutanteNome[0];
                     AV45ServicoExecutanteNome = A56ServicoExecutanteNome;
                     H8A0( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 75, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(527, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(326, Gx_line+0, 376, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 383, Gx_line+0, 558, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 583, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 183, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 283, Gx_line+0, 375, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(227, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(11);
                  }
                  pr_default.close(11);
               }
            }
            if ( AV85GestaoServicoTipoHH == 2 )
            {
               AV88MsgVarChar = context.GetMessage( "OBS: A ordem de serviço está marcada como HH por DEMANDA. O orçamento completo será exibido no final da OS.", "");
            }
            H8A0( false, 34) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88MsgVarChar, "")), 67, Gx_line+17, 684, Gx_line+32, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+34);
            H8A0( false, 202) ;
            getPrinter().GxDrawLine(83, Gx_line+150, 333, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(417, Gx_line+150, 667, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 150, Gx_line+167, 254, Gx_line+181, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 467, Gx_line+167, 602, Gx_line+181, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(375, Gx_line+100, 400, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+202);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8A0( true, 0) ;
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

      protected void H8A0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV13DateTime, "99/99/99 99:99"), 275, Gx_line+33, 458, Gx_line+48, 1, 0, 0, 0) ;
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
         AV71SDTContexto = new SdtSDTContexto(context);
         AV72WebSession = context.GetSession();
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P008A2_A36ServicoSetorId = new long[1] ;
         P008A2_A38GestaoServicoId = new long[1] ;
         P008A2_A77ServicoEmpresaId = new long[1] ;
         P008A2_A79GestaoServicoNumero = new long[1] ;
         P008A2_A40GestaoServicoDescricao = new string[] {""} ;
         P008A2_A35ServicoClienteNome = new string[] {""} ;
         P008A2_A37ServicoSetorNome = new string[] {""} ;
         P008A2_A54ServicoNaturezaNome = new string[] {""} ;
         P008A2_A41GestaoServicoPrioridade = new short[1] ;
         P008A2_A42GestaoServicoStatus = new short[1] ;
         P008A2_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P008A2_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008A2_A157GestaoServicoPrecificacao = new short[1] ;
         P008A2_A53ServicoNaturezaId = new long[1] ;
         P008A2_n53ServicoNaturezaId = new bool[] {false} ;
         P008A2_A129EnderecoId = new long[1] ;
         P008A2_n129EnderecoId = new bool[] {false} ;
         P008A2_A34ServicoClienteId = new long[1] ;
         P008A2_A322GestaoServicoTipoDemanda = new short[1] ;
         P008A2_A420GestaoServicoTipoHH = new short[1] ;
         P008A2_n420GestaoServicoTipoHH = new bool[] {false} ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV24GestaoServicoDescricao = "";
         AV42ServicoClienteNome = "";
         AV49ServicoSetorNome = "";
         AV47ServicoNaturezaNome = "";
         AV10AuxGestaoServicoPrioridade = "";
         AV11AuxGestaoServicoStatus = "";
         AV26GestaoServicoDtProgramada = DateTime.MinValue;
         AV25GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV33GestaoServicoPrecificacaoVarChar = "";
         AV74TipoDemandaVarChar = "";
         P008A3_A106ClienteEnderecoId = new long[1] ;
         P008A3_A17ClienteId = new long[1] ;
         P008A3_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV20EnderecoLocal = "";
         P008A4_A1EmpresaId = new long[1] ;
         P008A4_A2EmpresaNome = new string[] {""} ;
         P008A4_A3EmpresaCNPJ = new string[] {""} ;
         P008A4_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV97Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         AV16EmpresaFoto = "";
         sImgUrl = "";
         AV76EmpresaContato = "";
         AV77EmpresaEndereco = "";
         P008A5_A38GestaoServicoId = new long[1] ;
         P008A5_A326TipoServicoNome = new string[] {""} ;
         P008A5_A329TipoServicoEstimado = new short[1] ;
         P008A5_A325TipoServicoId = new long[1] ;
         P008A5_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV69TempoEstimado = "";
         AV93TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV68TerminoDate = DateTime.MinValue;
         AV82ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P008A6_A25NaturezaId = new long[1] ;
         P008A6_A162NaturezaValor = new decimal[1] ;
         P008A6_A289NaturezaCusto = new decimal[1] ;
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         AV67TipoServicoNome = "";
         AV78Total2VarChar = "";
         AV89GestaoServicoIdVarChar = "";
         P008A7_A38GestaoServicoId = new long[1] ;
         P008A7_A55ServicoExecutanteId = new long[1] ;
         P008A7_n55ServicoExecutanteId = new bool[] {false} ;
         P008A7_A131GestaoServicoExecutanteId = new long[1] ;
         AV44ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         AV91ServicoExecutanteIdVarChar = "";
         P008A8_A9UsuarioId = new long[1] ;
         P008A8_A173UsuarioFuncaoId = new long[1] ;
         P008A8_n173UsuarioFuncaoId = new bool[] {false} ;
         P008A8_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV75TecnicoNome = "";
         P008A9_A341FuncaoTipoHHId = new long[1] ;
         P008A9_A163FuncaoId = new long[1] ;
         P008A9_A343FuncaoTipoHHDescricao = new string[] {""} ;
         P008A9_A338FuncaoTipoHoraValor = new decimal[1] ;
         A343FuncaoTipoHHDescricao = "";
         AV84FuncaoTipoHoraDescricao = "";
         AV83FuncaoTipoHoraValorDescricao = "";
         P008A10_A55ServicoExecutanteId = new long[1] ;
         P008A10_n55ServicoExecutanteId = new bool[] {false} ;
         P008A10_A38GestaoServicoId = new long[1] ;
         P008A10_A423ExecutanteTipoHoraDescricao = new string[] {""} ;
         P008A10_A424GestaoServicoExecutanteQtdHora = new short[1] ;
         P008A10_A422ExecutanteTipoHoraId = new long[1] ;
         P008A10_n422ExecutanteTipoHoraId = new bool[] {false} ;
         P008A10_A131GestaoServicoExecutanteId = new long[1] ;
         A423ExecutanteTipoHoraDescricao = "";
         P008A11_A341FuncaoTipoHHId = new long[1] ;
         P008A11_A163FuncaoId = new long[1] ;
         P008A11_A338FuncaoTipoHoraValor = new decimal[1] ;
         P008A12_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008A12_A145OrdemGestaoServicoId = new long[1] ;
         P008A12_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008A12_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008A12_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008A12_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008A12_A140OrdemExecutanteComentario = new string[] {""} ;
         P008A12_A142OrdemExecutanteValor = new decimal[1] ;
         P008A12_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV45ServicoExecutanteNome = "";
         AV80Inicio = "";
         AV81Termino = "";
         AV21GestaoServicoComentario = "";
         AV36GestaoServicoValor = "";
         P008A13_A55ServicoExecutanteId = new long[1] ;
         P008A13_n55ServicoExecutanteId = new bool[] {false} ;
         P008A13_A38GestaoServicoId = new long[1] ;
         P008A13_A56ServicoExecutanteNome = new string[] {""} ;
         P008A13_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV88MsgVarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcimpressaoosmodelo4__default(),
            new Object[][] {
                new Object[] {
               P008A2_A36ServicoSetorId, P008A2_A38GestaoServicoId, P008A2_A77ServicoEmpresaId, P008A2_A79GestaoServicoNumero, P008A2_A40GestaoServicoDescricao, P008A2_A35ServicoClienteNome, P008A2_A37ServicoSetorNome, P008A2_A54ServicoNaturezaNome, P008A2_A41GestaoServicoPrioridade, P008A2_A42GestaoServicoStatus,
               P008A2_A43GestaoServicoDtProgramada, P008A2_A39GestaoServicoDtHora, P008A2_A157GestaoServicoPrecificacao, P008A2_A53ServicoNaturezaId, P008A2_n53ServicoNaturezaId, P008A2_A129EnderecoId, P008A2_n129EnderecoId, P008A2_A34ServicoClienteId, P008A2_A322GestaoServicoTipoDemanda, P008A2_A420GestaoServicoTipoHH,
               P008A2_n420GestaoServicoTipoHH
               }
               , new Object[] {
               P008A3_A106ClienteEnderecoId, P008A3_A17ClienteId, P008A3_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P008A4_A1EmpresaId, P008A4_A2EmpresaNome, P008A4_A3EmpresaCNPJ, P008A4_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P008A5_A38GestaoServicoId, P008A5_A326TipoServicoNome, P008A5_A329TipoServicoEstimado, P008A5_A325TipoServicoId, P008A5_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008A6_A25NaturezaId, P008A6_A162NaturezaValor, P008A6_A289NaturezaCusto
               }
               , new Object[] {
               P008A7_A38GestaoServicoId, P008A7_A55ServicoExecutanteId, P008A7_n55ServicoExecutanteId, P008A7_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008A8_A9UsuarioId, P008A8_A173UsuarioFuncaoId, P008A8_n173UsuarioFuncaoId, P008A8_A10UsuarioNome
               }
               , new Object[] {
               P008A9_A341FuncaoTipoHHId, P008A9_A163FuncaoId, P008A9_A343FuncaoTipoHHDescricao, P008A9_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008A10_A55ServicoExecutanteId, P008A10_n55ServicoExecutanteId, P008A10_A38GestaoServicoId, P008A10_A423ExecutanteTipoHoraDescricao, P008A10_A424GestaoServicoExecutanteQtdHora, P008A10_A422ExecutanteTipoHoraId, P008A10_n422ExecutanteTipoHoraId, P008A10_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008A11_A341FuncaoTipoHHId, P008A11_A163FuncaoId, P008A11_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008A12_A133OrdemExecutanteUsuarioId, P008A12_A145OrdemGestaoServicoId, P008A12_A134OrdemExecutanteUsuarioNome, P008A12_A137OrdemExecutanteHrInicio, P008A12_A136OrdemExecutanteDtInicio, P008A12_A139OrdemExecutanteHrConclusao, P008A12_A140OrdemExecutanteComentario, P008A12_A142OrdemExecutanteValor, P008A12_A135OrdemExecutanteId
               }
               , new Object[] {
               P008A13_A55ServicoExecutanteId, P008A13_n55ServicoExecutanteId, P008A13_A38GestaoServicoId, P008A13_A56ServicoExecutanteNome, P008A13_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV87Tela ;
      private short GxWebError ;
      private short AV40PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV32GestaoServicoPrecificacao ;
      private short AV35GestaoServicoStatus ;
      private short AV85GestaoServicoTipoHH ;
      private short A329TipoServicoEstimado ;
      private short AV86QtdHoras ;
      private short A424GestaoServicoExecutanteQtdHora ;
      private short AV108GXLvl124 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV99GXV1 ;
      private int AV102GXV2 ;
      private int AV103GXV3 ;
      private long AV29GestaoServicoId ;
      private long AV54UsuarioId ;
      private long AV73EmpresaId ;
      private long A36ServicoSetorId ;
      private long A38GestaoServicoId ;
      private long A77ServicoEmpresaId ;
      private long A79GestaoServicoNumero ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long A34ServicoClienteId ;
      private long AV43ServicoEmpresaId ;
      private long AV30GestaoServicoNumero ;
      private long AV46ServicoNaturezaId ;
      private long AV19EnderecoId ;
      private long AV41ServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A1EmpresaId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV79ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV62UsuarioFuncaoId ;
      private long A341FuncaoTipoHHId ;
      private long A163FuncaoId ;
      private long A422ExecutanteTipoHoraId ;
      private long AV92ExecutanteTipoHoraId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV51Total ;
      private decimal A338FuncaoTipoHoraValor ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV42ServicoClienteNome ;
      private string AV49ServicoSetorNome ;
      private string AV47ServicoNaturezaNome ;
      private string AV10AuxGestaoServicoPrioridade ;
      private string AV11AuxGestaoServicoStatus ;
      private string A107ClienteEnderecoLocal ;
      private string AV20EnderecoLocal ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV18EmpresaNome ;
      private string AV15EmpresaCNPJ ;
      private string sImgUrl ;
      private string AV76EmpresaContato ;
      private string A326TipoServicoNome ;
      private string AV67TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV75TecnicoNome ;
      private string A343FuncaoTipoHHDescricao ;
      private string AV84FuncaoTipoHoraDescricao ;
      private string A423ExecutanteTipoHoraDescricao ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV45ServicoExecutanteNome ;
      private string AV80Inicio ;
      private string AV81Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV13DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV93TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime AV68TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n420GestaoServicoTipoHH ;
      private bool n55ServicoExecutanteId ;
      private bool AV90IsExiste ;
      private bool n173UsuarioFuncaoId ;
      private bool n422ExecutanteTipoHoraId ;
      private string A40GestaoServicoDescricao ;
      private string AV24GestaoServicoDescricao ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV74TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV97Empresafoto_GXI ;
      private string AV77EmpresaEndereco ;
      private string AV69TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV78Total2VarChar ;
      private string AV89GestaoServicoIdVarChar ;
      private string AV91ServicoExecutanteIdVarChar ;
      private string AV83FuncaoTipoHoraValorDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV21GestaoServicoComentario ;
      private string AV36GestaoServicoValor ;
      private string AV88MsgVarChar ;
      private string AV16EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV72WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV71SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P008A2_A36ServicoSetorId ;
      private long[] P008A2_A38GestaoServicoId ;
      private long[] P008A2_A77ServicoEmpresaId ;
      private long[] P008A2_A79GestaoServicoNumero ;
      private string[] P008A2_A40GestaoServicoDescricao ;
      private string[] P008A2_A35ServicoClienteNome ;
      private string[] P008A2_A37ServicoSetorNome ;
      private string[] P008A2_A54ServicoNaturezaNome ;
      private short[] P008A2_A41GestaoServicoPrioridade ;
      private short[] P008A2_A42GestaoServicoStatus ;
      private DateTime[] P008A2_A43GestaoServicoDtProgramada ;
      private DateTime[] P008A2_A39GestaoServicoDtHora ;
      private short[] P008A2_A157GestaoServicoPrecificacao ;
      private long[] P008A2_A53ServicoNaturezaId ;
      private bool[] P008A2_n53ServicoNaturezaId ;
      private long[] P008A2_A129EnderecoId ;
      private bool[] P008A2_n129EnderecoId ;
      private long[] P008A2_A34ServicoClienteId ;
      private short[] P008A2_A322GestaoServicoTipoDemanda ;
      private short[] P008A2_A420GestaoServicoTipoHH ;
      private bool[] P008A2_n420GestaoServicoTipoHH ;
      private long[] P008A3_A106ClienteEnderecoId ;
      private long[] P008A3_A17ClienteId ;
      private string[] P008A3_A107ClienteEnderecoLocal ;
      private long[] P008A4_A1EmpresaId ;
      private string[] P008A4_A2EmpresaNome ;
      private string[] P008A4_A3EmpresaCNPJ ;
      private string[] P008A4_A40000EmpresaFoto_GXI ;
      private long[] P008A5_A38GestaoServicoId ;
      private string[] P008A5_A326TipoServicoNome ;
      private short[] P008A5_A329TipoServicoEstimado ;
      private long[] P008A5_A325TipoServicoId ;
      private long[] P008A5_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV82ServicoNaturezaIdCollection ;
      private long[] P008A6_A25NaturezaId ;
      private decimal[] P008A6_A162NaturezaValor ;
      private decimal[] P008A6_A289NaturezaCusto ;
      private long[] P008A7_A38GestaoServicoId ;
      private long[] P008A7_A55ServicoExecutanteId ;
      private bool[] P008A7_n55ServicoExecutanteId ;
      private long[] P008A7_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV44ServicoExecutanteIdCollection ;
      private long[] P008A8_A9UsuarioId ;
      private long[] P008A8_A173UsuarioFuncaoId ;
      private bool[] P008A8_n173UsuarioFuncaoId ;
      private string[] P008A8_A10UsuarioNome ;
      private long[] P008A9_A341FuncaoTipoHHId ;
      private long[] P008A9_A163FuncaoId ;
      private string[] P008A9_A343FuncaoTipoHHDescricao ;
      private decimal[] P008A9_A338FuncaoTipoHoraValor ;
      private long[] P008A10_A55ServicoExecutanteId ;
      private bool[] P008A10_n55ServicoExecutanteId ;
      private long[] P008A10_A38GestaoServicoId ;
      private string[] P008A10_A423ExecutanteTipoHoraDescricao ;
      private short[] P008A10_A424GestaoServicoExecutanteQtdHora ;
      private long[] P008A10_A422ExecutanteTipoHoraId ;
      private bool[] P008A10_n422ExecutanteTipoHoraId ;
      private long[] P008A10_A131GestaoServicoExecutanteId ;
      private long[] P008A11_A341FuncaoTipoHHId ;
      private long[] P008A11_A163FuncaoId ;
      private decimal[] P008A11_A338FuncaoTipoHoraValor ;
      private long[] P008A12_A133OrdemExecutanteUsuarioId ;
      private long[] P008A12_A145OrdemGestaoServicoId ;
      private string[] P008A12_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008A12_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008A12_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008A12_A139OrdemExecutanteHrConclusao ;
      private string[] P008A12_A140OrdemExecutanteComentario ;
      private decimal[] P008A12_A142OrdemExecutanteValor ;
      private long[] P008A12_A135OrdemExecutanteId ;
      private long[] P008A13_A55ServicoExecutanteId ;
      private bool[] P008A13_n55ServicoExecutanteId ;
      private long[] P008A13_A38GestaoServicoId ;
      private string[] P008A13_A56ServicoExecutanteNome ;
      private long[] P008A13_A131GestaoServicoExecutanteId ;
   }

   public class aprcimpressaoosmodelo4__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008A2;
          prmP008A2 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008A3;
          prmP008A3 = new Object[] {
          new ParDef("@AV41ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP008A4;
          prmP008A4 = new Object[] {
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP008A5;
          prmP008A5 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008A6;
          prmP008A6 = new Object[] {
          new ParDef("@AV46ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP008A7;
          prmP008A7 = new Object[] {
          new ParDef("@AV89GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP008A8;
          prmP008A8 = new Object[] {
          new ParDef("@AV79ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP008A9;
          prmP008A9 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008A10;
          prmP008A10 = new Object[] {
          new ParDef("@AV89GestaoServicoIdVarChar",GXType.VarChar,40,0) ,
          new ParDef("@AV91ServicoExecutanteIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP008A11;
          prmP008A11 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV92ExecutanteTipoHoraId",GXType.Decimal,18,0)
          };
          Object[] prmP008A12;
          prmP008A12 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008A13;
          prmP008A13 = new Object[] {
          new ParDef("@AV89GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008A2", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A3", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV41ServicoClienteId and [ClienteEnderecoId] = @AV19EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A4", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV43ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A5", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008A6", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV46ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A7", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV89GestaoServicoIdVarChar) ORDER BY [GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008A8", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV79ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A9", "SELECT T1.[FuncaoTipoHHId] AS FuncaoTipoHHId, T1.[FuncaoId], T2.[TipoHoraDescricao] AS FuncaoTipoHHDescricao, T1.[FuncaoTipoHoraValor] FROM ([FuncaoTipoHora] T1 INNER JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[FuncaoTipoHHId]) WHERE T1.[FuncaoId] = @AV62UsuarioFuncaoId ORDER BY T1.[FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008A10", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[TipoHoraDescricao] AS ExecutanteTipoHoraDescricao, T1.[GestaoServicoExecutanteQtdHora], T1.[ExecutanteTipoHoraId] AS ExecutanteTipoHoraId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[ExecutanteTipoHoraId]) WHERE (T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV89GestaoServicoIdVarChar)) AND (T1.[ServicoExecutanteId] = CONVERT( DECIMAL(28,14), @AV91ServicoExecutanteIdVarChar)) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008A11", "SELECT [FuncaoTipoHHId] AS FuncaoTipoHHId, [FuncaoId], [FuncaoTipoHoraValor] FROM [FuncaoTipoHora] WHERE [FuncaoId] = @AV62UsuarioFuncaoId and [FuncaoTipoHHId] = @AV92ExecutanteTipoHoraId ORDER BY [FuncaoId], [FuncaoTipoHHId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008A12", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008A13", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV89GestaoServicoIdVarChar) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A13,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                ((bool[]) buf[16])[0] = rslt.wasNull(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((short[]) buf[18])[0] = rslt.getShort(17);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((bool[]) buf[20])[0] = rslt.wasNull(18);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 18);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 10 :
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
             case 11 :
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
