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
   public class aprcrelatoriomodelo3 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public aprcrelatoriomodelo3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriomodelo3( IGxContext context )
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
         setOutputFileName("Modelo3.pdf");
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
            AV65SDTContexto.FromJSonString(AV66WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV67EmpresaId = AV65SDTContexto.gxTpr_Empresaid;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P007S2 */
            pr_default.execute(0, new Object[] {AV67EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P007S2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P007S2_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV78Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
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
            AV70TipoDemandaVarChar = context.GetMessage( "Serviço", "");
            AV33GestaoServicoPrecificacaoVarChar = context.GetMessage( "Tipo de Serviço", "");
            AV20EnderecoLocal = context.GetMessage( "Rio de Janeiro, Centro", "");
            H7S0( false, 235) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 250, Gx_line+17, 475, Gx_line+50, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16EmpresaFoto)) ? AV78Empresafoto_GXI : AV16EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 23, Gx_line+5, 208, Gx_line+62) ;
            getPrinter().GxDrawRect(492, Gx_line+0, 734, Gx_line+33, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nº da OS", ""), 500, Gx_line+8, 567, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 600, Gx_line+9, 692, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data da Abertura:", ""), 500, Gx_line+39, 617, Gx_line+57, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25GestaoServicoDtHora, "99/99/9999 99:99:99"), 617, Gx_line+42, 717, Gx_line+59, 0, 0, 0, 0) ;
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
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AuxGestaoServicoPrioridade, "")), 583, Gx_line+77, 725, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 500, Gx_line+107, 558, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoStatus, "")), 558, Gx_line+109, 700, Gx_line+124, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ServicoClienteNome, "")), 83, Gx_line+75, 216, Gx_line+90, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 225, Gx_line+74, 308, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EnderecoLocal, "")), 308, Gx_line+75, 483, Gx_line+90, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 25, Gx_line+107, 75, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49ServicoSetorNome, "")), 75, Gx_line+108, 217, Gx_line+123, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 225, Gx_line+107, 325, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoPrecificacaoVarChar, "")), 325, Gx_line+108, 467, Gx_line+123, 0, 0, 0, 0) ;
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
            getPrinter().GxDrawText(context.localUtil.Format( AV26GestaoServicoDtProgramada, "99/99/99"), 631, Gx_line+143, 723, Gx_line+158, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 25, Gx_line+141, 108, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24GestaoServicoDescricao, "")), 108, Gx_line+142, 466, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(217, Gx_line+100, 492, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+235);
            AV73i = 1;
            while ( AV73i <= 3 )
            {
               AV47ServicoNaturezaNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV73i), 4, 0));
               AV68TempoEstimado = context.GetMessage( "2 dias", "");
               AV69TerminoDate = DateTimeUtil.DAdd( Gx_date, (2));
               H7S0( false, 18) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV69TerminoDate, "99/99/99"), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TempoEstimado, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV73i = (short)(AV73i+1);
            }
            H7S0( false, 68) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 734, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 258, Gx_line+50, 391, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 250, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(250, Gx_line+50, 483, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 492, Gx_line+50, 625, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 441, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            AV74n = 1;
            while ( AV74n <= 3 )
            {
               AV71TipoServicoNome = context.GetMessage( "Serviço N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV74n), 4, 0));
               AV39NaturezaValorVarChar = context.GetMessage( "R$ 100,00", "");
               AV38NaturezaCustoVarChar = context.GetMessage( "R$ 50,00", "");
               H7S0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TipoServicoNome, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV74n = (short)(AV74n+1);
            }
            AV51Total = (decimal)(450);
            AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
            H7S0( false, 33) ;
            getPrinter().GxDrawRect(483, Gx_line+0, 583, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+0, 550, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TotalVarChar, "")), 592, Gx_line+0, 717, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+33);
            H7S0( false, 51) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+33, 734, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+33, 150, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(200, Gx_line+33, 300, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+0, 441, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(292, Gx_line+33, 392, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+33, 283, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+33, 358, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+33, 467, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(367, Gx_line+33, 492, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+33, 550, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+33, 650, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+33, 584, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 667, Gx_line+33, 717, Gx_line+51, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(583, Gx_line+33, 658, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            AV75j = 1;
            while ( AV75j <= 3 )
            {
               AV72TecnicoNome = context.GetMessage( "Técnico N", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV75j), 4, 0));
               AV55FuncaoHrNormal = context.GetMessage( "R$ 100,00", "");
               AV56FuncaoHr50 = context.GetMessage( "R$ 100,00", "");
               AV57FuncaoHr100 = context.GetMessage( "R$ 100,00", "");
               AV58FuncaoViagem = context.GetMessage( "R$ 100,00", "");
               AV59FuncaoNoturno = context.GetMessage( "R$ 100,00", "");
               AV60FuncaoDiaria = context.GetMessage( "R$ 100,00", "");
               H7S0( false, 17) ;
               getPrinter().GxDrawRect(658, Gx_line+0, 758, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TecnicoNome, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHr50, "")), 308, Gx_line+0, 383, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoNoturno, "")), 592, Gx_line+0, 659, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoDiaria, "")), 667, Gx_line+0, 734, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV75j = (short)(AV75j+1);
            }
            H7S0( false, 214) ;
            getPrinter().GxDrawLine(108, Gx_line+133, 358, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(442, Gx_line+133, 692, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 175, Gx_line+150, 279, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 492, Gx_line+150, 627, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+0, 734, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+214);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7S0( true, 0) ;
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

      protected void H7S0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV13DateTime, "99/99/99 99:99"), 283, Gx_line+33, 466, Gx_line+48, 1, 0, 0, 0) ;
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
         AV65SDTContexto = new SdtSDTContexto(context);
         AV66WebSession = context.GetSession();
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P007S2_A1EmpresaId = new long[1] ;
         P007S2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV78Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         AV24GestaoServicoDescricao = "";
         AV42ServicoClienteNome = "";
         AV49ServicoSetorNome = "";
         AV10AuxGestaoServicoPrioridade = "";
         AV11AuxGestaoServicoStatus = "";
         AV26GestaoServicoDtProgramada = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV25GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV70TipoDemandaVarChar = "";
         AV33GestaoServicoPrecificacaoVarChar = "";
         AV20EnderecoLocal = "";
         AV16EmpresaFoto = "";
         sImgUrl = "";
         AV47ServicoNaturezaNome = "";
         AV68TempoEstimado = "";
         AV69TerminoDate = DateTime.MinValue;
         AV71TipoServicoNome = "";
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         AV72TecnicoNome = "";
         AV55FuncaoHrNormal = "";
         AV56FuncaoHr50 = "";
         AV57FuncaoHr100 = "";
         AV58FuncaoViagem = "";
         AV59FuncaoNoturno = "";
         AV60FuncaoDiaria = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriomodelo3__default(),
            new Object[][] {
                new Object[] {
               P007S2_A1EmpresaId, P007S2_A40000EmpresaFoto_GXI
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
      private short AV73i ;
      private short AV74n ;
      private short AV75j ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV67EmpresaId ;
      private long A1EmpresaId ;
      private long AV30GestaoServicoNumero ;
      private decimal AV51Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV42ServicoClienteNome ;
      private string AV49ServicoSetorNome ;
      private string AV10AuxGestaoServicoPrioridade ;
      private string AV11AuxGestaoServicoStatus ;
      private string AV20EnderecoLocal ;
      private string sImgUrl ;
      private string AV47ServicoNaturezaNome ;
      private string AV71TipoServicoNome ;
      private string AV72TecnicoNome ;
      private DateTime AV13DateTime ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime Gx_date ;
      private DateTime AV69TerminoDate ;
      private bool entryPointCalled ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV78Empresafoto_GXI ;
      private string AV24GestaoServicoDescricao ;
      private string AV70TipoDemandaVarChar ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV68TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV55FuncaoHrNormal ;
      private string AV56FuncaoHr50 ;
      private string AV57FuncaoHr100 ;
      private string AV58FuncaoViagem ;
      private string AV59FuncaoNoturno ;
      private string AV60FuncaoDiaria ;
      private string AV16EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV66WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV65SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P007S2_A1EmpresaId ;
      private string[] P007S2_A40000EmpresaFoto_GXI ;
   }

   public class aprcrelatoriomodelo3__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007S2;
          prmP007S2 = new Object[] {
          new ParDef("@AV67EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007S2", "SELECT [EmpresaId], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV67EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
