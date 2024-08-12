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
   public class aprcexemplomodelomshs : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public aprcexemplomodelomshs( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcexemplomodelomshs( IGxContext context )
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
            AV75SDTContexto.FromJSonString(AV103WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV30EmpresaId = AV75SDTContexto.gxTpr_Empresaid;
            AV23DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00C12 */
            pr_default.execute(0, new Object[] {AV30EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00C12_A1EmpresaId[0];
               A2EmpresaNome = P00C12_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00C12_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00C12_A40000EmpresaFoto_GXI[0];
               AV24Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV31EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV25EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV29EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV99Url = StringUtil.StringReplace( AV29EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV106Empresafoto_GXI = AV99Url;
               AV28EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV51GestaoServicoNumero = 100;
            HC10( false, 417) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Número da OS:", ""), 292, Gx_line+100, 407, Gx_line+118, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV51GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 410, Gx_line+100, 502, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV46GestaoServicoDtHora, "99/99/9999 99:99:99"), 317, Gx_line+167, 417, Gx_line+184, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77ServicoClienteNome, "")), 283, Gx_line+218, 541, Gx_line+233, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17AuxGestaoServicoStatus, "")), 83, Gx_line+167, 225, Gx_line+182, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+400, 675, Gx_line+417, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado", ""), 283, Gx_line+400, 416, Gx_line+416, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Término Previsto", ""), 500, Gx_line+400, 633, Gx_line+416, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Serviço", ""), 67, Gx_line+400, 200, Gx_line+415, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(275, Gx_line+400, 483, Gx_line+417, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28EmpresaFoto)) ? AV106Empresafoto_GXI : AV28EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 258, Gx_line+17, 483, Gx_line+84) ;
            getPrinter().GxDrawRect(58, Gx_line+133, 675, Gx_line+150, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Status da OS", ""), 333, Gx_line+133, 408, Gx_line+149, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+150, 675, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Status", ""), 133, Gx_line+151, 165, Gx_line+165, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data", ""), 350, Gx_line+150, 375, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Responsável", ""), 525, Gx_line+150, 591, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+167, 675, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ResponsavelNome, "")), 475, Gx_line+167, 642, Gx_line+182, 1, 0, 0, 0) ;
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
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AuxGestaoServicoPrioridade, "")), 283, Gx_line+251, 425, Gx_line+266, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV47GestaoServicoDtProgramada, "99/99/99"), 283, Gx_line+234, 416, Gx_line+251, 0, 0, 0, 0) ;
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
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45GestaoServicoDescricao, "")), 283, Gx_line+355, 658, Gx_line+388, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 83, Gx_line+367, 166, Gx_line+381, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+350, 675, Gx_line+400, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+333, 675, Gx_line+350, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição do Serviço", ""), 283, Gx_line+333, 427, Gx_line+349, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ClienteContatoEmail, "")), 283, Gx_line+317, 633, Gx_line+332, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ClienteContatoTelefone, "")), 283, Gx_line+300, 541, Gx_line+315, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ClienteContatoNome, "")), 283, Gx_line+283, 541, Gx_line+298, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+417);
            HC10( false, 17) ;
            getPrinter().GxDrawRect(275, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84ServicoNaturezaNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92TempoEstimado, "")), 283, Gx_line+0, 441, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV94TerminoDate, "99/99/99"), 500, Gx_line+0, 633, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            HC10( false, 17) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 533, Gx_line+0, 633, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(525, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 408, Gx_line+0, 508, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 275, Gx_line+0, 383, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 67, Gx_line+0, 200, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 67, Gx_line+0, 200, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 275, Gx_line+0, 383, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 408, Gx_line+0, 508, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(525, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 533, Gx_line+0, 633, Gx_line+16, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            HC10( false, 17) ;
            getPrinter().GxDrawRect(267, Gx_line+0, 400, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(400, Gx_line+0, 525, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TotalVarChar, "")), 533, Gx_line+0, 658, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65NaturezaCustoVarChar, "")), 408, Gx_line+0, 525, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69NaturezaValorVarChar, "")), 275, Gx_line+0, 392, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipoServicoNome, "")), 67, Gx_line+0, 225, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            HC10( false, 17) ;
            getPrinter().GxDrawRect(400, Gx_line+0, 525, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(58, Gx_line+0, 675, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97Total2VarChar, "")), 533, Gx_line+0, 658, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 483, Gx_line+0, 516, Gx_line+16, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC10( true, 0) ;
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

      protected void HC10( bool bFoot ,
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
         AV75SDTContexto = new SdtSDTContexto(context);
         AV103WebSession = context.GetSession();
         AV23DateTime = (DateTime)(DateTime.MinValue);
         P00C12_A1EmpresaId = new long[1] ;
         P00C12_A2EmpresaNome = new string[] {""} ;
         P00C12_A3EmpresaCNPJ = new string[] {""} ;
         P00C12_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV24Descricao = "";
         AV31EmpresaNome = "";
         AV25EmpresaCNPJ = "";
         AV29EmpresaFotoUrl = "";
         AV99Url = "";
         AV106Empresafoto_GXI = "";
         AV28EmpresaFoto = "";
         AV46GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV77ServicoClienteNome = "";
         AV17AuxGestaoServicoStatus = "";
         AV28EmpresaFoto = "";
         sImgUrl = "";
         AV74ResponsavelNome = "";
         AV16AuxGestaoServicoPrioridade = "";
         AV47GestaoServicoDtProgramada = DateTime.MinValue;
         AV45GestaoServicoDescricao = "";
         AV20ClienteContatoEmail = "";
         AV22ClienteContatoTelefone = "";
         AV21ClienteContatoNome = "";
         AV84ServicoNaturezaNome = "";
         AV92TempoEstimado = "";
         AV94TerminoDate = DateTime.MinValue;
         AV98TotalVarChar = "";
         AV65NaturezaCustoVarChar = "";
         AV69NaturezaValorVarChar = "";
         AV95TipoServicoNome = "";
         AV97Total2VarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcexemplomodelomshs__default(),
            new Object[][] {
                new Object[] {
               P00C12_A1EmpresaId, P00C12_A2EmpresaNome, P00C12_A3EmpresaCNPJ, P00C12_A40000EmpresaFoto_GXI
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV30EmpresaId ;
      private long A1EmpresaId ;
      private long AV51GestaoServicoNumero ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV31EmpresaNome ;
      private string AV25EmpresaCNPJ ;
      private string AV77ServicoClienteNome ;
      private string AV17AuxGestaoServicoStatus ;
      private string sImgUrl ;
      private string AV74ResponsavelNome ;
      private string AV16AuxGestaoServicoPrioridade ;
      private string AV22ClienteContatoTelefone ;
      private string AV21ClienteContatoNome ;
      private string AV84ServicoNaturezaNome ;
      private string AV95TipoServicoNome ;
      private DateTime AV23DateTime ;
      private DateTime AV46GestaoServicoDtHora ;
      private DateTime AV47GestaoServicoDtProgramada ;
      private DateTime AV94TerminoDate ;
      private bool entryPointCalled ;
      private string A40000EmpresaFoto_GXI ;
      private string AV24Descricao ;
      private string AV29EmpresaFotoUrl ;
      private string AV99Url ;
      private string AV106Empresafoto_GXI ;
      private string AV45GestaoServicoDescricao ;
      private string AV20ClienteContatoEmail ;
      private string AV92TempoEstimado ;
      private string AV98TotalVarChar ;
      private string AV65NaturezaCustoVarChar ;
      private string AV69NaturezaValorVarChar ;
      private string AV97Total2VarChar ;
      private string AV28EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV103WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV75SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00C12_A1EmpresaId ;
      private string[] P00C12_A2EmpresaNome ;
      private string[] P00C12_A3EmpresaCNPJ ;
      private string[] P00C12_A40000EmpresaFoto_GXI ;
   }

   public class aprcexemplomodelomshs__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00C12;
          prmP00C12 = new Object[] {
          new ParDef("@AV30EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C12", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV30EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 18);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                return;
       }
    }

 }

}
