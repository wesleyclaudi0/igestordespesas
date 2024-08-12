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
   public class aprcrelatoriomodelo1 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatoriomodelo1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriomodelo1( IGxContext context )
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("Modelo1.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11736, 0, 1, 1, 0, 1, 1) )
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
            AV66SDTContexto.FromJSonString(AV68WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV67EmpresaId = AV66SDTContexto.gxTpr_Empresaid;
            AV14DateTime = DateTimeUtil.Now( context);
            /* Using cursor P007M2 */
            pr_default.execute(0, new Object[] {AV67EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P007M2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P007M2_A40000EmpresaFoto_GXI[0];
               A2EmpresaNome = P007M2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P007M2_A3EmpresaCNPJ[0];
               AV15Descricao = context.GetMessage( "REGISTRO DE ORDEM DE SERVIÇO", "");
               AV18EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV54Url = StringUtil.StringReplace( AV18EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV76Empresafoto_GXI = AV54Url;
               AV17EmpresaFoto = "";
               AV19EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV16EmpresaCNPJ = A3EmpresaCNPJ;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV31GestaoServicoNumero = 100;
            AV25GestaoServicoDescricao = context.GetMessage( "Ordem de Servico Exemplo", "");
            AV43ServicoClienteNome = context.GetMessage( "Cliente 1", "");
            AV50ServicoSetorNome = context.GetMessage( "Setor 1", "");
            AV11AuxGestaoServicoPrioridade = context.GetMessage( "Alta", "");
            AV12AuxGestaoServicoStatus = context.GetMessage( "Pendente", "");
            AV27GestaoServicoDtProgramada = Gx_date;
            AV26GestaoServicoDtHora = DateTimeUtil.Now( context);
            AV73TipoDemandaVarChar = context.GetMessage( "Serviço", "");
            AV34GestaoServicoPrecificacaoVarChar = context.GetMessage( "Tipo de Serviço", "");
            AV21EnderecoLocal = context.GetMessage( "Rio de Janeiro, Centro", "");
            H7M0( false, 151) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Descricao, "")), 208, Gx_line+0, 558, Gx_line+33, 1, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17EmpresaFoto)) ? AV76Empresafoto_GXI : AV17EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 17, Gx_line+50, 182, Gx_line+115) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16EmpresaCNPJ, "")), 200, Gx_line+83, 442, Gx_line+98, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpresaNome, "")), 200, Gx_line+67, 442, Gx_line+82, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+66, 775, Gx_line+116, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "O.S Nº: ", ""), 617, Gx_line+68, 673, Gx_line+86, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 674, Gx_line+69, 766, Gx_line+86, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data da Abertura:", ""), 564, Gx_line+94, 672, Gx_line+112, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26GestaoServicoDtHora, "99/99/9999 99:99:99"), 668, Gx_line+95, 768, Gx_line+112, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+151);
            H7M0( false, 259) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+242, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 142, Gx_line+67, 200, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 142, Gx_line+133, 192, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 450, Gx_line+67, 533, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 142, Gx_line+100, 225, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 450, Gx_line+100, 508, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43ServicoClienteNome, "")), 200, Gx_line+68, 417, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50ServicoSetorNome, "")), 192, Gx_line+134, 350, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoPrioridade, "")), 524, Gx_line+68, 666, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12AuxGestaoServicoStatus, "")), 499, Gx_line+101, 641, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "DADOS GERAIS", ""), 325, Gx_line+17, 469, Gx_line+38, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EnderecoLocal, "")), 217, Gx_line+101, 417, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34GestaoServicoPrecificacaoVarChar, "")), 539, Gx_line+134, 756, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 450, Gx_line+133, 550, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Programada para:", ""), 142, Gx_line+167, 275, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV27GestaoServicoDtProgramada, "99/99/99"), 267, Gx_line+168, 392, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 142, Gx_line+200, 225, Gx_line+218, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25GestaoServicoDescricao, "")), 217, Gx_line+201, 750, Gx_line+218, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Demanda:", ""), 450, Gx_line+167, 592, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TipoDemandaVarChar, "")), 572, Gx_line+168, 722, Gx_line+185, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+259);
            AV72i = 1;
            while ( AV72i <= 2 )
            {
               AV74ServicoDescricao = context.GetMessage( "Serviço - ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV72i), 4, 0));
               AV48ServicoNaturezaNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV72i), 4, 0));
               AV71TempoEstimado = context.GetMessage( "2 dias", "");
               AV70TerminoDate = DateTimeUtil.DAdd( Gx_date, (2));
               H7M0( false, 133) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+117, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48ServicoNaturezaNome, "")), 250, Gx_line+51, 404, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço:", ""), 142, Gx_line+50, 267, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término Previsto:", ""), 142, Gx_line+83, 275, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado:", ""), 450, Gx_line+50, 583, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV70TerminoDate, "99/99/99"), 262, Gx_line+84, 420, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ServicoDescricao, "")), 182, Gx_line+9, 599, Gx_line+42, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TempoEstimado, "")), 572, Gx_line+51, 672, Gx_line+68, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+133);
               AV72i = (short)(AV72i+1);
            }
            AV40NaturezaValorVarChar = context.GetMessage( "R$ 100,00", "");
            AV39NaturezaCustoVarChar = context.GetMessage( "R$ 100,00", "");
            AV52Total = (decimal)(200);
            AV53TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV52Total, 18, 2));
            H7M0( false, 182) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+167, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo:", ""), 142, Gx_line+83, 192, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor do Serviço:", ""), 142, Gx_line+50, 309, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor Total:", ""), 142, Gx_line+117, 275, Gx_line+135, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TotalVarChar, "")), 450, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaCustoVarChar, "")), 450, Gx_line+83, 608, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40NaturezaValorVarChar, "")), 450, Gx_line+50, 608, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 450, Gx_line+38, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+182);
            AV65OrcamentoTipoHH = context.GetMessage( "ORÇAMENTO - NOME TÉCNICO", "");
            AV56FuncaoHrNormal = context.GetMessage( "R$ 100,00", "");
            AV57FuncaoHr50 = context.GetMessage( "R$ 100,00", "");
            AV58FuncaoHr100 = context.GetMessage( "R$ 100,00", "");
            AV59FuncaoViagem = context.GetMessage( "R$ 100,00", "");
            AV60FuncaoNoturno = context.GetMessage( "R$ 100,00", "");
            AV61FuncaoDiaria = context.GetMessage( "R$ 100,00", "");
            H7M0( false, 200) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+183, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 100%:", ""), 142, Gx_line+133, 217, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr Normal:", ""), 142, Gx_line+67, 225, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 50%:", ""), 142, Gx_line+100, 209, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Diária:", ""), 450, Gx_line+133, 508, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Viagem:", ""), 450, Gx_line+67, 517, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Noturno:", ""), 450, Gx_line+100, 517, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61FuncaoDiaria, "")), 500, Gx_line+133, 658, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoViagem, "")), 508, Gx_line+67, 666, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoNoturno, "")), 517, Gx_line+100, 675, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoHr100, "")), 208, Gx_line+133, 366, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr50, "")), 200, Gx_line+100, 358, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHrNormal, "")), 217, Gx_line+67, 375, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65OrcamentoTipoHH, "")), 176, Gx_line+17, 593, Gx_line+50, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+200);
            H7M0( false, 151) ;
            getPrinter().GxDrawLine(92, Gx_line+100, 342, Gx_line+100, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(425, Gx_line+100, 675, Gx_line+100, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 158, Gx_line+117, 262, Gx_line+131, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 475, Gx_line+117, 610, Gx_line+131, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+151);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7M0( true, 0) ;
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

      protected void H7M0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV14DateTime, "99/99/99 99:99"), 292, Gx_line+0, 475, Gx_line+15, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+0, 772, Gx_line+15, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+32);
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
         AV66SDTContexto = new SdtSDTContexto(context);
         AV68WebSession = context.GetSession();
         AV14DateTime = (DateTime)(DateTime.MinValue);
         P007M2_A1EmpresaId = new long[1] ;
         P007M2_A40000EmpresaFoto_GXI = new string[] {""} ;
         P007M2_A2EmpresaNome = new string[] {""} ;
         P007M2_A3EmpresaCNPJ = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         AV15Descricao = "";
         AV18EmpresaFotoUrl = "";
         AV54Url = "";
         AV76Empresafoto_GXI = "";
         AV17EmpresaFoto = "";
         AV19EmpresaNome = "";
         AV16EmpresaCNPJ = "";
         AV25GestaoServicoDescricao = "";
         AV43ServicoClienteNome = "";
         AV50ServicoSetorNome = "";
         AV11AuxGestaoServicoPrioridade = "";
         AV12AuxGestaoServicoStatus = "";
         AV27GestaoServicoDtProgramada = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV26GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV73TipoDemandaVarChar = "";
         AV34GestaoServicoPrecificacaoVarChar = "";
         AV21EnderecoLocal = "";
         AV17EmpresaFoto = "";
         sImgUrl = "";
         AV74ServicoDescricao = "";
         AV48ServicoNaturezaNome = "";
         AV71TempoEstimado = "";
         AV70TerminoDate = DateTime.MinValue;
         AV40NaturezaValorVarChar = "";
         AV39NaturezaCustoVarChar = "";
         AV53TotalVarChar = "";
         AV65OrcamentoTipoHH = "";
         AV56FuncaoHrNormal = "";
         AV57FuncaoHr50 = "";
         AV58FuncaoHr100 = "";
         AV59FuncaoViagem = "";
         AV60FuncaoNoturno = "";
         AV61FuncaoDiaria = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriomodelo1__default(),
            new Object[][] {
                new Object[] {
               P007M2_A1EmpresaId, P007M2_A40000EmpresaFoto_GXI, P007M2_A2EmpresaNome, P007M2_A3EmpresaCNPJ
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV72i ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV67EmpresaId ;
      private long A1EmpresaId ;
      private long AV31GestaoServicoNumero ;
      private decimal AV52Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV19EmpresaNome ;
      private string AV16EmpresaCNPJ ;
      private string AV43ServicoClienteNome ;
      private string AV50ServicoSetorNome ;
      private string AV11AuxGestaoServicoPrioridade ;
      private string AV12AuxGestaoServicoStatus ;
      private string AV21EnderecoLocal ;
      private string sImgUrl ;
      private string AV48ServicoNaturezaNome ;
      private string AV65OrcamentoTipoHH ;
      private DateTime AV14DateTime ;
      private DateTime AV26GestaoServicoDtHora ;
      private DateTime AV27GestaoServicoDtProgramada ;
      private DateTime Gx_date ;
      private DateTime AV70TerminoDate ;
      private bool entryPointCalled ;
      private string A40000EmpresaFoto_GXI ;
      private string AV15Descricao ;
      private string AV18EmpresaFotoUrl ;
      private string AV54Url ;
      private string AV76Empresafoto_GXI ;
      private string AV25GestaoServicoDescricao ;
      private string AV73TipoDemandaVarChar ;
      private string AV34GestaoServicoPrecificacaoVarChar ;
      private string AV74ServicoDescricao ;
      private string AV71TempoEstimado ;
      private string AV40NaturezaValorVarChar ;
      private string AV39NaturezaCustoVarChar ;
      private string AV53TotalVarChar ;
      private string AV56FuncaoHrNormal ;
      private string AV57FuncaoHr50 ;
      private string AV58FuncaoHr100 ;
      private string AV59FuncaoViagem ;
      private string AV60FuncaoNoturno ;
      private string AV61FuncaoDiaria ;
      private string AV17EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV68WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV66SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P007M2_A1EmpresaId ;
      private string[] P007M2_A40000EmpresaFoto_GXI ;
      private string[] P007M2_A2EmpresaNome ;
      private string[] P007M2_A3EmpresaCNPJ ;
   }

   public class aprcrelatoriomodelo1__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007M2;
          prmP007M2 = new Object[] {
          new ParDef("@AV67EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007M2", "SELECT [EmpresaId], [EmpresaFoto_GXI], [EmpresaNome], [EmpresaCNPJ] FROM [Empresa] WHERE [EmpresaId] = @AV67EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007M2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getString(4, 18);
                return;
       }
    }

 }

}
