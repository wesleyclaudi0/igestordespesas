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
   public class aprcrelatoriomodelo2 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public aprcrelatoriomodelo2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriomodelo2( IGxContext context )
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
         setOutputFileName("Modelo2.pdf");
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
            AV67SDTContexto.FromJSonString(AV68WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV66EmpresaId = AV67SDTContexto.gxTpr_Empresaid;
            AV14DateTime = DateTimeUtil.Now( context);
            /* Using cursor P007R2 */
            pr_default.execute(0, new Object[] {AV66EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P007R2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P007R2_A40000EmpresaFoto_GXI[0];
               A2EmpresaNome = P007R2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P007R2_A3EmpresaCNPJ[0];
               AV15Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV18EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV54Url = StringUtil.StringReplace( AV18EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV78Empresafoto_GXI = AV54Url;
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
            AV69TipoDemandaVarChar = context.GetMessage( "Serviço", "");
            AV34GestaoServicoPrecificacaoVarChar = context.GetMessage( "Tipo de Serviço", "");
            AV21EnderecoLocal = context.GetMessage( "Rio de Janeiro, Centro", "");
            H7R0( false, 184) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Descricao, "")), 110, Gx_line+67, 343, Gx_line+100, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpresaNome, "")), 550, Gx_line+33, 767, Gx_line+48, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+17, 775, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nº da OS:", ""), 550, Gx_line+67, 625, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 617, Gx_line+69, 709, Gx_line+84, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Abertura:", ""), 550, Gx_line+83, 617, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26GestaoServicoDtHora, "99/99/9999 99:99:99"), 610, Gx_line+84, 710, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 550, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12AuxGestaoServicoStatus, "")), 597, Gx_line+119, 739, Gx_line+134, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Programada para:", ""), 550, Gx_line+100, 675, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV27GestaoServicoDtProgramada, "99/99/99"), 661, Gx_line+102, 753, Gx_line+117, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+184);
            H7R0( false, 151) ;
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
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43ServicoClienteNome, "")), 89, Gx_line+18, 306, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50ServicoSetorNome, "")), 86, Gx_line+51, 244, Gx_line+66, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EnderecoLocal, "")), 111, Gx_line+34, 311, Gx_line+49, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoPrioridade, "")), 478, Gx_line+18, 695, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 400, Gx_line+17, 500, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(392, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TipoDemandaVarChar, "")), 521, Gx_line+51, 663, Gx_line+66, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Demanda:", ""), 400, Gx_line+50, 533, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25GestaoServicoDescricao, "")), 111, Gx_line+68, 675, Gx_line+83, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34GestaoServicoPrecificacaoVarChar, "")), 486, Gx_line+35, 653, Gx_line+50, 0, 0, 0, 0) ;
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
            AV72i = 1;
            while ( AV72i <= 3 )
            {
               AV48ServicoNaturezaNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV72i), 4, 0));
               AV70TempoEstimado = context.GetMessage( "2 dias", "");
               AV71TerminoDate = DateTimeUtil.DAdd( Gx_date, (2));
               H7R0( false, 18) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48ServicoNaturezaNome, "")), 33, Gx_line+1, 191, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TempoEstimado, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV71TerminoDate, "99/99/99"), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV72i = (short)(AV72i+1);
            }
            H7R0( false, 51) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 342, Gx_line+17, 450, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 492, Gx_line+33, 625, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(250, Gx_line+33, 483, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+33, 250, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 25, Gx_line+33, 150, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 258, Gx_line+33, 391, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            AV74n = 1;
            while ( AV74n <= 3 )
            {
               AV73TipoServicoNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV74n), 4, 0));
               AV40NaturezaValorVarChar = context.GetMessage( "R$ 100,00", "");
               AV39NaturezaCustoVarChar = context.GetMessage( "R$ 50,00", "");
               H7R0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaCustoVarChar, "")), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40NaturezaValorVarChar, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TipoServicoNome, "")), 25, Gx_line+1, 183, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV74n = (short)(AV74n+1);
            }
            AV52Total = (decimal)(450);
            AV53TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV52Total, 18, 2));
            H7R0( false, 101) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TotalVarChar, "")), 592, Gx_line+18, 750, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+17, 550, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(483, Gx_line+17, 777, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(483, Gx_line+17, 583, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+67, 775, Gx_line+84, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+83, 775, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+83, 150, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+83, 192, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(200, Gx_line+83, 300, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+67, 441, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(292, Gx_line+83, 392, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+83, 283, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+83, 550, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+83, 358, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+83, 467, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(367, Gx_line+83, 492, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+83, 584, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+83, 675, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 692, Gx_line+83, 750, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(575, Gx_line+83, 683, Gx_line+100, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+101);
            AV75j = 1;
            while ( AV75j <= 3 )
            {
               AV76TecnicoNome = context.GetMessage( "Técnio N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV75j), 4, 0));
               AV56FuncaoHrNormal = context.GetMessage( "R$ 100,00", "");
               AV57FuncaoHr50 = context.GetMessage( "R$ 100,00", "");
               AV58FuncaoHr100 = context.GetMessage( "R$ 100,00", "");
               AV59FuncaoViagem = context.GetMessage( "R$ 100,00", "");
               AV60FuncaoNoturno = context.GetMessage( "R$ 100,00", "");
               AV61FuncaoDiaria = context.GetMessage( "R$ 100,00", "");
               H7R0( false, 18) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61FuncaoDiaria, "")), 692, Gx_line+0, 767, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoNoturno, "")), 592, Gx_line+0, 675, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr50, "")), 308, Gx_line+0, 391, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TecnicoNome, "")), 25, Gx_line+0, 200, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 200, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(683, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV75j = (short)(AV75j+1);
            }
            H7R0( false, 134) ;
            getPrinter().GxDrawLine(83, Gx_line+83, 333, Gx_line+83, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 467, Gx_line+100, 602, Gx_line+114, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 150, Gx_line+100, 254, Gx_line+114, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(417, Gx_line+83, 667, Gx_line+83, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+134);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7R0( true, 0) ;
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

      protected void H7R0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV14DateTime, "99/99/99 99:99"), 292, Gx_line+33, 475, Gx_line+48, 1, 0, 0, 0) ;
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
         AV67SDTContexto = new SdtSDTContexto(context);
         AV68WebSession = context.GetSession();
         AV14DateTime = (DateTime)(DateTime.MinValue);
         P007R2_A1EmpresaId = new long[1] ;
         P007R2_A40000EmpresaFoto_GXI = new string[] {""} ;
         P007R2_A2EmpresaNome = new string[] {""} ;
         P007R2_A3EmpresaCNPJ = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         AV15Descricao = "";
         AV18EmpresaFotoUrl = "";
         AV54Url = "";
         AV78Empresafoto_GXI = "";
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
         AV69TipoDemandaVarChar = "";
         AV34GestaoServicoPrecificacaoVarChar = "";
         AV21EnderecoLocal = "";
         AV48ServicoNaturezaNome = "";
         AV70TempoEstimado = "";
         AV71TerminoDate = DateTime.MinValue;
         AV73TipoServicoNome = "";
         AV40NaturezaValorVarChar = "";
         AV39NaturezaCustoVarChar = "";
         AV53TotalVarChar = "";
         AV76TecnicoNome = "";
         AV56FuncaoHrNormal = "";
         AV57FuncaoHr50 = "";
         AV58FuncaoHr100 = "";
         AV59FuncaoViagem = "";
         AV60FuncaoNoturno = "";
         AV61FuncaoDiaria = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriomodelo2__default(),
            new Object[][] {
                new Object[] {
               P007R2_A1EmpresaId, P007R2_A40000EmpresaFoto_GXI, P007R2_A2EmpresaNome, P007R2_A3EmpresaCNPJ
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
      private short AV74n ;
      private short AV75j ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV66EmpresaId ;
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
      private string AV48ServicoNaturezaNome ;
      private string AV73TipoServicoNome ;
      private string AV76TecnicoNome ;
      private DateTime AV14DateTime ;
      private DateTime AV26GestaoServicoDtHora ;
      private DateTime AV27GestaoServicoDtProgramada ;
      private DateTime Gx_date ;
      private DateTime AV71TerminoDate ;
      private bool entryPointCalled ;
      private string A40000EmpresaFoto_GXI ;
      private string AV15Descricao ;
      private string AV18EmpresaFotoUrl ;
      private string AV54Url ;
      private string AV78Empresafoto_GXI ;
      private string AV25GestaoServicoDescricao ;
      private string AV69TipoDemandaVarChar ;
      private string AV34GestaoServicoPrecificacaoVarChar ;
      private string AV70TempoEstimado ;
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
      private IGxSession AV68WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV67SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P007R2_A1EmpresaId ;
      private string[] P007R2_A40000EmpresaFoto_GXI ;
      private string[] P007R2_A2EmpresaNome ;
      private string[] P007R2_A3EmpresaCNPJ ;
   }

   public class aprcrelatoriomodelo2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007R2;
          prmP007R2 = new Object[] {
          new ParDef("@AV66EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007R2", "SELECT [EmpresaId], [EmpresaFoto_GXI], [EmpresaNome], [EmpresaCNPJ] FROM [Empresa] WHERE [EmpresaId] = @AV66EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R2,1, GxCacheFrequency.OFF ,false,true )
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
