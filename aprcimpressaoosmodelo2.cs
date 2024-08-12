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
   public class aprcimpressaoosmodelo2 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
                  AV83Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcimpressaoosmodelo2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcimpressaoosmodelo2( IGxContext context )
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
         this.AV83Tela = aP1_Tela;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_Tela )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
         this.AV83Tela = aP1_Tela;
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
         setOutputFileName("ImpressaoM2.pdf");
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
            AV89SDTContexto.FromJSonString(AV90WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV54UsuarioId = AV89SDTContexto.gxTpr_Usuarioid;
            AV65EmpresaId = AV89SDTContexto.gxTpr_Empresaid;
            AV40PerfilUsuario = AV89SDTContexto.gxTpr_Usuarioperfil;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00882 */
            pr_default.execute(0, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00882_A36ServicoSetorId[0];
               A38GestaoServicoId = P00882_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00882_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00882_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00882_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00882_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00882_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00882_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00882_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00882_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00882_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00882_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00882_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00882_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00882_n53ServicoNaturezaId[0];
               A129EnderecoId = P00882_A129EnderecoId[0];
               n129EnderecoId = P00882_n129EnderecoId[0];
               A34ServicoClienteId = P00882_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00882_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P00882_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P00882_n420GestaoServicoTipoHH[0];
               A37ServicoSetorNome = P00882_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00882_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00882_A35ServicoClienteNome[0];
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
               AV66TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               AV35GestaoServicoStatus = A42GestaoServicoStatus;
               AV82GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00883 */
            pr_default.execute(1, new Object[] {AV41ServicoClienteId, AV19EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00883_A106ClienteEnderecoId[0];
               A17ClienteId = P00883_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00883_A107ClienteEnderecoLocal[0];
               AV20EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00884 */
            pr_default.execute(2, new Object[] {AV43ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P00884_A1EmpresaId[0];
               A2EmpresaNome = P00884_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00884_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00884_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV95Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H880( false, 184) ;
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
            H880( false, 151) ;
            getPrinter().GxDrawRect(17, Gx_line+117, 775, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "SERVIÇOS", ""), 342, Gx_line+117, 422, Gx_line+135, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DADOS DO CLIENTE", ""), 308, Gx_line+0, 475, Gx_line+18, 0, 0, 0, 0) ;
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
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TipoDemandaVarChar, "")), 521, Gx_line+51, 663, Gx_line+66, 0, 0, 0, 0) ;
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
            /* Using cursor P00885 */
            pr_default.execute(3, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P00885_A38GestaoServicoId[0];
               A326TipoServicoNome = P00885_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00885_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00885_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00885_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00885_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00885_A329TipoServicoEstimado[0];
               AV47ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV67TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
               AV91TerminoDateTime = DateTimeUtil.ResetTime( AV26GestaoServicoDtProgramada ) ;
               AV68TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV91TerminoDateTime, 3600*(A329TipoServicoEstimado)));
               AV78ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H880( false, 18) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 33, Gx_line+1, 191, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TempoEstimado, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV68TerminoDate, "99/99/99"), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV40PerfilUsuario != 4 )
            {
               if ( AV32GestaoServicoPrecificacao == 2 )
               {
                  H880( false, 51) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 342, Gx_line+17, 450, Gx_line+35, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Custo", ""), 492, Gx_line+33, 625, Gx_line+51, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(250, Gx_line+33, 483, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+33, 250, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 33, Gx_line+33, 158, Gx_line+51, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 258, Gx_line+33, 391, Gx_line+51, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+51);
                  AV97GXV1 = 1;
                  while ( AV97GXV1 <= AV78ServicoNaturezaIdCollection.Count )
                  {
                     AV46ServicoNaturezaId = (long)(AV78ServicoNaturezaIdCollection.GetNumeric(AV97GXV1));
                     /* Using cursor P00886 */
                     pr_default.execute(4, new Object[] {AV46ServicoNaturezaId});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A25NaturezaId = P00886_A25NaturezaId[0];
                        A26NaturezaNome = P00886_A26NaturezaNome[0];
                        A162NaturezaValor = P00886_A162NaturezaValor[0];
                        A289NaturezaCusto = P00886_A289NaturezaCusto[0];
                        AV70TipoServicoNome = StringUtil.Trim( A26NaturezaNome);
                        AV39NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                        AV38NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                        AV51Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                        AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
                        H880( false, 17) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(483, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TipoServicoNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     AV97GXV1 = (int)(AV97GXV1+1);
                  }
                  H880( false, 35) ;
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
                  AV87GestaoServicoIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GestaoServicoId), 18, 0));
                  if ( AV32GestaoServicoPrecificacao == 1 )
                  {
                     /* Using cursor P00887 */
                     pr_default.execute(5, new Object[] {AV87GestaoServicoIdVarChar});
                     while ( (pr_default.getStatus(5) != 101) )
                     {
                        A38GestaoServicoId = P00887_A38GestaoServicoId[0];
                        A55ServicoExecutanteId = P00887_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P00887_n55ServicoExecutanteId[0];
                        A131GestaoServicoExecutanteId = P00887_A131GestaoServicoExecutanteId[0];
                        AV100GXV2 = 1;
                        while ( AV100GXV2 <= AV44ServicoExecutanteIdCollection.Count )
                        {
                           AV75ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV100GXV2));
                           if ( AV75ServicoExecutanteId == A55ServicoExecutanteId )
                           {
                              AV88IsExiste = true;
                           }
                           else
                           {
                              AV88IsExiste = false;
                           }
                           AV100GXV2 = (int)(AV100GXV2+1);
                        }
                        if ( ! AV88IsExiste )
                        {
                           AV44ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                        }
                        pr_default.readNext(5);
                     }
                     pr_default.close(5);
                     AV101GXV3 = 1;
                     while ( AV101GXV3 <= AV44ServicoExecutanteIdCollection.Count )
                     {
                        AV75ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV101GXV3));
                        AV86ServicoExecutanteIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV75ServicoExecutanteId), 18, 0));
                        /* Using cursor P00888 */
                        pr_default.execute(6, new Object[] {AV75ServicoExecutanteId});
                        while ( (pr_default.getStatus(6) != 101) )
                        {
                           A9UsuarioId = P00888_A9UsuarioId[0];
                           A173UsuarioFuncaoId = P00888_A173UsuarioFuncaoId[0];
                           n173UsuarioFuncaoId = P00888_n173UsuarioFuncaoId[0];
                           A10UsuarioNome = P00888_A10UsuarioNome[0];
                           AV62UsuarioFuncaoId = A173UsuarioFuncaoId;
                           AV73TecnicoNome = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(6);
                        H880( false, 68) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor por Hora", ""), 442, Gx_line+50, 517, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+50, 192, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo de Hora", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(283, Gx_line+50, 383, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TecnicoNome, "")), 167, Gx_line+33, 606, Gx_line+51, 1+256, 0, 0, 0) ;
                        getPrinter().GxDrawRect(433, Gx_line+50, 533, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Qtd de Horas", ""), 292, Gx_line+50, 384, Gx_line+68, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+68);
                        if ( AV82GestaoServicoTipoHH == 2 )
                        {
                           /* Using cursor P00889 */
                           pr_default.execute(7, new Object[] {AV62UsuarioFuncaoId});
                           while ( (pr_default.getStatus(7) != 101) )
                           {
                              A341FuncaoTipoHHId = P00889_A341FuncaoTipoHHId[0];
                              A163FuncaoId = P00889_A163FuncaoId[0];
                              A343FuncaoTipoHHDescricao = P00889_A343FuncaoTipoHHDescricao[0];
                              A338FuncaoTipoHoraValor = P00889_A338FuncaoTipoHoraValor[0];
                              A343FuncaoTipoHHDescricao = P00889_A343FuncaoTipoHHDescricao[0];
                              AV79FuncaoTipoHoraDescricao = A343FuncaoTipoHHDescricao;
                              AV80FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                              H880( false, 18) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80FuncaoTipoHoraValorDescricao, "")), 442, Gx_line+0, 709, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79FuncaoTipoHoraDescricao, "")), 25, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 200, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(283, Gx_line+0, 583, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(433, Gx_line+0, 533, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV81QtdHoras), "ZZZ9")), 292, Gx_line+0, 384, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+18);
                              pr_default.readNext(7);
                           }
                           pr_default.close(7);
                        }
                        else
                        {
                           /* Using cursor P008810 */
                           pr_default.execute(8, new Object[] {AV87GestaoServicoIdVarChar, AV86ServicoExecutanteIdVarChar});
                           while ( (pr_default.getStatus(8) != 101) )
                           {
                              A55ServicoExecutanteId = P008810_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008810_n55ServicoExecutanteId[0];
                              A38GestaoServicoId = P008810_A38GestaoServicoId[0];
                              A423ExecutanteTipoHoraDescricao = P008810_A423ExecutanteTipoHoraDescricao[0];
                              A424GestaoServicoExecutanteQtdHora = P008810_A424GestaoServicoExecutanteQtdHora[0];
                              A422ExecutanteTipoHoraId = P008810_A422ExecutanteTipoHoraId[0];
                              n422ExecutanteTipoHoraId = P008810_n422ExecutanteTipoHoraId[0];
                              A131GestaoServicoExecutanteId = P008810_A131GestaoServicoExecutanteId[0];
                              A423ExecutanteTipoHoraDescricao = P008810_A423ExecutanteTipoHoraDescricao[0];
                              AV79FuncaoTipoHoraDescricao = A423ExecutanteTipoHoraDescricao;
                              AV81QtdHoras = A424GestaoServicoExecutanteQtdHora;
                              AV85ExecutanteTipoHoraId = A422ExecutanteTipoHoraId;
                              /* Using cursor P008811 */
                              pr_default.execute(9, new Object[] {AV62UsuarioFuncaoId, AV85ExecutanteTipoHoraId});
                              while ( (pr_default.getStatus(9) != 101) )
                              {
                                 A341FuncaoTipoHHId = P008811_A341FuncaoTipoHHId[0];
                                 A163FuncaoId = P008811_A163FuncaoId[0];
                                 A338FuncaoTipoHoraValor = P008811_A338FuncaoTipoHoraValor[0];
                                 AV80FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(9);
                              H880( false, 18) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80FuncaoTipoHoraValorDescricao, "")), 442, Gx_line+0, 709, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79FuncaoTipoHoraDescricao, "")), 25, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 200, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(283, Gx_line+0, 583, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(433, Gx_line+0, 533, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV81QtdHoras), "ZZZ9")), 292, Gx_line+0, 384, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+18);
                              pr_default.readNext(8);
                           }
                           pr_default.close(8);
                        }
                        AV101GXV3 = (int)(AV101GXV3+1);
                     }
                  }
               }
            }
            if ( AV83Tela == 1 )
            {
               H880( false, 68) ;
               getPrinter().GxDrawRect(575, Gx_line+50, 667, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(392, Gx_line+50, 417, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+50, 275, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(117, Gx_line+50, 167, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 675, Gx_line+50, 733, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 25, Gx_line+50, 133, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 425, Gx_line+50, 558, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término", ""), 283, Gx_line+50, 408, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Início", ""), 175, Gx_line+50, 233, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "ATIVIDADES", ""), 250, Gx_line+33, 508, Gx_line+51, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
               AV106GXLvl129 = 0;
               /* Using cursor P008812 */
               pr_default.execute(10, new Object[] {AV29GestaoServicoId});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A133OrdemExecutanteUsuarioId = P008812_A133OrdemExecutanteUsuarioId[0];
                  A145OrdemGestaoServicoId = P008812_A145OrdemGestaoServicoId[0];
                  A134OrdemExecutanteUsuarioNome = P008812_A134OrdemExecutanteUsuarioNome[0];
                  A137OrdemExecutanteHrInicio = P008812_A137OrdemExecutanteHrInicio[0];
                  A136OrdemExecutanteDtInicio = P008812_A136OrdemExecutanteDtInicio[0];
                  A139OrdemExecutanteHrConclusao = P008812_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P008812_A140OrdemExecutanteComentario[0];
                  A142OrdemExecutanteValor = P008812_A142OrdemExecutanteValor[0];
                  A135OrdemExecutanteId = P008812_A135OrdemExecutanteId[0];
                  A134OrdemExecutanteUsuarioNome = P008812_A134OrdemExecutanteUsuarioNome[0];
                  AV106GXLvl129 = 1;
                  AV45ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                  AV76Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                  AV77Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                  AV21GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                  if ( AV40PerfilUsuario != 4 )
                  {
                     AV36GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                  }
                  H880( false, 17) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(617, Gx_line+0, 667, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 425, Gx_line+0, 650, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 675, Gx_line+0, 767, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  pr_default.readNext(10);
               }
               pr_default.close(10);
               if ( AV106GXLvl129 == 0 )
               {
                  /* Using cursor P008813 */
                  pr_default.execute(11, new Object[] {AV29GestaoServicoId});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A55ServicoExecutanteId = P008813_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P008813_n55ServicoExecutanteId[0];
                     A38GestaoServicoId = P008813_A38GestaoServicoId[0];
                     A56ServicoExecutanteNome = P008813_A56ServicoExecutanteNome[0];
                     A131GestaoServicoExecutanteId = P008813_A131GestaoServicoExecutanteId[0];
                     A56ServicoExecutanteNome = P008813_A56ServicoExecutanteNome[0];
                     AV45ServicoExecutanteNome = A56ServicoExecutanteNome;
                     H880( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(617, Gx_line+0, 667, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 425, Gx_line+0, 650, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 675, Gx_line+0, 767, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(11);
                  }
                  pr_default.close(11);
               }
            }
            if ( AV82GestaoServicoTipoHH == 2 )
            {
               AV84MsgVarChar = context.GetMessage( "OBS: A ordem de serviço está marcada como HH por DEMANDA. O orçamento completo será exibido no final da OS.", "");
            }
            H880( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84MsgVarChar, "")), 17, Gx_line+17, 775, Gx_line+35, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            H880( false, 272) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 500, Gx_line+183, 635, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 183, Gx_line+183, 287, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(450, Gx_line+167, 700, Gx_line+167, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(117, Gx_line+167, 367, Gx_line+167, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+272);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H880( true, 0) ;
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

      protected void H880( bool bFoot ,
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
         AV89SDTContexto = new SdtSDTContexto(context);
         AV90WebSession = context.GetSession();
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P00882_A36ServicoSetorId = new long[1] ;
         P00882_A38GestaoServicoId = new long[1] ;
         P00882_A77ServicoEmpresaId = new long[1] ;
         P00882_A79GestaoServicoNumero = new long[1] ;
         P00882_A40GestaoServicoDescricao = new string[] {""} ;
         P00882_A35ServicoClienteNome = new string[] {""} ;
         P00882_A37ServicoSetorNome = new string[] {""} ;
         P00882_A54ServicoNaturezaNome = new string[] {""} ;
         P00882_A41GestaoServicoPrioridade = new short[1] ;
         P00882_A42GestaoServicoStatus = new short[1] ;
         P00882_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00882_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00882_A157GestaoServicoPrecificacao = new short[1] ;
         P00882_A53ServicoNaturezaId = new long[1] ;
         P00882_n53ServicoNaturezaId = new bool[] {false} ;
         P00882_A129EnderecoId = new long[1] ;
         P00882_n129EnderecoId = new bool[] {false} ;
         P00882_A34ServicoClienteId = new long[1] ;
         P00882_A322GestaoServicoTipoDemanda = new short[1] ;
         P00882_A420GestaoServicoTipoHH = new short[1] ;
         P00882_n420GestaoServicoTipoHH = new bool[] {false} ;
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
         AV66TipoDemandaVarChar = "";
         P00883_A106ClienteEnderecoId = new long[1] ;
         P00883_A17ClienteId = new long[1] ;
         P00883_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV20EnderecoLocal = "";
         P00884_A1EmpresaId = new long[1] ;
         P00884_A2EmpresaNome = new string[] {""} ;
         P00884_A3EmpresaCNPJ = new string[] {""} ;
         P00884_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV95Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         P00885_A38GestaoServicoId = new long[1] ;
         P00885_A326TipoServicoNome = new string[] {""} ;
         P00885_A329TipoServicoEstimado = new short[1] ;
         P00885_A325TipoServicoId = new long[1] ;
         P00885_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV67TempoEstimado = "";
         AV91TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV68TerminoDate = DateTime.MinValue;
         AV78ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00886_A25NaturezaId = new long[1] ;
         P00886_A26NaturezaNome = new string[] {""} ;
         P00886_A162NaturezaValor = new decimal[1] ;
         P00886_A289NaturezaCusto = new decimal[1] ;
         A26NaturezaNome = "";
         AV70TipoServicoNome = "";
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         AV87GestaoServicoIdVarChar = "";
         P00887_A38GestaoServicoId = new long[1] ;
         P00887_A55ServicoExecutanteId = new long[1] ;
         P00887_n55ServicoExecutanteId = new bool[] {false} ;
         P00887_A131GestaoServicoExecutanteId = new long[1] ;
         AV44ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         AV86ServicoExecutanteIdVarChar = "";
         P00888_A9UsuarioId = new long[1] ;
         P00888_A173UsuarioFuncaoId = new long[1] ;
         P00888_n173UsuarioFuncaoId = new bool[] {false} ;
         P00888_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV73TecnicoNome = "";
         P00889_A341FuncaoTipoHHId = new long[1] ;
         P00889_A163FuncaoId = new long[1] ;
         P00889_A343FuncaoTipoHHDescricao = new string[] {""} ;
         P00889_A338FuncaoTipoHoraValor = new decimal[1] ;
         A343FuncaoTipoHHDescricao = "";
         AV79FuncaoTipoHoraDescricao = "";
         AV80FuncaoTipoHoraValorDescricao = "";
         P008810_A55ServicoExecutanteId = new long[1] ;
         P008810_n55ServicoExecutanteId = new bool[] {false} ;
         P008810_A38GestaoServicoId = new long[1] ;
         P008810_A423ExecutanteTipoHoraDescricao = new string[] {""} ;
         P008810_A424GestaoServicoExecutanteQtdHora = new short[1] ;
         P008810_A422ExecutanteTipoHoraId = new long[1] ;
         P008810_n422ExecutanteTipoHoraId = new bool[] {false} ;
         P008810_A131GestaoServicoExecutanteId = new long[1] ;
         A423ExecutanteTipoHoraDescricao = "";
         P008811_A341FuncaoTipoHHId = new long[1] ;
         P008811_A163FuncaoId = new long[1] ;
         P008811_A338FuncaoTipoHoraValor = new decimal[1] ;
         P008812_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008812_A145OrdemGestaoServicoId = new long[1] ;
         P008812_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008812_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008812_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008812_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008812_A140OrdemExecutanteComentario = new string[] {""} ;
         P008812_A142OrdemExecutanteValor = new decimal[1] ;
         P008812_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV45ServicoExecutanteNome = "";
         AV76Inicio = "";
         AV77Termino = "";
         AV21GestaoServicoComentario = "";
         AV36GestaoServicoValor = "";
         P008813_A55ServicoExecutanteId = new long[1] ;
         P008813_n55ServicoExecutanteId = new bool[] {false} ;
         P008813_A38GestaoServicoId = new long[1] ;
         P008813_A56ServicoExecutanteNome = new string[] {""} ;
         P008813_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV84MsgVarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcimpressaoosmodelo2__default(),
            new Object[][] {
                new Object[] {
               P00882_A36ServicoSetorId, P00882_A38GestaoServicoId, P00882_A77ServicoEmpresaId, P00882_A79GestaoServicoNumero, P00882_A40GestaoServicoDescricao, P00882_A35ServicoClienteNome, P00882_A37ServicoSetorNome, P00882_A54ServicoNaturezaNome, P00882_A41GestaoServicoPrioridade, P00882_A42GestaoServicoStatus,
               P00882_A43GestaoServicoDtProgramada, P00882_A39GestaoServicoDtHora, P00882_A157GestaoServicoPrecificacao, P00882_A53ServicoNaturezaId, P00882_n53ServicoNaturezaId, P00882_A129EnderecoId, P00882_n129EnderecoId, P00882_A34ServicoClienteId, P00882_A322GestaoServicoTipoDemanda, P00882_A420GestaoServicoTipoHH,
               P00882_n420GestaoServicoTipoHH
               }
               , new Object[] {
               P00883_A106ClienteEnderecoId, P00883_A17ClienteId, P00883_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00884_A1EmpresaId, P00884_A2EmpresaNome, P00884_A3EmpresaCNPJ, P00884_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00885_A38GestaoServicoId, P00885_A326TipoServicoNome, P00885_A329TipoServicoEstimado, P00885_A325TipoServicoId, P00885_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00886_A25NaturezaId, P00886_A26NaturezaNome, P00886_A162NaturezaValor, P00886_A289NaturezaCusto
               }
               , new Object[] {
               P00887_A38GestaoServicoId, P00887_A55ServicoExecutanteId, P00887_n55ServicoExecutanteId, P00887_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00888_A9UsuarioId, P00888_A173UsuarioFuncaoId, P00888_n173UsuarioFuncaoId, P00888_A10UsuarioNome
               }
               , new Object[] {
               P00889_A341FuncaoTipoHHId, P00889_A163FuncaoId, P00889_A343FuncaoTipoHHDescricao, P00889_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008810_A55ServicoExecutanteId, P008810_n55ServicoExecutanteId, P008810_A38GestaoServicoId, P008810_A423ExecutanteTipoHoraDescricao, P008810_A424GestaoServicoExecutanteQtdHora, P008810_A422ExecutanteTipoHoraId, P008810_n422ExecutanteTipoHoraId, P008810_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008811_A341FuncaoTipoHHId, P008811_A163FuncaoId, P008811_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008812_A133OrdemExecutanteUsuarioId, P008812_A145OrdemGestaoServicoId, P008812_A134OrdemExecutanteUsuarioNome, P008812_A137OrdemExecutanteHrInicio, P008812_A136OrdemExecutanteDtInicio, P008812_A139OrdemExecutanteHrConclusao, P008812_A140OrdemExecutanteComentario, P008812_A142OrdemExecutanteValor, P008812_A135OrdemExecutanteId
               }
               , new Object[] {
               P008813_A55ServicoExecutanteId, P008813_n55ServicoExecutanteId, P008813_A38GestaoServicoId, P008813_A56ServicoExecutanteNome, P008813_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV83Tela ;
      private short GxWebError ;
      private short AV40PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV32GestaoServicoPrecificacao ;
      private short AV35GestaoServicoStatus ;
      private short AV82GestaoServicoTipoHH ;
      private short A329TipoServicoEstimado ;
      private short AV81QtdHoras ;
      private short A424GestaoServicoExecutanteQtdHora ;
      private short AV106GXLvl129 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV97GXV1 ;
      private int AV100GXV2 ;
      private int AV101GXV3 ;
      private long AV29GestaoServicoId ;
      private long AV54UsuarioId ;
      private long AV65EmpresaId ;
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
      private long AV75ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV62UsuarioFuncaoId ;
      private long A341FuncaoTipoHHId ;
      private long A163FuncaoId ;
      private long A422ExecutanteTipoHoraId ;
      private long AV85ExecutanteTipoHoraId ;
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
      private string A326TipoServicoNome ;
      private string A26NaturezaNome ;
      private string AV70TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV73TecnicoNome ;
      private string A343FuncaoTipoHHDescricao ;
      private string AV79FuncaoTipoHoraDescricao ;
      private string A423ExecutanteTipoHoraDescricao ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV45ServicoExecutanteNome ;
      private string AV76Inicio ;
      private string AV77Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV13DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV91TerminoDateTime ;
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
      private bool AV88IsExiste ;
      private bool n173UsuarioFuncaoId ;
      private bool n422ExecutanteTipoHoraId ;
      private string A40GestaoServicoDescricao ;
      private string AV24GestaoServicoDescricao ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV66TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV95Empresafoto_GXI ;
      private string AV67TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV87GestaoServicoIdVarChar ;
      private string AV86ServicoExecutanteIdVarChar ;
      private string AV80FuncaoTipoHoraValorDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV21GestaoServicoComentario ;
      private string AV36GestaoServicoValor ;
      private string AV84MsgVarChar ;
      private string AV16EmpresaFoto ;
      private IGxSession AV90WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV89SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00882_A36ServicoSetorId ;
      private long[] P00882_A38GestaoServicoId ;
      private long[] P00882_A77ServicoEmpresaId ;
      private long[] P00882_A79GestaoServicoNumero ;
      private string[] P00882_A40GestaoServicoDescricao ;
      private string[] P00882_A35ServicoClienteNome ;
      private string[] P00882_A37ServicoSetorNome ;
      private string[] P00882_A54ServicoNaturezaNome ;
      private short[] P00882_A41GestaoServicoPrioridade ;
      private short[] P00882_A42GestaoServicoStatus ;
      private DateTime[] P00882_A43GestaoServicoDtProgramada ;
      private DateTime[] P00882_A39GestaoServicoDtHora ;
      private short[] P00882_A157GestaoServicoPrecificacao ;
      private long[] P00882_A53ServicoNaturezaId ;
      private bool[] P00882_n53ServicoNaturezaId ;
      private long[] P00882_A129EnderecoId ;
      private bool[] P00882_n129EnderecoId ;
      private long[] P00882_A34ServicoClienteId ;
      private short[] P00882_A322GestaoServicoTipoDemanda ;
      private short[] P00882_A420GestaoServicoTipoHH ;
      private bool[] P00882_n420GestaoServicoTipoHH ;
      private long[] P00883_A106ClienteEnderecoId ;
      private long[] P00883_A17ClienteId ;
      private string[] P00883_A107ClienteEnderecoLocal ;
      private long[] P00884_A1EmpresaId ;
      private string[] P00884_A2EmpresaNome ;
      private string[] P00884_A3EmpresaCNPJ ;
      private string[] P00884_A40000EmpresaFoto_GXI ;
      private long[] P00885_A38GestaoServicoId ;
      private string[] P00885_A326TipoServicoNome ;
      private short[] P00885_A329TipoServicoEstimado ;
      private long[] P00885_A325TipoServicoId ;
      private long[] P00885_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV78ServicoNaturezaIdCollection ;
      private long[] P00886_A25NaturezaId ;
      private string[] P00886_A26NaturezaNome ;
      private decimal[] P00886_A162NaturezaValor ;
      private decimal[] P00886_A289NaturezaCusto ;
      private long[] P00887_A38GestaoServicoId ;
      private long[] P00887_A55ServicoExecutanteId ;
      private bool[] P00887_n55ServicoExecutanteId ;
      private long[] P00887_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV44ServicoExecutanteIdCollection ;
      private long[] P00888_A9UsuarioId ;
      private long[] P00888_A173UsuarioFuncaoId ;
      private bool[] P00888_n173UsuarioFuncaoId ;
      private string[] P00888_A10UsuarioNome ;
      private long[] P00889_A341FuncaoTipoHHId ;
      private long[] P00889_A163FuncaoId ;
      private string[] P00889_A343FuncaoTipoHHDescricao ;
      private decimal[] P00889_A338FuncaoTipoHoraValor ;
      private long[] P008810_A55ServicoExecutanteId ;
      private bool[] P008810_n55ServicoExecutanteId ;
      private long[] P008810_A38GestaoServicoId ;
      private string[] P008810_A423ExecutanteTipoHoraDescricao ;
      private short[] P008810_A424GestaoServicoExecutanteQtdHora ;
      private long[] P008810_A422ExecutanteTipoHoraId ;
      private bool[] P008810_n422ExecutanteTipoHoraId ;
      private long[] P008810_A131GestaoServicoExecutanteId ;
      private long[] P008811_A341FuncaoTipoHHId ;
      private long[] P008811_A163FuncaoId ;
      private decimal[] P008811_A338FuncaoTipoHoraValor ;
      private long[] P008812_A133OrdemExecutanteUsuarioId ;
      private long[] P008812_A145OrdemGestaoServicoId ;
      private string[] P008812_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008812_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008812_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008812_A139OrdemExecutanteHrConclusao ;
      private string[] P008812_A140OrdemExecutanteComentario ;
      private decimal[] P008812_A142OrdemExecutanteValor ;
      private long[] P008812_A135OrdemExecutanteId ;
      private long[] P008813_A55ServicoExecutanteId ;
      private bool[] P008813_n55ServicoExecutanteId ;
      private long[] P008813_A38GestaoServicoId ;
      private string[] P008813_A56ServicoExecutanteNome ;
      private long[] P008813_A131GestaoServicoExecutanteId ;
   }

   public class aprcimpressaoosmodelo2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00882;
          prmP00882 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00883;
          prmP00883 = new Object[] {
          new ParDef("@AV41ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00884;
          prmP00884 = new Object[] {
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00885;
          prmP00885 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00886;
          prmP00886 = new Object[] {
          new ParDef("@AV46ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00887;
          prmP00887 = new Object[] {
          new ParDef("@AV87GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP00888;
          prmP00888 = new Object[] {
          new ParDef("@AV75ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00889;
          prmP00889 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008810;
          prmP008810 = new Object[] {
          new ParDef("@AV87GestaoServicoIdVarChar",GXType.VarChar,40,0) ,
          new ParDef("@AV86ServicoExecutanteIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP008811;
          prmP008811 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV85ExecutanteTipoHoraId",GXType.Decimal,18,0)
          };
          Object[] prmP008812;
          prmP008812 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008813;
          prmP008813 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00882", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00882,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00883", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV41ServicoClienteId and [ClienteEnderecoId] = @AV19EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00883,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00884", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV43ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00884,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00885", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00885,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00886", "SELECT [NaturezaId], [NaturezaNome], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV46ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00886,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00887", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV87GestaoServicoIdVarChar) ORDER BY [GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00887,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00888", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV75ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00888,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00889", "SELECT T1.[FuncaoTipoHHId] AS FuncaoTipoHHId, T1.[FuncaoId], T2.[TipoHoraDescricao] AS FuncaoTipoHHDescricao, T1.[FuncaoTipoHoraValor] FROM ([FuncaoTipoHora] T1 INNER JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[FuncaoTipoHHId]) WHERE T1.[FuncaoId] = @AV62UsuarioFuncaoId ORDER BY T1.[FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00889,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008810", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[TipoHoraDescricao] AS ExecutanteTipoHoraDescricao, T1.[GestaoServicoExecutanteQtdHora], T1.[ExecutanteTipoHoraId] AS ExecutanteTipoHoraId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[ExecutanteTipoHoraId]) WHERE (T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV87GestaoServicoIdVarChar)) AND (T1.[ServicoExecutanteId] = CONVERT( DECIMAL(28,14), @AV86ServicoExecutanteIdVarChar)) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008810,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008811", "SELECT [FuncaoTipoHHId] AS FuncaoTipoHHId, [FuncaoId], [FuncaoTipoHoraValor] FROM [FuncaoTipoHora] WHERE [FuncaoId] = @AV62UsuarioFuncaoId and [FuncaoTipoHHId] = @AV85ExecutanteTipoHoraId ORDER BY [FuncaoId], [FuncaoTipoHHId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008811,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008812", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008812,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008813", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008813,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
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
