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
   public class aprcorcamentomodelo3 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV39GestaoServicoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcorcamentomodelo3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcorcamentomodelo3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId )
      {
         this.AV39GestaoServicoId = aP0_GestaoServicoId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId )
      {
         this.AV39GestaoServicoId = aP0_GestaoServicoId;
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
         setOutputFileName("OrcamentoM3.pdf");
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
            AV16DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00832 */
            pr_default.execute(0, new Object[] {AV39GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00832_A36ServicoSetorId[0];
               A38GestaoServicoId = P00832_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00832_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00832_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00832_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00832_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00832_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00832_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00832_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00832_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00832_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00832_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00832_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00832_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00832_n53ServicoNaturezaId[0];
               A129EnderecoId = P00832_A129EnderecoId[0];
               n129EnderecoId = P00832_n129EnderecoId[0];
               A34ServicoClienteId = P00832_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00832_A322GestaoServicoTipoDemanda[0];
               A37ServicoSetorNome = P00832_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00832_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00832_A35ServicoClienteNome[0];
               AV59ServicoEmpresaId = A77ServicoEmpresaId;
               AV40GestaoServicoNumero = A79GestaoServicoNumero;
               AV34GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV58ServicoClienteNome = A35ServicoClienteNome;
               AV65ServicoSetorNome = A37ServicoSetorNome;
               AV63ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV13AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV14AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               AV36GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
               AV35GestaoServicoDtHora = A39GestaoServicoDtHora;
               AV42GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
               AV43GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
               AV62ServicoNaturezaId = A53ServicoNaturezaId;
               AV23EnderecoId = A129EnderecoId;
               AV57ServicoClienteId = A34ServicoClienteId;
               AV9TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00833 */
            pr_default.execute(1, new Object[] {AV57ServicoClienteId, AV23EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00833_A106ClienteEnderecoId[0];
               A17ClienteId = P00833_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00833_A107ClienteEnderecoLocal[0];
               AV24EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00834 */
            pr_default.execute(2, new Object[] {AV59ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P00834_A1EmpresaId[0];
               A2EmpresaNome = P00834_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00834_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00834_A40000EmpresaFoto_GXI[0];
               AV17Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV22EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV18EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV20EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV71Url = StringUtil.StringReplace( AV20EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV82Empresafoto_GXI = AV71Url;
               AV19EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H830( false, 235) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Descricao, "")), 250, Gx_line+17, 475, Gx_line+50, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19EmpresaFoto)) ? AV82Empresafoto_GXI : AV19EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 23, Gx_line+5, 208, Gx_line+62) ;
            getPrinter().GxDrawRect(492, Gx_line+0, 734, Gx_line+33, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nº da OS", ""), 500, Gx_line+8, 567, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 600, Gx_line+9, 692, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data da Abertura:", ""), 500, Gx_line+39, 617, Gx_line+57, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV35GestaoServicoDtHora, "99/99/9999 99:99:99"), 617, Gx_line+42, 717, Gx_line+59, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+233, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+33, 734, Gx_line+66, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 492, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(217, Gx_line+0, 492, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+100, 734, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+67, 734, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(217, Gx_line+67, 492, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+100, 217, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+67, 259, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 25, Gx_line+74, 83, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 500, Gx_line+74, 583, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13AuxGestaoServicoPrioridade, "")), 583, Gx_line+77, 725, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 500, Gx_line+107, 558, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AuxGestaoServicoStatus, "")), 558, Gx_line+109, 700, Gx_line+124, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58ServicoClienteNome, "")), 83, Gx_line+75, 216, Gx_line+90, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 225, Gx_line+74, 308, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24EnderecoLocal, "")), 308, Gx_line+75, 483, Gx_line+90, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 25, Gx_line+107, 75, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65ServicoSetorNome, "")), 75, Gx_line+108, 217, Gx_line+123, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 225, Gx_line+107, 325, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43GestaoServicoPrecificacaoVarChar, "")), 325, Gx_line+108, 467, Gx_line+123, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "SOBRE O SERVIÇO", ""), 317, Gx_line+183, 484, Gx_line+200, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+133, 492, Gx_line+166, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+133, 734, Gx_line+166, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado", ""), 258, Gx_line+217, 391, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+217, 734, Gx_line+234, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Término Previsto", ""), 492, Gx_line+217, 625, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(250, Gx_line+217, 483, Gx_line+234, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 33, Gx_line+217, 158, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data Programada:", ""), 500, Gx_line+141, 633, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV36GestaoServicoDtProgramada, "99/99/99"), 631, Gx_line+143, 723, Gx_line+158, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 25, Gx_line+141, 108, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34GestaoServicoDescricao, "")), 108, Gx_line+142, 466, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(217, Gx_line+100, 492, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+235);
            /* Using cursor P00835 */
            pr_default.execute(3, new Object[] {AV39GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P00835_A38GestaoServicoId[0];
               A326TipoServicoNome = P00835_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00835_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00835_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00835_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00835_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00835_A329TipoServicoEstimado[0];
               AV63ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV67TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " dia(s)", "");
               AV68TerminoDate = DateTimeUtil.DAdd( AV36GestaoServicoDtProgramada, (A329TipoServicoEstimado));
               AV78ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H830( false, 18) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV68TerminoDate, "99/99/99"), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TempoEstimado, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63ServicoNaturezaNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV42GestaoServicoPrecificacao == 2 )
            {
               AV84GXV1 = 1;
               while ( AV84GXV1 <= AV78ServicoNaturezaIdCollection.Count )
               {
                  AV62ServicoNaturezaId = (long)(AV78ServicoNaturezaIdCollection.GetNumeric(AV84GXV1));
                  /* Using cursor P00836 */
                  pr_default.execute(4, new Object[] {AV62ServicoNaturezaId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A25NaturezaId = P00836_A25NaturezaId[0];
                     A162NaturezaValor = P00836_A162NaturezaValor[0];
                     A289NaturezaCusto = P00836_A289NaturezaCusto[0];
                     AV52NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                     AV51NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                     AV69Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                     AV70TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV69Total, 18, 2));
                     H830( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10TipoServicoNome, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52NaturezaValorVarChar, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51NaturezaCustoVarChar, "")), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
                  AV84GXV1 = (int)(AV84GXV1+1);
               }
               H830( false, 33) ;
               getPrinter().GxDrawRect(483, Gx_line+0, 583, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+0, 550, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TotalVarChar, "")), 592, Gx_line+0, 717, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+33);
            }
            else
            {
               if ( AV42GestaoServicoPrecificacao == 1 )
               {
                  H830( false, 68) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+50, 734, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(200, Gx_line+50, 300, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 441, Gx_line+35, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(292, Gx_line+50, 392, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+50, 283, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+50, 358, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+50, 467, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(367, Gx_line+50, 492, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+50, 550, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+50, 650, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(492, Gx_line+50, 584, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 667, Gx_line+50, 717, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(583, Gx_line+50, 658, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+68);
                  /* Using cursor P00837 */
                  pr_default.execute(5, new Object[] {AV39GestaoServicoId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A38GestaoServicoId = P00837_A38GestaoServicoId[0];
                     A55ServicoExecutanteId = P00837_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P00837_n55ServicoExecutanteId[0];
                     A131GestaoServicoExecutanteId = P00837_A131GestaoServicoExecutanteId[0];
                     AV60ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  AV87GXV2 = 1;
                  while ( AV87GXV2 <= AV60ServicoExecutanteIdCollection.Count )
                  {
                     AV77ServicoExecutanteId = (long)(AV60ServicoExecutanteIdCollection.GetNumeric(AV87GXV2));
                     /* Using cursor P00838 */
                     pr_default.execute(6, new Object[] {AV77ServicoExecutanteId});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A9UsuarioId = P00838_A9UsuarioId[0];
                        A173UsuarioFuncaoId = P00838_A173UsuarioFuncaoId[0];
                        n173UsuarioFuncaoId = P00838_n173UsuarioFuncaoId[0];
                        A10UsuarioNome = P00838_A10UsuarioNome[0];
                        AV73UsuarioFuncaoId = A173UsuarioFuncaoId;
                        AV8TecnicoNome = StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(6);
                     /* Using cursor P00839 */
                     pr_default.execute(7, new Object[] {AV73UsuarioFuncaoId});
                     while ( (pr_default.getStatus(7) != 101) )
                     {
                        A163FuncaoId = P00839_A163FuncaoId[0];
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(7);
                     H830( false, 17) ;
                     getPrinter().GxDrawRect(658, Gx_line+0, 758, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8TecnicoNome, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27FuncaoHr50, "")), 308, Gx_line+0, 383, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FuncaoNoturno, "")), 592, Gx_line+0, 659, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FuncaoDiaria, "")), 667, Gx_line+0, 734, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     AV87GXV2 = (int)(AV87GXV2+1);
                  }
               }
            }
            H830( false, 214) ;
            getPrinter().GxDrawLine(92, Gx_line+133, 342, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(425, Gx_line+133, 675, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 158, Gx_line+150, 262, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 475, Gx_line+150, 610, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+0, 734, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+214);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H830( true, 0) ;
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

      protected void H830( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV16DateTime, "99/99/99 99:99"), 283, Gx_line+33, 466, Gx_line+48, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 658, Gx_line+33, 697, Gx_line+48, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+54);
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
         AV16DateTime = (DateTime)(DateTime.MinValue);
         P00832_A36ServicoSetorId = new long[1] ;
         P00832_A38GestaoServicoId = new long[1] ;
         P00832_A77ServicoEmpresaId = new long[1] ;
         P00832_A79GestaoServicoNumero = new long[1] ;
         P00832_A40GestaoServicoDescricao = new string[] {""} ;
         P00832_A35ServicoClienteNome = new string[] {""} ;
         P00832_A37ServicoSetorNome = new string[] {""} ;
         P00832_A54ServicoNaturezaNome = new string[] {""} ;
         P00832_A41GestaoServicoPrioridade = new short[1] ;
         P00832_A42GestaoServicoStatus = new short[1] ;
         P00832_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00832_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00832_A157GestaoServicoPrecificacao = new short[1] ;
         P00832_A53ServicoNaturezaId = new long[1] ;
         P00832_n53ServicoNaturezaId = new bool[] {false} ;
         P00832_A129EnderecoId = new long[1] ;
         P00832_n129EnderecoId = new bool[] {false} ;
         P00832_A34ServicoClienteId = new long[1] ;
         P00832_A322GestaoServicoTipoDemanda = new short[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV34GestaoServicoDescricao = "";
         AV58ServicoClienteNome = "";
         AV65ServicoSetorNome = "";
         AV63ServicoNaturezaNome = "";
         AV13AuxGestaoServicoPrioridade = "";
         AV14AuxGestaoServicoStatus = "";
         AV36GestaoServicoDtProgramada = DateTime.MinValue;
         AV35GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV43GestaoServicoPrecificacaoVarChar = "";
         AV9TipoDemandaVarChar = "";
         P00833_A106ClienteEnderecoId = new long[1] ;
         P00833_A17ClienteId = new long[1] ;
         P00833_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV24EnderecoLocal = "";
         P00834_A1EmpresaId = new long[1] ;
         P00834_A2EmpresaNome = new string[] {""} ;
         P00834_A3EmpresaCNPJ = new string[] {""} ;
         P00834_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV17Descricao = "";
         AV22EmpresaNome = "";
         AV18EmpresaCNPJ = "";
         AV20EmpresaFotoUrl = "";
         AV71Url = "";
         AV82Empresafoto_GXI = "";
         AV19EmpresaFoto = "";
         AV19EmpresaFoto = "";
         sImgUrl = "";
         P00835_A38GestaoServicoId = new long[1] ;
         P00835_A326TipoServicoNome = new string[] {""} ;
         P00835_A329TipoServicoEstimado = new short[1] ;
         P00835_A325TipoServicoId = new long[1] ;
         P00835_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV67TempoEstimado = "";
         AV68TerminoDate = DateTime.MinValue;
         AV78ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00836_A25NaturezaId = new long[1] ;
         P00836_A162NaturezaValor = new decimal[1] ;
         P00836_A289NaturezaCusto = new decimal[1] ;
         AV52NaturezaValorVarChar = "";
         AV51NaturezaCustoVarChar = "";
         AV70TotalVarChar = "";
         AV10TipoServicoNome = "";
         P00837_A38GestaoServicoId = new long[1] ;
         P00837_A55ServicoExecutanteId = new long[1] ;
         P00837_n55ServicoExecutanteId = new bool[] {false} ;
         P00837_A131GestaoServicoExecutanteId = new long[1] ;
         AV60ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P00838_A9UsuarioId = new long[1] ;
         P00838_A173UsuarioFuncaoId = new long[1] ;
         P00838_n173UsuarioFuncaoId = new bool[] {false} ;
         P00838_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV8TecnicoNome = "";
         P00839_A163FuncaoId = new long[1] ;
         AV28FuncaoHrNormal = "";
         AV27FuncaoHr50 = "";
         AV26FuncaoHr100 = "";
         AV29FuncaoNoturno = "";
         AV30FuncaoViagem = "";
         AV25FuncaoDiaria = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcorcamentomodelo3__default(),
            new Object[][] {
                new Object[] {
               P00832_A36ServicoSetorId, P00832_A38GestaoServicoId, P00832_A77ServicoEmpresaId, P00832_A79GestaoServicoNumero, P00832_A40GestaoServicoDescricao, P00832_A35ServicoClienteNome, P00832_A37ServicoSetorNome, P00832_A54ServicoNaturezaNome, P00832_A41GestaoServicoPrioridade, P00832_A42GestaoServicoStatus,
               P00832_A43GestaoServicoDtProgramada, P00832_A39GestaoServicoDtHora, P00832_A157GestaoServicoPrecificacao, P00832_A53ServicoNaturezaId, P00832_n53ServicoNaturezaId, P00832_A129EnderecoId, P00832_n129EnderecoId, P00832_A34ServicoClienteId, P00832_A322GestaoServicoTipoDemanda
               }
               , new Object[] {
               P00833_A106ClienteEnderecoId, P00833_A17ClienteId, P00833_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00834_A1EmpresaId, P00834_A2EmpresaNome, P00834_A3EmpresaCNPJ, P00834_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00835_A38GestaoServicoId, P00835_A326TipoServicoNome, P00835_A329TipoServicoEstimado, P00835_A325TipoServicoId, P00835_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00836_A25NaturezaId, P00836_A162NaturezaValor, P00836_A289NaturezaCusto
               }
               , new Object[] {
               P00837_A38GestaoServicoId, P00837_A55ServicoExecutanteId, P00837_n55ServicoExecutanteId, P00837_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00838_A9UsuarioId, P00838_A173UsuarioFuncaoId, P00838_n173UsuarioFuncaoId, P00838_A10UsuarioNome
               }
               , new Object[] {
               P00839_A163FuncaoId
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
      private short AV42GestaoServicoPrecificacao ;
      private short A329TipoServicoEstimado ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV84GXV1 ;
      private int AV87GXV2 ;
      private long AV39GestaoServicoId ;
      private long A36ServicoSetorId ;
      private long A38GestaoServicoId ;
      private long A77ServicoEmpresaId ;
      private long A79GestaoServicoNumero ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long A34ServicoClienteId ;
      private long AV59ServicoEmpresaId ;
      private long AV40GestaoServicoNumero ;
      private long AV62ServicoNaturezaId ;
      private long AV23EnderecoId ;
      private long AV57ServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A1EmpresaId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV77ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV73UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV69Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV58ServicoClienteNome ;
      private string AV65ServicoSetorNome ;
      private string AV63ServicoNaturezaNome ;
      private string AV13AuxGestaoServicoPrioridade ;
      private string AV14AuxGestaoServicoStatus ;
      private string A107ClienteEnderecoLocal ;
      private string AV24EnderecoLocal ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV22EmpresaNome ;
      private string AV18EmpresaCNPJ ;
      private string sImgUrl ;
      private string A326TipoServicoNome ;
      private string AV10TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV8TecnicoNome ;
      private DateTime AV16DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV35GestaoServicoDtHora ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV36GestaoServicoDtProgramada ;
      private DateTime AV68TerminoDate ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string A40GestaoServicoDescricao ;
      private string AV34GestaoServicoDescricao ;
      private string AV43GestaoServicoPrecificacaoVarChar ;
      private string AV9TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV17Descricao ;
      private string AV20EmpresaFotoUrl ;
      private string AV71Url ;
      private string AV82Empresafoto_GXI ;
      private string AV67TempoEstimado ;
      private string AV52NaturezaValorVarChar ;
      private string AV51NaturezaCustoVarChar ;
      private string AV70TotalVarChar ;
      private string AV28FuncaoHrNormal ;
      private string AV27FuncaoHr50 ;
      private string AV26FuncaoHr100 ;
      private string AV29FuncaoNoturno ;
      private string AV30FuncaoViagem ;
      private string AV25FuncaoDiaria ;
      private string AV19EmpresaFoto ;
      private string Empresafoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00832_A36ServicoSetorId ;
      private long[] P00832_A38GestaoServicoId ;
      private long[] P00832_A77ServicoEmpresaId ;
      private long[] P00832_A79GestaoServicoNumero ;
      private string[] P00832_A40GestaoServicoDescricao ;
      private string[] P00832_A35ServicoClienteNome ;
      private string[] P00832_A37ServicoSetorNome ;
      private string[] P00832_A54ServicoNaturezaNome ;
      private short[] P00832_A41GestaoServicoPrioridade ;
      private short[] P00832_A42GestaoServicoStatus ;
      private DateTime[] P00832_A43GestaoServicoDtProgramada ;
      private DateTime[] P00832_A39GestaoServicoDtHora ;
      private short[] P00832_A157GestaoServicoPrecificacao ;
      private long[] P00832_A53ServicoNaturezaId ;
      private bool[] P00832_n53ServicoNaturezaId ;
      private long[] P00832_A129EnderecoId ;
      private bool[] P00832_n129EnderecoId ;
      private long[] P00832_A34ServicoClienteId ;
      private short[] P00832_A322GestaoServicoTipoDemanda ;
      private long[] P00833_A106ClienteEnderecoId ;
      private long[] P00833_A17ClienteId ;
      private string[] P00833_A107ClienteEnderecoLocal ;
      private long[] P00834_A1EmpresaId ;
      private string[] P00834_A2EmpresaNome ;
      private string[] P00834_A3EmpresaCNPJ ;
      private string[] P00834_A40000EmpresaFoto_GXI ;
      private long[] P00835_A38GestaoServicoId ;
      private string[] P00835_A326TipoServicoNome ;
      private short[] P00835_A329TipoServicoEstimado ;
      private long[] P00835_A325TipoServicoId ;
      private long[] P00835_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV78ServicoNaturezaIdCollection ;
      private long[] P00836_A25NaturezaId ;
      private decimal[] P00836_A162NaturezaValor ;
      private decimal[] P00836_A289NaturezaCusto ;
      private long[] P00837_A38GestaoServicoId ;
      private long[] P00837_A55ServicoExecutanteId ;
      private bool[] P00837_n55ServicoExecutanteId ;
      private long[] P00837_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV60ServicoExecutanteIdCollection ;
      private long[] P00838_A9UsuarioId ;
      private long[] P00838_A173UsuarioFuncaoId ;
      private bool[] P00838_n173UsuarioFuncaoId ;
      private string[] P00838_A10UsuarioNome ;
      private long[] P00839_A163FuncaoId ;
   }

   public class aprcorcamentomodelo3__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00832;
          prmP00832 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00833;
          prmP00833 = new Object[] {
          new ParDef("@AV57ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV23EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00834;
          prmP00834 = new Object[] {
          new ParDef("@AV59ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00835;
          prmP00835 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00836;
          prmP00836 = new Object[] {
          new ParDef("@AV62ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00837;
          prmP00837 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00838;
          prmP00838 = new Object[] {
          new ParDef("@AV77ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00839;
          prmP00839 = new Object[] {
          new ParDef("@AV73UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00832", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV39GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00832,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00833", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV57ServicoClienteId and [ClienteEnderecoId] = @AV23EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00833,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00834", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV59ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00834,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00835", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV39GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00835,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00836", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV62ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00836,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00837", "SELECT [GestaoServicoId], [ServicoExecutanteId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV39GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00837,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00838", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV77ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00838,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00839", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV73UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00839,1, GxCacheFrequency.OFF ,false,true )
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
