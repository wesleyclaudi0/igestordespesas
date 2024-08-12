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
   public class aprcrelatoriosatisfacao : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
                  AV9PreenchidoPor = (short)(Math.Round(NumberUtil.Val( GetPar( "PreenchidoPor"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatoriosatisfacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriosatisfacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           short aP1_PreenchidoPor )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV9PreenchidoPor = aP1_PreenchidoPor;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_PreenchidoPor )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV9PreenchidoPor = aP1_PreenchidoPor;
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
         setOutputFileName("RelatorioSatisfacao.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            AV83SDTContexto.FromJSonString(AV112WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV111UsuarioId = AV83SDTContexto.gxTpr_Usuarioid;
            AV37EmpresaId = AV83SDTContexto.gxTpr_Empresaid;
            AV80PerfilUsuario = AV83SDTContexto.gxTpr_Usuarioperfil;
            AV30DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00CH2 */
            pr_default.execute(0, new Object[] {AV8GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00CH2_A36ServicoSetorId[0];
               A81GestaoServicoUsuarioId = P00CH2_A81GestaoServicoUsuarioId[0];
               A38GestaoServicoId = P00CH2_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00CH2_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00CH2_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00CH2_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00CH2_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00CH2_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00CH2_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00CH2_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00CH2_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00CH2_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00CH2_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00CH2_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00CH2_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00CH2_n53ServicoNaturezaId[0];
               A129EnderecoId = P00CH2_A129EnderecoId[0];
               n129EnderecoId = P00CH2_n129EnderecoId[0];
               A34ServicoClienteId = P00CH2_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00CH2_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P00CH2_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P00CH2_n420GestaoServicoTipoHH[0];
               A82GestaoServicoUsuarioNome = P00CH2_A82GestaoServicoUsuarioNome[0];
               A37ServicoSetorNome = P00CH2_A37ServicoSetorNome[0];
               A82GestaoServicoUsuarioNome = P00CH2_A82GestaoServicoUsuarioNome[0];
               A54ServicoNaturezaNome = P00CH2_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00CH2_A35ServicoClienteNome[0];
               AV86ServicoEmpresaId = A77ServicoEmpresaId;
               AV58GestaoServicoNumero = A79GestaoServicoNumero;
               AV52GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV85ServicoClienteNome = A35ServicoClienteNome;
               AV94ServicoSetorNome = A37ServicoSetorNome;
               AV92ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV23AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV24AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               AV54GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
               AV53GestaoServicoDtHora = A39GestaoServicoDtHora;
               AV60GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
               AV61GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
               AV90ServicoNaturezaId = A53ServicoNaturezaId;
               AV39EnderecoId = A129EnderecoId;
               AV84ServicoClienteId = A34ServicoClienteId;
               AV20TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               AV63GestaoServicoStatus = A42GestaoServicoStatus;
               AV18GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               AV82ResponsavelNome = A82GestaoServicoUsuarioNome;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00CH3 */
            pr_default.execute(1, new Object[] {AV86ServicoEmpresaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1EmpresaId = P00CH3_A1EmpresaId[0];
               A2EmpresaNome = P00CH3_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00CH3_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00CH3_A40000EmpresaFoto_GXI[0];
               AV38EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV32EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV36EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV108Url = StringUtil.StringReplace( AV36EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV115Empresafoto_GXI = AV108Url;
               AV35EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00CH4 */
            pr_default.execute(2, new Object[] {AV84ServicoClienteId, AV39EnderecoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A106ClienteEnderecoId = P00CH4_A106ClienteEnderecoId[0];
               A17ClienteId = P00CH4_A17ClienteId[0];
               A119ClienteContatoNome = P00CH4_A119ClienteContatoNome[0];
               A120ClienteContatoTelefone = P00CH4_A120ClienteContatoTelefone[0];
               A121ClienteContatoEmail = P00CH4_A121ClienteContatoEmail[0];
               A122ClienteContatoId = P00CH4_A122ClienteContatoId[0];
               AV28ClienteContatoNome = A119ClienteContatoNome;
               AV29ClienteContatoTelefone = A120ClienteContatoTelefone;
               AV27ClienteContatoEmail = A121ClienteContatoEmail;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Using cursor P00CH5 */
            pr_default.execute(3, new Object[] {AV84ServicoClienteId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A17ClienteId = P00CH5_A17ClienteId[0];
               A513SatisfacaoId = P00CH5_A513SatisfacaoId[0];
               n513SatisfacaoId = P00CH5_n513SatisfacaoId[0];
               AV16SatisfacaoId = A513SatisfacaoId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            /* Using cursor P00CH6 */
            pr_default.execute(4, new Object[] {AV16SatisfacaoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A513SatisfacaoId = P00CH6_A513SatisfacaoId[0];
               n513SatisfacaoId = P00CH6_n513SatisfacaoId[0];
               A514SatisfacaoDescricao = P00CH6_A514SatisfacaoDescricao[0];
               AV10SatisfacaoDescricao = A514SatisfacaoDescricao;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            HCH0( false, 84) ;
            getPrinter().GxDrawRect(83, Gx_line+67, 700, Gx_line+84, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Requisito", ""), 100, Gx_line+67, 147, Gx_line+81, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Pergunta", ""), 308, Gx_line+67, 354, Gx_line+81, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Nota", ""), 617, Gx_line+67, 642, Gx_line+81, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(233, Gx_line+67, 300, Gx_line+84, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+67, 600, Gx_line+84, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(83, Gx_line+17, 700, Gx_line+34, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(83, Gx_line+33, 700, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("4", 547, Gx_line+18, 554, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("3", 445, Gx_line+18, 452, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("2", 333, Gx_line+18, 340, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("1", 238, Gx_line+18, 245, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "NA", ""), 127, Gx_line+18, 144, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("5", 650, Gx_line+18, 657, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+33, 500, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(550, Gx_line+33, 600, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(333, Gx_line+33, 400, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(217, Gx_line+33, 292, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(117, Gx_line+33, 184, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Não Aplicavél", ""), 100, Gx_line+33, 170, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Indiferente", ""), 423, Gx_line+34, 476, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Muito Satisfeito", ""), 614, Gx_line+34, 690, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Satisfeito", ""), 528, Gx_line+34, 574, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Insatisfeito", ""), 314, Gx_line+34, 367, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Muito Insatisfeito", ""), 194, Gx_line+33, 277, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(117, Gx_line+17, 184, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(225, Gx_line+17, 292, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(333, Gx_line+17, 400, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(433, Gx_line+17, 500, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+17, 600, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+84);
            /* Using cursor P00CH7 */
            pr_default.execute(5, new Object[] {AV8GestaoServicoId, AV9PreenchidoPor});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A522ClientePesquisaId = P00CH7_A522ClientePesquisaId[0];
               A34ServicoClienteId = P00CH7_A34ServicoClienteId[0];
               A38GestaoServicoId = P00CH7_A38GestaoServicoId[0];
               A536PesquisaPerfil = P00CH7_A536PesquisaPerfil[0];
               A513SatisfacaoId = P00CH7_A513SatisfacaoId[0];
               n513SatisfacaoId = P00CH7_n513SatisfacaoId[0];
               A524PesquisaNotaRequisitoId = P00CH7_A524PesquisaNotaRequisitoId[0];
               A530PesquisaNotaDescricao = P00CH7_A530PesquisaNotaDescricao[0];
               A527PesquisaNota = P00CH7_A527PesquisaNota[0];
               A523PesquisaNotaId = P00CH7_A523PesquisaNotaId[0];
               A38GestaoServicoId = P00CH7_A38GestaoServicoId[0];
               A34ServicoClienteId = P00CH7_A34ServicoClienteId[0];
               A513SatisfacaoId = P00CH7_A513SatisfacaoId[0];
               n513SatisfacaoId = P00CH7_n513SatisfacaoId[0];
               AV13PesquisaNotaDescricao = A530PesquisaNotaDescricao;
               if ( A527PesquisaNota == 0 )
               {
                  AV14PesquisaNota = context.GetMessage( "NA", "");
               }
               else
               {
                  AV14PesquisaNota = StringUtil.Trim( StringUtil.Str( (decimal)(A527PesquisaNota), 1, 0));
               }
               /* Using cursor P00CH8 */
               pr_default.execute(6, new Object[] {n513SatisfacaoId, A513SatisfacaoId, A524PesquisaNotaRequisitoId});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A516SatisfacaoRequisitoId = P00CH8_A516SatisfacaoRequisitoId[0];
                  A517SatisfacaoRequisitoDescricao = P00CH8_A517SatisfacaoRequisitoDescricao[0];
                  AV11SatisfacaoRequisitoDescricao = A517SatisfacaoRequisitoDescricao;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(6);
               HCH0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13PesquisaNotaDescricao, "")), 308, Gx_line+0, 591, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14PesquisaNota, "")), 617, Gx_line+1, 684, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11SatisfacaoRequisitoDescricao, "")), 100, Gx_line+1, 292, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+0, 700, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+0, 300, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(533, Gx_line+0, 600, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCH0( true, 0) ;
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

      protected void HCH0( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10SatisfacaoDescricao, "")), 338, Gx_line+50, 656, Gx_line+76, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ClienteContatoNome, "")), 308, Gx_line+250, 566, Gx_line+265, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ClienteContatoTelefone, "")), 308, Gx_line+267, 566, Gx_line+282, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ClienteContatoEmail, "")), 308, Gx_line+283, 658, Gx_line+298, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Descrição do Serviço", ""), 308, Gx_line+300, 452, Gx_line+316, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+300, 700, Gx_line+317, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+317, 700, Gx_line+367, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 100, Gx_line+333, 183, Gx_line+347, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52GestaoServicoDescricao, "")), 308, Gx_line+321, 683, Gx_line+354, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+317, 300, Gx_line+367, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(225, Gx_line+250, 300, Gx_line+267, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+267, 300, Gx_line+284, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+283, 300, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Contato:", ""), 100, Gx_line+250, 143, Gx_line+264, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Telefone:", ""), 100, Gx_line+267, 148, Gx_line+281, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email:", ""), 100, Gx_line+283, 130, Gx_line+297, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+267, 700, Gx_line+284, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+283, 700, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+250, 700, Gx_line+267, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Informações do Cliente", ""), 317, Gx_line+233, 461, Gx_line+249, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+233, 700, Gx_line+250, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+183, 700, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+217, 300, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+200, 300, Gx_line+217, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+183, 300, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV54GestaoServicoDtProgramada, "99/99/99"), 308, Gx_line+200, 441, Gx_line+217, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23AuxGestaoServicoPrioridade, "")), 308, Gx_line+217, 450, Gx_line+232, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 100, Gx_line+183, 137, Gx_line+197, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Data Programada:", ""), 100, Gx_line+200, 200, Gx_line+214, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 100, Gx_line+217, 175, Gx_line+231, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+217, 700, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+200, 700, Gx_line+217, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Informações da OS", ""), 325, Gx_line+167, 469, Gx_line+183, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(425, Gx_line+133, 492, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(425, Gx_line+117, 492, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+133, 300, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(233, Gx_line+117, 300, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+167, 700, Gx_line+184, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82ResponsavelNome, "")), 500, Gx_line+133, 667, Gx_line+148, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+133, 700, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Responsável", ""), 550, Gx_line+117, 616, Gx_line+131, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Data", ""), 375, Gx_line+117, 400, Gx_line+131, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Status", ""), 158, Gx_line+117, 190, Gx_line+131, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+117, 700, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Status da OS", ""), 358, Gx_line+100, 433, Gx_line+116, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+100, 700, Gx_line+117, 1, 0, 0, 0, 1, 26, 111, 175, 0, 0, 0, 0, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV35EmpresaFoto)) ? AV115Empresafoto_GXI : AV35EmpresaFoto);
               getPrinter().GxDrawBitMap(sImgUrl, 88, Gx_line+21, 299, Gx_line+79) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24AuxGestaoServicoStatus, "")), 108, Gx_line+133, 250, Gx_line+148, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85ServicoClienteNome, "")), 308, Gx_line+184, 566, Gx_line+199, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV53GestaoServicoDtHora, "99/99/9999 99:99:99"), 342, Gx_line+133, 442, Gx_line+150, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(83, Gx_line+17, 700, Gx_line+84, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "PESQUISA DE SATISFAÇÃO", ""), 375, Gx_line+33, 624, Gx_line+54, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Status da OS", ""), 358, Gx_line+100, 433, Gx_line+116, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Informações da OS", ""), 325, Gx_line+167, 469, Gx_line+183, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Informações do Cliente", ""), 325, Gx_line+233, 469, Gx_line+249, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Descrição do Serviço", ""), 317, Gx_line+300, 461, Gx_line+316, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+367);
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
         AV83SDTContexto = new SdtSDTContexto(context);
         AV112WebSession = context.GetSession();
         AV30DateTime = (DateTime)(DateTime.MinValue);
         P00CH2_A36ServicoSetorId = new long[1] ;
         P00CH2_A81GestaoServicoUsuarioId = new long[1] ;
         P00CH2_A38GestaoServicoId = new long[1] ;
         P00CH2_A77ServicoEmpresaId = new long[1] ;
         P00CH2_A79GestaoServicoNumero = new long[1] ;
         P00CH2_A40GestaoServicoDescricao = new string[] {""} ;
         P00CH2_A35ServicoClienteNome = new string[] {""} ;
         P00CH2_A37ServicoSetorNome = new string[] {""} ;
         P00CH2_A54ServicoNaturezaNome = new string[] {""} ;
         P00CH2_A41GestaoServicoPrioridade = new short[1] ;
         P00CH2_A42GestaoServicoStatus = new short[1] ;
         P00CH2_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00CH2_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00CH2_A157GestaoServicoPrecificacao = new short[1] ;
         P00CH2_A53ServicoNaturezaId = new long[1] ;
         P00CH2_n53ServicoNaturezaId = new bool[] {false} ;
         P00CH2_A129EnderecoId = new long[1] ;
         P00CH2_n129EnderecoId = new bool[] {false} ;
         P00CH2_A34ServicoClienteId = new long[1] ;
         P00CH2_A322GestaoServicoTipoDemanda = new short[1] ;
         P00CH2_A420GestaoServicoTipoHH = new short[1] ;
         P00CH2_n420GestaoServicoTipoHH = new bool[] {false} ;
         P00CH2_A82GestaoServicoUsuarioNome = new string[] {""} ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         A82GestaoServicoUsuarioNome = "";
         AV52GestaoServicoDescricao = "";
         AV85ServicoClienteNome = "";
         AV94ServicoSetorNome = "";
         AV92ServicoNaturezaNome = "";
         AV23AuxGestaoServicoPrioridade = "";
         AV24AuxGestaoServicoStatus = "";
         AV54GestaoServicoDtProgramada = DateTime.MinValue;
         AV53GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV61GestaoServicoPrecificacaoVarChar = "";
         AV20TipoDemandaVarChar = "";
         AV82ResponsavelNome = "";
         P00CH3_A1EmpresaId = new long[1] ;
         P00CH3_A2EmpresaNome = new string[] {""} ;
         P00CH3_A3EmpresaCNPJ = new string[] {""} ;
         P00CH3_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV38EmpresaNome = "";
         AV32EmpresaCNPJ = "";
         AV36EmpresaFotoUrl = "";
         AV108Url = "";
         AV115Empresafoto_GXI = "";
         AV35EmpresaFoto = "";
         P00CH4_A106ClienteEnderecoId = new long[1] ;
         P00CH4_A17ClienteId = new long[1] ;
         P00CH4_A119ClienteContatoNome = new string[] {""} ;
         P00CH4_A120ClienteContatoTelefone = new string[] {""} ;
         P00CH4_A121ClienteContatoEmail = new string[] {""} ;
         P00CH4_A122ClienteContatoId = new long[1] ;
         A119ClienteContatoNome = "";
         A120ClienteContatoTelefone = "";
         A121ClienteContatoEmail = "";
         AV28ClienteContatoNome = "";
         AV29ClienteContatoTelefone = "";
         AV27ClienteContatoEmail = "";
         P00CH5_A17ClienteId = new long[1] ;
         P00CH5_A513SatisfacaoId = new long[1] ;
         P00CH5_n513SatisfacaoId = new bool[] {false} ;
         P00CH6_A513SatisfacaoId = new long[1] ;
         P00CH6_n513SatisfacaoId = new bool[] {false} ;
         P00CH6_A514SatisfacaoDescricao = new string[] {""} ;
         A514SatisfacaoDescricao = "";
         AV10SatisfacaoDescricao = "";
         P00CH7_A522ClientePesquisaId = new long[1] ;
         P00CH7_A34ServicoClienteId = new long[1] ;
         P00CH7_A38GestaoServicoId = new long[1] ;
         P00CH7_A536PesquisaPerfil = new short[1] ;
         P00CH7_A513SatisfacaoId = new long[1] ;
         P00CH7_n513SatisfacaoId = new bool[] {false} ;
         P00CH7_A524PesquisaNotaRequisitoId = new long[1] ;
         P00CH7_A530PesquisaNotaDescricao = new string[] {""} ;
         P00CH7_A527PesquisaNota = new short[1] ;
         P00CH7_A523PesquisaNotaId = new long[1] ;
         A530PesquisaNotaDescricao = "";
         AV13PesquisaNotaDescricao = "";
         AV14PesquisaNota = "";
         P00CH8_A513SatisfacaoId = new long[1] ;
         P00CH8_n513SatisfacaoId = new bool[] {false} ;
         P00CH8_A516SatisfacaoRequisitoId = new long[1] ;
         P00CH8_A517SatisfacaoRequisitoDescricao = new string[] {""} ;
         A517SatisfacaoRequisitoDescricao = "";
         AV11SatisfacaoRequisitoDescricao = "";
         AV35EmpresaFoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriosatisfacao__default(),
            new Object[][] {
                new Object[] {
               P00CH2_A36ServicoSetorId, P00CH2_A81GestaoServicoUsuarioId, P00CH2_A38GestaoServicoId, P00CH2_A77ServicoEmpresaId, P00CH2_A79GestaoServicoNumero, P00CH2_A40GestaoServicoDescricao, P00CH2_A35ServicoClienteNome, P00CH2_A37ServicoSetorNome, P00CH2_A54ServicoNaturezaNome, P00CH2_A41GestaoServicoPrioridade,
               P00CH2_A42GestaoServicoStatus, P00CH2_A43GestaoServicoDtProgramada, P00CH2_A39GestaoServicoDtHora, P00CH2_A157GestaoServicoPrecificacao, P00CH2_A53ServicoNaturezaId, P00CH2_n53ServicoNaturezaId, P00CH2_A129EnderecoId, P00CH2_n129EnderecoId, P00CH2_A34ServicoClienteId, P00CH2_A322GestaoServicoTipoDemanda,
               P00CH2_A420GestaoServicoTipoHH, P00CH2_n420GestaoServicoTipoHH, P00CH2_A82GestaoServicoUsuarioNome
               }
               , new Object[] {
               P00CH3_A1EmpresaId, P00CH3_A2EmpresaNome, P00CH3_A3EmpresaCNPJ, P00CH3_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00CH4_A106ClienteEnderecoId, P00CH4_A17ClienteId, P00CH4_A119ClienteContatoNome, P00CH4_A120ClienteContatoTelefone, P00CH4_A121ClienteContatoEmail, P00CH4_A122ClienteContatoId
               }
               , new Object[] {
               P00CH5_A17ClienteId, P00CH5_A513SatisfacaoId, P00CH5_n513SatisfacaoId
               }
               , new Object[] {
               P00CH6_A513SatisfacaoId, P00CH6_A514SatisfacaoDescricao
               }
               , new Object[] {
               P00CH7_A522ClientePesquisaId, P00CH7_A34ServicoClienteId, P00CH7_A38GestaoServicoId, P00CH7_A536PesquisaPerfil, P00CH7_A513SatisfacaoId, P00CH7_n513SatisfacaoId, P00CH7_A524PesquisaNotaRequisitoId, P00CH7_A530PesquisaNotaDescricao, P00CH7_A527PesquisaNota, P00CH7_A523PesquisaNotaId
               }
               , new Object[] {
               P00CH8_A513SatisfacaoId, P00CH8_A516SatisfacaoRequisitoId, P00CH8_A517SatisfacaoRequisitoDescricao
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9PreenchidoPor ;
      private short GxWebError ;
      private short AV80PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV60GestaoServicoPrecificacao ;
      private short AV63GestaoServicoStatus ;
      private short AV18GestaoServicoTipoHH ;
      private short A536PesquisaPerfil ;
      private short A527PesquisaNota ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV8GestaoServicoId ;
      private long AV111UsuarioId ;
      private long AV37EmpresaId ;
      private long A36ServicoSetorId ;
      private long A81GestaoServicoUsuarioId ;
      private long A38GestaoServicoId ;
      private long A77ServicoEmpresaId ;
      private long A79GestaoServicoNumero ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long A34ServicoClienteId ;
      private long AV86ServicoEmpresaId ;
      private long AV58GestaoServicoNumero ;
      private long AV90ServicoNaturezaId ;
      private long AV39EnderecoId ;
      private long AV84ServicoClienteId ;
      private long A1EmpresaId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A122ClienteContatoId ;
      private long A513SatisfacaoId ;
      private long AV16SatisfacaoId ;
      private long A522ClientePesquisaId ;
      private long A524PesquisaNotaRequisitoId ;
      private long A523PesquisaNotaId ;
      private long A516SatisfacaoRequisitoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string A82GestaoServicoUsuarioNome ;
      private string AV85ServicoClienteNome ;
      private string AV94ServicoSetorNome ;
      private string AV92ServicoNaturezaNome ;
      private string AV23AuxGestaoServicoPrioridade ;
      private string AV24AuxGestaoServicoStatus ;
      private string AV82ResponsavelNome ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV38EmpresaNome ;
      private string AV32EmpresaCNPJ ;
      private string A119ClienteContatoNome ;
      private string A120ClienteContatoTelefone ;
      private string AV28ClienteContatoNome ;
      private string AV29ClienteContatoTelefone ;
      private string A514SatisfacaoDescricao ;
      private string AV10SatisfacaoDescricao ;
      private string sImgUrl ;
      private DateTime AV30DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV53GestaoServicoDtHora ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV54GestaoServicoDtProgramada ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n420GestaoServicoTipoHH ;
      private bool n513SatisfacaoId ;
      private string A40GestaoServicoDescricao ;
      private string AV52GestaoServicoDescricao ;
      private string AV61GestaoServicoPrecificacaoVarChar ;
      private string AV20TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV36EmpresaFotoUrl ;
      private string AV108Url ;
      private string AV115Empresafoto_GXI ;
      private string A121ClienteContatoEmail ;
      private string AV27ClienteContatoEmail ;
      private string A530PesquisaNotaDescricao ;
      private string AV13PesquisaNotaDescricao ;
      private string AV14PesquisaNota ;
      private string A517SatisfacaoRequisitoDescricao ;
      private string AV11SatisfacaoRequisitoDescricao ;
      private string AV35EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV112WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV83SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00CH2_A36ServicoSetorId ;
      private long[] P00CH2_A81GestaoServicoUsuarioId ;
      private long[] P00CH2_A38GestaoServicoId ;
      private long[] P00CH2_A77ServicoEmpresaId ;
      private long[] P00CH2_A79GestaoServicoNumero ;
      private string[] P00CH2_A40GestaoServicoDescricao ;
      private string[] P00CH2_A35ServicoClienteNome ;
      private string[] P00CH2_A37ServicoSetorNome ;
      private string[] P00CH2_A54ServicoNaturezaNome ;
      private short[] P00CH2_A41GestaoServicoPrioridade ;
      private short[] P00CH2_A42GestaoServicoStatus ;
      private DateTime[] P00CH2_A43GestaoServicoDtProgramada ;
      private DateTime[] P00CH2_A39GestaoServicoDtHora ;
      private short[] P00CH2_A157GestaoServicoPrecificacao ;
      private long[] P00CH2_A53ServicoNaturezaId ;
      private bool[] P00CH2_n53ServicoNaturezaId ;
      private long[] P00CH2_A129EnderecoId ;
      private bool[] P00CH2_n129EnderecoId ;
      private long[] P00CH2_A34ServicoClienteId ;
      private short[] P00CH2_A322GestaoServicoTipoDemanda ;
      private short[] P00CH2_A420GestaoServicoTipoHH ;
      private bool[] P00CH2_n420GestaoServicoTipoHH ;
      private string[] P00CH2_A82GestaoServicoUsuarioNome ;
      private long[] P00CH3_A1EmpresaId ;
      private string[] P00CH3_A2EmpresaNome ;
      private string[] P00CH3_A3EmpresaCNPJ ;
      private string[] P00CH3_A40000EmpresaFoto_GXI ;
      private long[] P00CH4_A106ClienteEnderecoId ;
      private long[] P00CH4_A17ClienteId ;
      private string[] P00CH4_A119ClienteContatoNome ;
      private string[] P00CH4_A120ClienteContatoTelefone ;
      private string[] P00CH4_A121ClienteContatoEmail ;
      private long[] P00CH4_A122ClienteContatoId ;
      private long[] P00CH5_A17ClienteId ;
      private long[] P00CH5_A513SatisfacaoId ;
      private bool[] P00CH5_n513SatisfacaoId ;
      private long[] P00CH6_A513SatisfacaoId ;
      private bool[] P00CH6_n513SatisfacaoId ;
      private string[] P00CH6_A514SatisfacaoDescricao ;
      private long[] P00CH7_A522ClientePesquisaId ;
      private long[] P00CH7_A34ServicoClienteId ;
      private long[] P00CH7_A38GestaoServicoId ;
      private short[] P00CH7_A536PesquisaPerfil ;
      private long[] P00CH7_A513SatisfacaoId ;
      private bool[] P00CH7_n513SatisfacaoId ;
      private long[] P00CH7_A524PesquisaNotaRequisitoId ;
      private string[] P00CH7_A530PesquisaNotaDescricao ;
      private short[] P00CH7_A527PesquisaNota ;
      private long[] P00CH7_A523PesquisaNotaId ;
      private long[] P00CH8_A513SatisfacaoId ;
      private bool[] P00CH8_n513SatisfacaoId ;
      private long[] P00CH8_A516SatisfacaoRequisitoId ;
      private string[] P00CH8_A517SatisfacaoRequisitoDescricao ;
   }

   public class aprcrelatoriosatisfacao__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CH2;
          prmP00CH2 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CH3;
          prmP00CH3 = new Object[] {
          new ParDef("@AV86ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00CH4;
          prmP00CH4 = new Object[] {
          new ParDef("@AV84ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV39EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CH5;
          prmP00CH5 = new Object[] {
          new ParDef("@AV84ServicoClienteId",GXType.Decimal,18,0)
          };
          Object[] prmP00CH6;
          prmP00CH6 = new Object[] {
          new ParDef("@AV16SatisfacaoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CH7;
          prmP00CH7 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0) ,
          new ParDef("@AV9PreenchidoPor",GXType.Int16,4,0)
          };
          Object[] prmP00CH8;
          prmP00CH8 = new Object[] {
          new ParDef("@SatisfacaoId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@PesquisaNotaRequisitoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CH2", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoUsuarioId] AS GestaoServicoUsuarioId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T5.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T4.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH], T3.[UsuarioNome] AS GestaoServicoUsuarioNome FROM (((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T1.[GestaoServicoUsuarioId]) LEFT JOIN [Natureza] T4 ON T4.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T5 ON T5.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV8GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CH3", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV86ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CH4", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteContatoNome], [ClienteContatoTelefone], [ClienteContatoEmail], [ClienteContatoId] FROM [ClienteContato] WHERE [ClienteId] = @AV84ServicoClienteId and [ClienteEnderecoId] = @AV39EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CH5", "SELECT [ClienteId], [SatisfacaoId] FROM [Cliente] WHERE [ClienteId] = @AV84ServicoClienteId ORDER BY [ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CH6", "SELECT [SatisfacaoId], [SatisfacaoDescricao] FROM [Satisfacao] WHERE [SatisfacaoId] = @AV16SatisfacaoId ORDER BY [SatisfacaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CH7", "SELECT T1.[ClientePesquisaId], T3.[ServicoClienteId] AS ServicoClienteId, T2.[GestaoServicoId], T1.[PesquisaPerfil], T4.[SatisfacaoId], T1.[PesquisaNotaRequisitoId], T1.[PesquisaNotaDescricao], T1.[PesquisaNota], T1.[PesquisaNotaId] FROM ((([ClientePesquisaNota] T1 INNER JOIN [ClientePesquisa] T2 ON T2.[ClientePesquisaId] = T1.[ClientePesquisaId]) INNER JOIN [GestaoServico] T3 ON T3.[GestaoServicoId] = T2.[GestaoServicoId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T3.[ServicoClienteId]) WHERE (T2.[GestaoServicoId] = @AV8GestaoServicoId) AND (T1.[PesquisaPerfil] = @AV9PreenchidoPor) ORDER BY T1.[PesquisaNotaRequisitoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CH8", "SELECT [SatisfacaoId], [SatisfacaoRequisitoId], [SatisfacaoRequisitoDescricao] FROM [SatisfacaoRequisito] WHERE [SatisfacaoId] = @SatisfacaoId and [SatisfacaoRequisitoId] = @PesquisaNotaRequisitoId ORDER BY [SatisfacaoId], [SatisfacaoRequisitoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH8,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getString(3, 18);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
