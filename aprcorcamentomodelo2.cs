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
   public class aprcorcamentomodelo2 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcorcamentomodelo2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcorcamentomodelo2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
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
         setOutputFileName("OrcamentoM2.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11765, 0, 1, 1, 0, 1, 1) )
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
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00822 */
            pr_default.execute(0, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00822_A36ServicoSetorId[0];
               A38GestaoServicoId = P00822_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00822_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00822_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00822_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00822_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00822_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00822_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00822_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00822_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00822_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00822_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00822_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00822_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00822_n53ServicoNaturezaId[0];
               A129EnderecoId = P00822_A129EnderecoId[0];
               n129EnderecoId = P00822_n129EnderecoId[0];
               A34ServicoClienteId = P00822_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00822_A322GestaoServicoTipoDemanda[0];
               A37ServicoSetorNome = P00822_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00822_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00822_A35ServicoClienteNome[0];
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
               AV68TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00823 */
            pr_default.execute(1, new Object[] {AV41ServicoClienteId, AV19EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00823_A106ClienteEnderecoId[0];
               A17ClienteId = P00823_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00823_A107ClienteEnderecoLocal[0];
               AV20EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00824 */
            pr_default.execute(2, new Object[] {AV43ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P00824_A1EmpresaId[0];
               A2EmpresaNome = P00824_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00824_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00824_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV83Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H820( false, 184) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 110, Gx_line+67, 343, Gx_line+100, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpresaNome, "")), 550, Gx_line+33, 767, Gx_line+48, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+17, 775, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nº da OS:", ""), 550, Gx_line+67, 625, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 617, Gx_line+69, 709, Gx_line+84, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Abertura:", ""), 550, Gx_line+83, 617, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25GestaoServicoDtHora, "99/99/9999 99:99:99"), 610, Gx_line+84, 710, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 550, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoStatus, "")), 597, Gx_line+119, 739, Gx_line+134, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Programada para:", ""), 550, Gx_line+100, 675, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26GestaoServicoDtProgramada, "99/99/99"), 661, Gx_line+102, 753, Gx_line+117, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+184);
            H820( false, 151) ;
            getPrinter().GxDrawRect(17, Gx_line+117, 775, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "SERVIÇOS", ""), 350, Gx_line+117, 430, Gx_line+135, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DADOS DO CLIENTE", ""), 317, Gx_line+0, 484, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 33, Gx_line+17, 91, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 33, Gx_line+50, 83, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 33, Gx_line+33, 116, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ServicoClienteNome, "")), 89, Gx_line+18, 306, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49ServicoSetorNome, "")), 86, Gx_line+51, 244, Gx_line+66, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EnderecoLocal, "")), 111, Gx_line+34, 311, Gx_line+49, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AuxGestaoServicoPrioridade, "")), 478, Gx_line+18, 695, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 400, Gx_line+17, 500, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TipoDemandaVarChar, "")), 521, Gx_line+51, 663, Gx_line+66, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Demanda:", ""), 400, Gx_line+50, 533, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24GestaoServicoDescricao, "")), 111, Gx_line+68, 675, Gx_line+83, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoPrecificacaoVarChar, "")), 486, Gx_line+35, 653, Gx_line+50, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 400, Gx_line+33, 492, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 33, Gx_line+67, 116, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+67, 775, Gx_line+84, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+17, 775, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Término Previsto", ""), 492, Gx_line+133, 625, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(250, Gx_line+133, 483, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+133, 250, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 33, Gx_line+133, 158, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado", ""), 258, Gx_line+133, 391, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+133, 775, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+151);
            /* Using cursor P00825 */
            pr_default.execute(3, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P00825_A38GestaoServicoId[0];
               A326TipoServicoNome = P00825_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00825_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00825_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00825_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00825_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00825_A329TipoServicoEstimado[0];
               AV47ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV69TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " dia(s)", "");
               AV70TerminoDate = DateTimeUtil.DAdd( AV26GestaoServicoDtProgramada, (A329TipoServicoEstimado));
               AV79ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H820( false, 18) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 33, Gx_line+1, 191, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TempoEstimado, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV70TerminoDate, "99/99/99"), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV32GestaoServicoPrecificacao == 2 )
            {
               AV85GXV1 = 1;
               while ( AV85GXV1 <= AV79ServicoNaturezaIdCollection.Count )
               {
                  AV46ServicoNaturezaId = (long)(AV79ServicoNaturezaIdCollection.GetNumeric(AV85GXV1));
                  /* Using cursor P00826 */
                  pr_default.execute(4, new Object[] {AV46ServicoNaturezaId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A25NaturezaId = P00826_A25NaturezaId[0];
                     A162NaturezaValor = P00826_A162NaturezaValor[0];
                     A289NaturezaCusto = P00826_A289NaturezaCusto[0];
                     AV39NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                     AV38NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                     AV51Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                     AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
                     H820( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(483, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TipoServicoNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
                  AV85GXV1 = (int)(AV85GXV1+1);
               }
               H820( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TotalVarChar, "")), 592, Gx_line+18, 750, Gx_line+33, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+17, 550, Gx_line+35, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+17, 777, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+17, 583, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+35);
            }
            else
            {
               if ( AV32GestaoServicoPrecificacao == 1 )
               {
                  H820( false, 68) ;
                  getPrinter().GxDrawRect(567, Gx_line+50, 684, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 692, Gx_line+50, 750, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+50, 650, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(483, Gx_line+50, 583, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(367, Gx_line+50, 492, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+50, 467, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+50, 358, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+50, 550, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+50, 283, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(283, Gx_line+50, 391, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+33, 441, Gx_line+51, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(200, Gx_line+50, 300, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+50, 192, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+68);
                  /* Using cursor P00827 */
                  pr_default.execute(5, new Object[] {AV29GestaoServicoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A38GestaoServicoId = P00827_A38GestaoServicoId[0];
                     A55ServicoExecutanteId = P00827_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P00827_n55ServicoExecutanteId[0];
                     A131GestaoServicoExecutanteId = P00827_A131GestaoServicoExecutanteId[0];
                     AV44ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  AV88GXV2 = 1;
                  while ( AV88GXV2 <= AV44ServicoExecutanteIdCollection.Count )
                  {
                     AV78ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV88GXV2));
                     /* Using cursor P00828 */
                     pr_default.execute(6, new Object[] {AV78ServicoExecutanteId});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A9UsuarioId = P00828_A9UsuarioId[0];
                        A173UsuarioFuncaoId = P00828_A173UsuarioFuncaoId[0];
                        n173UsuarioFuncaoId = P00828_n173UsuarioFuncaoId[0];
                        A10UsuarioNome = P00828_A10UsuarioNome[0];
                        AV62UsuarioFuncaoId = A173UsuarioFuncaoId;
                        AV75TecnicoNome = StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(6);
                     /* Using cursor P00829 */
                     pr_default.execute(7, new Object[] {AV62UsuarioFuncaoId});
                     while ( (pr_default.getStatus(7) != 101) )
                     {
                        A163FuncaoId = P00829_A163FuncaoId[0];
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(7);
                     H820( false, 32) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoDiaria, "")), 692, Gx_line+0, 767, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoNoturno, "")), 592, Gx_line+0, 675, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHr50, "")), 308, Gx_line+0, 391, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TecnicoNome, "")), 25, Gx_line+0, 200, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 200, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(683, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+32);
                     AV88GXV2 = (int)(AV88GXV2+1);
                  }
               }
            }
            H820( false, 272) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 500, Gx_line+183, 635, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 183, Gx_line+183, 287, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(450, Gx_line+167, 700, Gx_line+167, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(117, Gx_line+167, 367, Gx_line+167, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+272);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H820( true, 0) ;
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

      protected void H820( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV13DateTime, "99/99/99 99:99"), 292, Gx_line+33, 475, Gx_line+48, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+0, 772, Gx_line+15, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
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
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P00822_A36ServicoSetorId = new long[1] ;
         P00822_A38GestaoServicoId = new long[1] ;
         P00822_A77ServicoEmpresaId = new long[1] ;
         P00822_A79GestaoServicoNumero = new long[1] ;
         P00822_A40GestaoServicoDescricao = new string[] {""} ;
         P00822_A35ServicoClienteNome = new string[] {""} ;
         P00822_A37ServicoSetorNome = new string[] {""} ;
         P00822_A54ServicoNaturezaNome = new string[] {""} ;
         P00822_A41GestaoServicoPrioridade = new short[1] ;
         P00822_A42GestaoServicoStatus = new short[1] ;
         P00822_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00822_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00822_A157GestaoServicoPrecificacao = new short[1] ;
         P00822_A53ServicoNaturezaId = new long[1] ;
         P00822_n53ServicoNaturezaId = new bool[] {false} ;
         P00822_A129EnderecoId = new long[1] ;
         P00822_n129EnderecoId = new bool[] {false} ;
         P00822_A34ServicoClienteId = new long[1] ;
         P00822_A322GestaoServicoTipoDemanda = new short[1] ;
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
         AV68TipoDemandaVarChar = "";
         P00823_A106ClienteEnderecoId = new long[1] ;
         P00823_A17ClienteId = new long[1] ;
         P00823_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV20EnderecoLocal = "";
         P00824_A1EmpresaId = new long[1] ;
         P00824_A2EmpresaNome = new string[] {""} ;
         P00824_A3EmpresaCNPJ = new string[] {""} ;
         P00824_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV83Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         P00825_A38GestaoServicoId = new long[1] ;
         P00825_A326TipoServicoNome = new string[] {""} ;
         P00825_A329TipoServicoEstimado = new short[1] ;
         P00825_A325TipoServicoId = new long[1] ;
         P00825_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV69TempoEstimado = "";
         AV70TerminoDate = DateTime.MinValue;
         AV79ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00826_A25NaturezaId = new long[1] ;
         P00826_A162NaturezaValor = new decimal[1] ;
         P00826_A289NaturezaCusto = new decimal[1] ;
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         AV72TipoServicoNome = "";
         P00827_A38GestaoServicoId = new long[1] ;
         P00827_A55ServicoExecutanteId = new long[1] ;
         P00827_n55ServicoExecutanteId = new bool[] {false} ;
         P00827_A131GestaoServicoExecutanteId = new long[1] ;
         AV44ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P00828_A9UsuarioId = new long[1] ;
         P00828_A173UsuarioFuncaoId = new long[1] ;
         P00828_n173UsuarioFuncaoId = new bool[] {false} ;
         P00828_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV75TecnicoNome = "";
         P00829_A163FuncaoId = new long[1] ;
         AV60FuncaoDiaria = "";
         AV58FuncaoViagem = "";
         AV59FuncaoNoturno = "";
         AV57FuncaoHr100 = "";
         AV56FuncaoHr50 = "";
         AV55FuncaoHrNormal = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcorcamentomodelo2__default(),
            new Object[][] {
                new Object[] {
               P00822_A36ServicoSetorId, P00822_A38GestaoServicoId, P00822_A77ServicoEmpresaId, P00822_A79GestaoServicoNumero, P00822_A40GestaoServicoDescricao, P00822_A35ServicoClienteNome, P00822_A37ServicoSetorNome, P00822_A54ServicoNaturezaNome, P00822_A41GestaoServicoPrioridade, P00822_A42GestaoServicoStatus,
               P00822_A43GestaoServicoDtProgramada, P00822_A39GestaoServicoDtHora, P00822_A157GestaoServicoPrecificacao, P00822_A53ServicoNaturezaId, P00822_n53ServicoNaturezaId, P00822_A129EnderecoId, P00822_n129EnderecoId, P00822_A34ServicoClienteId, P00822_A322GestaoServicoTipoDemanda
               }
               , new Object[] {
               P00823_A106ClienteEnderecoId, P00823_A17ClienteId, P00823_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00824_A1EmpresaId, P00824_A2EmpresaNome, P00824_A3EmpresaCNPJ, P00824_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00825_A38GestaoServicoId, P00825_A326TipoServicoNome, P00825_A329TipoServicoEstimado, P00825_A325TipoServicoId, P00825_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00826_A25NaturezaId, P00826_A162NaturezaValor, P00826_A289NaturezaCusto
               }
               , new Object[] {
               P00827_A38GestaoServicoId, P00827_A55ServicoExecutanteId, P00827_n55ServicoExecutanteId, P00827_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00828_A9UsuarioId, P00828_A173UsuarioFuncaoId, P00828_n173UsuarioFuncaoId, P00828_A10UsuarioNome
               }
               , new Object[] {
               P00829_A163FuncaoId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short AV32GestaoServicoPrecificacao ;
      private short A329TipoServicoEstimado ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV85GXV1 ;
      private int AV88GXV2 ;
      private long AV29GestaoServicoId ;
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
      private long AV78ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV62UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV51Total ;
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
      private string A326TipoServicoNome ;
      private string AV72TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV75TecnicoNome ;
      private DateTime AV13DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime AV70TerminoDate ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string A40GestaoServicoDescricao ;
      private string AV24GestaoServicoDescricao ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV68TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV83Empresafoto_GXI ;
      private string AV69TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV60FuncaoDiaria ;
      private string AV58FuncaoViagem ;
      private string AV59FuncaoNoturno ;
      private string AV57FuncaoHr100 ;
      private string AV56FuncaoHr50 ;
      private string AV55FuncaoHrNormal ;
      private string AV16EmpresaFoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00822_A36ServicoSetorId ;
      private long[] P00822_A38GestaoServicoId ;
      private long[] P00822_A77ServicoEmpresaId ;
      private long[] P00822_A79GestaoServicoNumero ;
      private string[] P00822_A40GestaoServicoDescricao ;
      private string[] P00822_A35ServicoClienteNome ;
      private string[] P00822_A37ServicoSetorNome ;
      private string[] P00822_A54ServicoNaturezaNome ;
      private short[] P00822_A41GestaoServicoPrioridade ;
      private short[] P00822_A42GestaoServicoStatus ;
      private DateTime[] P00822_A43GestaoServicoDtProgramada ;
      private DateTime[] P00822_A39GestaoServicoDtHora ;
      private short[] P00822_A157GestaoServicoPrecificacao ;
      private long[] P00822_A53ServicoNaturezaId ;
      private bool[] P00822_n53ServicoNaturezaId ;
      private long[] P00822_A129EnderecoId ;
      private bool[] P00822_n129EnderecoId ;
      private long[] P00822_A34ServicoClienteId ;
      private short[] P00822_A322GestaoServicoTipoDemanda ;
      private long[] P00823_A106ClienteEnderecoId ;
      private long[] P00823_A17ClienteId ;
      private string[] P00823_A107ClienteEnderecoLocal ;
      private long[] P00824_A1EmpresaId ;
      private string[] P00824_A2EmpresaNome ;
      private string[] P00824_A3EmpresaCNPJ ;
      private string[] P00824_A40000EmpresaFoto_GXI ;
      private long[] P00825_A38GestaoServicoId ;
      private string[] P00825_A326TipoServicoNome ;
      private short[] P00825_A329TipoServicoEstimado ;
      private long[] P00825_A325TipoServicoId ;
      private long[] P00825_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV79ServicoNaturezaIdCollection ;
      private long[] P00826_A25NaturezaId ;
      private decimal[] P00826_A162NaturezaValor ;
      private decimal[] P00826_A289NaturezaCusto ;
      private long[] P00827_A38GestaoServicoId ;
      private long[] P00827_A55ServicoExecutanteId ;
      private bool[] P00827_n55ServicoExecutanteId ;
      private long[] P00827_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV44ServicoExecutanteIdCollection ;
      private long[] P00828_A9UsuarioId ;
      private long[] P00828_A173UsuarioFuncaoId ;
      private bool[] P00828_n173UsuarioFuncaoId ;
      private string[] P00828_A10UsuarioNome ;
      private long[] P00829_A163FuncaoId ;
   }

   public class aprcorcamentomodelo2__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00823;
          prmP00823 = new Object[] {
          new ParDef("@AV41ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00824;
          prmP00824 = new Object[] {
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00825;
          prmP00825 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00826;
          prmP00826 = new Object[] {
          new ParDef("@AV46ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00827;
          prmP00827 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00828;
          prmP00828 = new Object[] {
          new ParDef("@AV78ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00829;
          prmP00829 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00823", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV41ServicoClienteId and [ClienteEnderecoId] = @AV19EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00823,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00824", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV43ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00824,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00825", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00825,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00826", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV46ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00826,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00827", "SELECT [GestaoServicoId], [ServicoExecutanteId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV29GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00827,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00828", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV78ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00828,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00829", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV62UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00829,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
