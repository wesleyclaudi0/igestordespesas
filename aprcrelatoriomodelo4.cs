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
   public class aprcrelatoriomodelo4 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public aprcrelatoriomodelo4( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriomodelo4( IGxContext context )
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
         setOutputFileName("Modelo4.pdf");
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
            AV73EmpresaId = AV71SDTContexto.gxTpr_Empresaid;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P007T2 */
            pr_default.execute(0, new Object[] {AV73EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P007T2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P007T2_A40000EmpresaFoto_GXI[0];
               A2EmpresaNome = P007T2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P007T2_A3EmpresaCNPJ[0];
               A4EmpresaContato = P007T2_A4EmpresaContato[0];
               A5EmpresaEndereco = P007T2_A5EmpresaEndereco[0];
               AV14Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV80Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = A3EmpresaCNPJ;
               AV76EmpresaContato = A4EmpresaContato;
               AV77EmpresaEndereco = A5EmpresaEndereco;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV30GestaoServicoNumero = 100;
            AV24GestaoServicoDescricao = context.GetMessage( "Ordem de Servico Exemplo", "");
            AV42ServicoClienteNome = context.GetMessage( "Cliente 1", "");
            AV49ServicoSetorNome = context.GetMessage( "Setor 1", "");
            AV10AuxGestaoServicoPrioridade = context.GetMessage( "Alta", "");
            AV11AuxGestaoServicoStatus = context.GetMessage( "Pendente", "");
            AV26GestaoServicoDtProgramada = Gx_date;
            AV25GestaoServicoDtHora = DateTimeUtil.Now( context);
            AV74TipoDemandaVarChar = context.GetMessage( "Serviço", "");
            AV33GestaoServicoPrecificacaoVarChar = context.GetMessage( "Tipo de Serviço", "");
            AV20EnderecoLocal = context.GetMessage( "Rio de Janeiro, Centro", "");
            H7T0( false, 234) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 128, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 197, Gx_line+0, 547, Gx_line+33, 1, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16EmpresaFoto)) ? AV80Empresafoto_GXI : AV16EmpresaFoto);
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
            AV70i = 1;
            while ( AV70i <= 3 )
            {
               AV47ServicoNaturezaNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV70i), 4, 0));
               AV69TempoEstimado = context.GetMessage( "2 dias", "");
               AV68TerminoDate = DateTimeUtil.DAdd( Gx_date, (2));
               H7T0( false, 17) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TempoEstimado, "")), 333, Gx_line+0, 491, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV68TerminoDate, "99/99/99"), 542, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV70i = (short)(AV70i+1);
            }
            H7T0( false, 34) ;
            getPrinter().GxDrawRect(325, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+17, 684, Gx_line+34, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 75, Gx_line+17, 208, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 283, Gx_line+17, 391, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 417, Gx_line+17, 517, Gx_line+33, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+17, 683, Gx_line+34, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(275, Gx_line+17, 408, Gx_line+34, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 542, Gx_line+17, 642, Gx_line+33, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+34);
            AV51Total = (decimal)(150);
            AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
            AV78Total2VarChar = context.GetMessage( "R$ 450,00", "");
            AV66n = 1;
            while ( AV66n <= 3 )
            {
               AV67TipoServicoNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV66n), 4, 0));
               AV39NaturezaValorVarChar = context.GetMessage( "R$ 100,00", "");
               AV38NaturezaCustoVarChar = context.GetMessage( "R$ 50,00", "");
               H7T0( false, 17) ;
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
               AV66n = (short)(AV66n+1);
            }
            H7T0( false, 17) ;
            getPrinter().GxDrawRect(408, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Total2VarChar, "")), 542, Gx_line+1, 667, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+1, 525, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(275, Gx_line+0, 408, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            H7T0( false, 18) ;
            getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 75, Gx_line+0, 158, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 200, Gx_line+0, 275, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 292, Gx_line+0, 342, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 383, Gx_line+0, 450, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 475, Gx_line+0, 525, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 550, Gx_line+0, 608, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 625, Gx_line+0, 675, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(192, Gx_line+0, 284, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(342, Gx_line+0, 375, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(417, Gx_line+0, 467, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(542, Gx_line+0, 544, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(617, Gx_line+0, 619, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            AV65j = 1;
            while ( AV65j <= 3 )
            {
               AV75TecnicoNome = context.GetMessage( "Técnio N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV65j), 4, 0));
               AV55FuncaoHrNormal = context.GetMessage( "R$ 100,00", "");
               AV56FuncaoHr50 = context.GetMessage( "R$ 100,00", "");
               AV57FuncaoHr100 = context.GetMessage( "R$ 100,00", "");
               AV58FuncaoViagem = context.GetMessage( "R$ 100,00", "");
               AV59FuncaoNoturno = context.GetMessage( "R$ 100,00", "");
               AV60FuncaoDiaria = context.GetMessage( "R$ 100,00", "");
               H7T0( false, 17) ;
               getPrinter().GxDrawRect(617, Gx_line+0, 619, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(542, Gx_line+0, 545, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(417, Gx_line+0, 467, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(342, Gx_line+0, 375, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(192, Gx_line+0, 284, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoDiaria, "")), 625, Gx_line+0, 683, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoNoturno, "")), 550, Gx_line+0, 617, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoViagem, "")), 475, Gx_line+0, 533, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHr50, "")), 292, Gx_line+0, 367, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FuncaoHrNormal, "")), 200, Gx_line+0, 267, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TecnicoNome, "")), 75, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr100, "")), 383, Gx_line+0, 458, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV65j = (short)(AV65j+1);
            }
            H7T0( false, 202) ;
            getPrinter().GxDrawLine(83, Gx_line+150, 333, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(417, Gx_line+150, 667, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 150, Gx_line+167, 254, Gx_line+181, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 467, Gx_line+167, 602, Gx_line+181, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+202);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7T0( true, 0) ;
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

      protected void H7T0( bool bFoot ,
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
         P007T2_A1EmpresaId = new long[1] ;
         P007T2_A40000EmpresaFoto_GXI = new string[] {""} ;
         P007T2_A2EmpresaNome = new string[] {""} ;
         P007T2_A3EmpresaCNPJ = new string[] {""} ;
         P007T2_A4EmpresaContato = new string[] {""} ;
         P007T2_A5EmpresaEndereco = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A4EmpresaContato = "";
         A5EmpresaEndereco = "";
         AV14Descricao = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV80Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV76EmpresaContato = "";
         AV77EmpresaEndereco = "";
         AV24GestaoServicoDescricao = "";
         AV42ServicoClienteNome = "";
         AV49ServicoSetorNome = "";
         AV10AuxGestaoServicoPrioridade = "";
         AV11AuxGestaoServicoStatus = "";
         AV26GestaoServicoDtProgramada = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV25GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV74TipoDemandaVarChar = "";
         AV33GestaoServicoPrecificacaoVarChar = "";
         AV20EnderecoLocal = "";
         AV16EmpresaFoto = "";
         sImgUrl = "";
         AV47ServicoNaturezaNome = "";
         AV69TempoEstimado = "";
         AV68TerminoDate = DateTime.MinValue;
         AV52TotalVarChar = "";
         AV78Total2VarChar = "";
         AV67TipoServicoNome = "";
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV75TecnicoNome = "";
         AV55FuncaoHrNormal = "";
         AV56FuncaoHr50 = "";
         AV57FuncaoHr100 = "";
         AV58FuncaoViagem = "";
         AV59FuncaoNoturno = "";
         AV60FuncaoDiaria = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriomodelo4__default(),
            new Object[][] {
                new Object[] {
               P007T2_A1EmpresaId, P007T2_A40000EmpresaFoto_GXI, P007T2_A2EmpresaNome, P007T2_A3EmpresaCNPJ, P007T2_A4EmpresaContato, P007T2_A5EmpresaEndereco
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
      private short AV70i ;
      private short AV66n ;
      private short AV65j ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV73EmpresaId ;
      private long A1EmpresaId ;
      private long AV30GestaoServicoNumero ;
      private decimal AV51Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string A4EmpresaContato ;
      private string AV18EmpresaNome ;
      private string AV15EmpresaCNPJ ;
      private string AV76EmpresaContato ;
      private string AV42ServicoClienteNome ;
      private string AV49ServicoSetorNome ;
      private string AV10AuxGestaoServicoPrioridade ;
      private string AV11AuxGestaoServicoStatus ;
      private string AV20EnderecoLocal ;
      private string sImgUrl ;
      private string AV47ServicoNaturezaNome ;
      private string AV67TipoServicoNome ;
      private string AV75TecnicoNome ;
      private DateTime AV13DateTime ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime Gx_date ;
      private DateTime AV68TerminoDate ;
      private bool entryPointCalled ;
      private string A40000EmpresaFoto_GXI ;
      private string A5EmpresaEndereco ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV80Empresafoto_GXI ;
      private string AV77EmpresaEndereco ;
      private string AV24GestaoServicoDescricao ;
      private string AV74TipoDemandaVarChar ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV69TempoEstimado ;
      private string AV52TotalVarChar ;
      private string AV78Total2VarChar ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV55FuncaoHrNormal ;
      private string AV56FuncaoHr50 ;
      private string AV57FuncaoHr100 ;
      private string AV58FuncaoViagem ;
      private string AV59FuncaoNoturno ;
      private string AV60FuncaoDiaria ;
      private string AV16EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV72WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV71SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P007T2_A1EmpresaId ;
      private string[] P007T2_A40000EmpresaFoto_GXI ;
      private string[] P007T2_A2EmpresaNome ;
      private string[] P007T2_A3EmpresaCNPJ ;
      private string[] P007T2_A4EmpresaContato ;
      private string[] P007T2_A5EmpresaEndereco ;
   }

   public class aprcrelatoriomodelo4__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007T2;
          prmP007T2 = new Object[] {
          new ParDef("@AV73EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007T2", "SELECT [EmpresaId], [EmpresaFoto_GXI], [EmpresaNome], [EmpresaCNPJ], [EmpresaContato], [EmpresaEndereco] FROM [Empresa] WHERE [EmpresaId] = @AV73EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
