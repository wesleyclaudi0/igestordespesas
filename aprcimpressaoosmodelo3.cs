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
   public class aprcimpressaoosmodelo3 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV85Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcimpressaoosmodelo3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcimpressaoosmodelo3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           short aP1_Tela )
      {
         this.AV39GestaoServicoId = aP0_GestaoServicoId;
         this.AV85Tela = aP1_Tela;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_Tela )
      {
         this.AV39GestaoServicoId = aP0_GestaoServicoId;
         this.AV85Tela = aP1_Tela;
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
         setOutputFileName("ImpressaoM3.pdf");
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
            AV56SDTContexto.FromJSonString(AV75WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV74UsuarioId = AV56SDTContexto.gxTpr_Usuarioid;
            AV21EmpresaId = AV56SDTContexto.gxTpr_Empresaid;
            AV55PerfilUsuario = AV56SDTContexto.gxTpr_Usuarioperfil;
            AV16DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00892 */
            pr_default.execute(0, new Object[] {AV39GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00892_A36ServicoSetorId[0];
               A38GestaoServicoId = P00892_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00892_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00892_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00892_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00892_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00892_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00892_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00892_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00892_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00892_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00892_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00892_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00892_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00892_n53ServicoNaturezaId[0];
               A129EnderecoId = P00892_A129EnderecoId[0];
               n129EnderecoId = P00892_n129EnderecoId[0];
               A34ServicoClienteId = P00892_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00892_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P00892_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P00892_n420GestaoServicoTipoHH[0];
               A37ServicoSetorNome = P00892_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00892_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00892_A35ServicoClienteNome[0];
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
               AV45GestaoServicoStatus = A42GestaoServicoStatus;
               AV83GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00893 */
            pr_default.execute(1, new Object[] {AV57ServicoClienteId, AV23EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00893_A106ClienteEnderecoId[0];
               A17ClienteId = P00893_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00893_A107ClienteEnderecoLocal[0];
               AV24EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00894 */
            pr_default.execute(2, new Object[] {AV59ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P00894_A1EmpresaId[0];
               A2EmpresaNome = P00894_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00894_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00894_A40000EmpresaFoto_GXI[0];
               AV17Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV22EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV18EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV20EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV71Url = StringUtil.StringReplace( AV20EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV95Empresafoto_GXI = AV71Url;
               AV19EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H890( false, 235) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Descricao, "")), 250, Gx_line+17, 475, Gx_line+50, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19EmpresaFoto)) ? AV95Empresafoto_GXI : AV19EmpresaFoto);
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
            /* Using cursor P00895 */
            pr_default.execute(3, new Object[] {AV39GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P00895_A38GestaoServicoId[0];
               A326TipoServicoNome = P00895_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00895_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00895_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00895_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00895_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00895_A329TipoServicoEstimado[0];
               AV63ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV67TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
               AV91TerminoDateTime = DateTimeUtil.ResetTime( AV36GestaoServicoDtProgramada ) ;
               AV68TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV91TerminoDateTime, 3600*(A329TipoServicoEstimado)));
               AV80ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H890( false, 18) ;
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
            if ( AV55PerfilUsuario != 4 )
            {
               if ( AV42GestaoServicoPrecificacao == 2 )
               {
                  AV97GXV1 = 1;
                  while ( AV97GXV1 <= AV80ServicoNaturezaIdCollection.Count )
                  {
                     AV62ServicoNaturezaId = (long)(AV80ServicoNaturezaIdCollection.GetNumeric(AV97GXV1));
                     /* Using cursor P00896 */
                     pr_default.execute(4, new Object[] {AV62ServicoNaturezaId});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A25NaturezaId = P00896_A25NaturezaId[0];
                        A162NaturezaValor = P00896_A162NaturezaValor[0];
                        A289NaturezaCusto = P00896_A289NaturezaCusto[0];
                        AV52NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                        AV51NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                        AV69Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                        AV70TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV69Total, 18, 2));
                        H890( false, 17) ;
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
                     AV97GXV1 = (int)(AV97GXV1+1);
                  }
                  H890( false, 33) ;
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
                  AV87GestaoServicoIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GestaoServicoId), 18, 0));
                  if ( AV42GestaoServicoPrecificacao == 1 )
                  {
                     /* Using cursor P00897 */
                     pr_default.execute(5, new Object[] {AV87GestaoServicoIdVarChar});
                     while ( (pr_default.getStatus(5) != 101) )
                     {
                        A38GestaoServicoId = P00897_A38GestaoServicoId[0];
                        A55ServicoExecutanteId = P00897_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P00897_n55ServicoExecutanteId[0];
                        A131GestaoServicoExecutanteId = P00897_A131GestaoServicoExecutanteId[0];
                        AV100GXV2 = 1;
                        while ( AV100GXV2 <= AV60ServicoExecutanteIdCollection.Count )
                        {
                           AV77ServicoExecutanteId = (long)(AV60ServicoExecutanteIdCollection.GetNumeric(AV100GXV2));
                           if ( AV77ServicoExecutanteId == A55ServicoExecutanteId )
                           {
                              AV89IsExiste = true;
                           }
                           else
                           {
                              AV89IsExiste = false;
                           }
                           AV100GXV2 = (int)(AV100GXV2+1);
                        }
                        if ( ! AV89IsExiste )
                        {
                           AV60ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                        }
                        pr_default.readNext(5);
                     }
                     pr_default.close(5);
                     AV101GXV3 = 1;
                     while ( AV101GXV3 <= AV60ServicoExecutanteIdCollection.Count )
                     {
                        AV77ServicoExecutanteId = (long)(AV60ServicoExecutanteIdCollection.GetNumeric(AV101GXV3));
                        AV88ServicoExecutanteIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV77ServicoExecutanteId), 18, 0));
                        /* Using cursor P00898 */
                        pr_default.execute(6, new Object[] {AV77ServicoExecutanteId});
                        while ( (pr_default.getStatus(6) != 101) )
                        {
                           A9UsuarioId = P00898_A9UsuarioId[0];
                           A173UsuarioFuncaoId = P00898_A173UsuarioFuncaoId[0];
                           n173UsuarioFuncaoId = P00898_n173UsuarioFuncaoId[0];
                           A10UsuarioNome = P00898_A10UsuarioNome[0];
                           AV73UsuarioFuncaoId = A173UsuarioFuncaoId;
                           AV8TecnicoNome = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(6);
                        H890( false, 68) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+50, 734, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo de Hora", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(200, Gx_line+50, 300, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor por Hora", ""), 358, Gx_line+50, 525, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8TecnicoNome, "")), 133, Gx_line+17, 572, Gx_line+35, 1+256, 0, 0, 0) ;
                        getPrinter().GxDrawRect(350, Gx_line+50, 450, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Qtd de Horas", ""), 208, Gx_line+50, 375, Gx_line+68, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+68);
                        if ( AV83GestaoServicoTipoHH == 2 )
                        {
                           /* Using cursor P00899 */
                           pr_default.execute(7, new Object[] {AV73UsuarioFuncaoId});
                           while ( (pr_default.getStatus(7) != 101) )
                           {
                              A341FuncaoTipoHHId = P00899_A341FuncaoTipoHHId[0];
                              A163FuncaoId = P00899_A163FuncaoId[0];
                              A343FuncaoTipoHHDescricao = P00899_A343FuncaoTipoHHDescricao[0];
                              A338FuncaoTipoHoraValor = P00899_A338FuncaoTipoHoraValor[0];
                              A343FuncaoTipoHHDescricao = P00899_A343FuncaoTipoHHDescricao[0];
                              AV81FuncaoTipoHoraDescricao = A343FuncaoTipoHHDescricao;
                              AV82FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                              H890( false, 18) ;
                              getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81FuncaoTipoHoraDescricao, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82FuncaoTipoHoraValorDescricao, "")), 358, Gx_line+0, 566, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(350, Gx_line+0, 450, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV84QtdHoras), "ZZZ9")), 208, Gx_line+0, 416, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+18);
                              pr_default.readNext(7);
                           }
                           pr_default.close(7);
                        }
                        else
                        {
                           /* Using cursor P008910 */
                           pr_default.execute(8, new Object[] {AV87GestaoServicoIdVarChar, AV88ServicoExecutanteIdVarChar});
                           while ( (pr_default.getStatus(8) != 101) )
                           {
                              A55ServicoExecutanteId = P008910_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008910_n55ServicoExecutanteId[0];
                              A38GestaoServicoId = P008910_A38GestaoServicoId[0];
                              A423ExecutanteTipoHoraDescricao = P008910_A423ExecutanteTipoHoraDescricao[0];
                              A424GestaoServicoExecutanteQtdHora = P008910_A424GestaoServicoExecutanteQtdHora[0];
                              A422ExecutanteTipoHoraId = P008910_A422ExecutanteTipoHoraId[0];
                              n422ExecutanteTipoHoraId = P008910_n422ExecutanteTipoHoraId[0];
                              A131GestaoServicoExecutanteId = P008910_A131GestaoServicoExecutanteId[0];
                              A423ExecutanteTipoHoraDescricao = P008910_A423ExecutanteTipoHoraDescricao[0];
                              AV81FuncaoTipoHoraDescricao = A423ExecutanteTipoHoraDescricao;
                              AV84QtdHoras = A424GestaoServicoExecutanteQtdHora;
                              AV90ExecutanteTipoHoraId = A422ExecutanteTipoHoraId;
                              /* Using cursor P008911 */
                              pr_default.execute(9, new Object[] {AV73UsuarioFuncaoId, AV90ExecutanteTipoHoraId});
                              while ( (pr_default.getStatus(9) != 101) )
                              {
                                 A341FuncaoTipoHHId = P008911_A341FuncaoTipoHHId[0];
                                 A163FuncaoId = P008911_A163FuncaoId[0];
                                 A338FuncaoTipoHoraValor = P008911_A338FuncaoTipoHoraValor[0];
                                 AV82FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(9);
                              H890( false, 18) ;
                              getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81FuncaoTipoHoraDescricao, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82FuncaoTipoHoraValorDescricao, "")), 358, Gx_line+0, 566, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(350, Gx_line+0, 450, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV84QtdHoras), "ZZZ9")), 208, Gx_line+0, 416, Gx_line+17, 0, 0, 0, 0) ;
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
            if ( AV85Tela == 1 )
            {
               H890( false, 68) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "ATIVIDADES", ""), 250, Gx_line+17, 508, Gx_line+35, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Início", ""), 175, Gx_line+50, 233, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término", ""), 283, Gx_line+50, 408, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 425, Gx_line+50, 558, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 25, Gx_line+50, 133, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 658, Gx_line+50, 716, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+50, 734, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(117, Gx_line+50, 167, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+50, 275, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(392, Gx_line+50, 417, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(608, Gx_line+50, 650, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
               AV106GXLvl124 = 0;
               /* Using cursor P008912 */
               pr_default.execute(10, new Object[] {AV39GestaoServicoId});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A133OrdemExecutanteUsuarioId = P008912_A133OrdemExecutanteUsuarioId[0];
                  A145OrdemGestaoServicoId = P008912_A145OrdemGestaoServicoId[0];
                  A134OrdemExecutanteUsuarioNome = P008912_A134OrdemExecutanteUsuarioNome[0];
                  A137OrdemExecutanteHrInicio = P008912_A137OrdemExecutanteHrInicio[0];
                  A136OrdemExecutanteDtInicio = P008912_A136OrdemExecutanteDtInicio[0];
                  A139OrdemExecutanteHrConclusao = P008912_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P008912_A140OrdemExecutanteComentario[0];
                  A142OrdemExecutanteValor = P008912_A142OrdemExecutanteValor[0];
                  A135OrdemExecutanteId = P008912_A135OrdemExecutanteId[0];
                  A134OrdemExecutanteUsuarioNome = P008912_A134OrdemExecutanteUsuarioNome[0];
                  AV106GXLvl124 = 1;
                  AV61ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                  AV78Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                  AV79Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                  AV31GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                  if ( AV55PerfilUsuario != 4 )
                  {
                     AV46GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                  }
                  H890( false, 17) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46GestaoServicoValor, "")), 658, Gx_line+0, 725, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31GestaoServicoComentario, "")), 425, Gx_line+0, 642, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(600, Gx_line+0, 650, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61ServicoExecutanteNome, "")), 25, Gx_line+0, 158, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  pr_default.readNext(10);
               }
               pr_default.close(10);
               if ( AV106GXLvl124 == 0 )
               {
                  /* Using cursor P008913 */
                  pr_default.execute(11, new Object[] {AV87GestaoServicoIdVarChar});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A55ServicoExecutanteId = P008913_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P008913_n55ServicoExecutanteId[0];
                     A38GestaoServicoId = P008913_A38GestaoServicoId[0];
                     A56ServicoExecutanteNome = P008913_A56ServicoExecutanteNome[0];
                     A131GestaoServicoExecutanteId = P008913_A131GestaoServicoExecutanteId[0];
                     A56ServicoExecutanteNome = P008913_A56ServicoExecutanteNome[0];
                     AV61ServicoExecutanteNome = A56ServicoExecutanteNome;
                     H890( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46GestaoServicoValor, "")), 658, Gx_line+0, 725, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31GestaoServicoComentario, "")), 425, Gx_line+0, 642, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(600, Gx_line+0, 650, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61ServicoExecutanteNome, "")), 25, Gx_line+0, 158, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(11);
                  }
                  pr_default.close(11);
               }
            }
            if ( AV83GestaoServicoTipoHH == 2 )
            {
               AV86MsgVarChar = context.GetMessage( "OBS: A ordem de serviço está marcada como HH por DEMANDA. O orçamento completo será exibido no final da OS.", "");
            }
            H890( false, 35) ;
            getPrinter().GxDrawLine(17, Gx_line+0, 734, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86MsgVarChar, "")), 17, Gx_line+17, 742, Gx_line+35, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            H890( false, 214) ;
            getPrinter().GxDrawLine(92, Gx_line+133, 342, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(425, Gx_line+133, 675, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 158, Gx_line+150, 262, Gx_line+164, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 475, Gx_line+150, 610, Gx_line+164, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+214);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H890( true, 0) ;
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

      protected void H890( bool bFoot ,
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
         AV56SDTContexto = new SdtSDTContexto(context);
         AV75WebSession = context.GetSession();
         AV16DateTime = (DateTime)(DateTime.MinValue);
         P00892_A36ServicoSetorId = new long[1] ;
         P00892_A38GestaoServicoId = new long[1] ;
         P00892_A77ServicoEmpresaId = new long[1] ;
         P00892_A79GestaoServicoNumero = new long[1] ;
         P00892_A40GestaoServicoDescricao = new string[] {""} ;
         P00892_A35ServicoClienteNome = new string[] {""} ;
         P00892_A37ServicoSetorNome = new string[] {""} ;
         P00892_A54ServicoNaturezaNome = new string[] {""} ;
         P00892_A41GestaoServicoPrioridade = new short[1] ;
         P00892_A42GestaoServicoStatus = new short[1] ;
         P00892_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00892_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00892_A157GestaoServicoPrecificacao = new short[1] ;
         P00892_A53ServicoNaturezaId = new long[1] ;
         P00892_n53ServicoNaturezaId = new bool[] {false} ;
         P00892_A129EnderecoId = new long[1] ;
         P00892_n129EnderecoId = new bool[] {false} ;
         P00892_A34ServicoClienteId = new long[1] ;
         P00892_A322GestaoServicoTipoDemanda = new short[1] ;
         P00892_A420GestaoServicoTipoHH = new short[1] ;
         P00892_n420GestaoServicoTipoHH = new bool[] {false} ;
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
         P00893_A106ClienteEnderecoId = new long[1] ;
         P00893_A17ClienteId = new long[1] ;
         P00893_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV24EnderecoLocal = "";
         P00894_A1EmpresaId = new long[1] ;
         P00894_A2EmpresaNome = new string[] {""} ;
         P00894_A3EmpresaCNPJ = new string[] {""} ;
         P00894_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV17Descricao = "";
         AV22EmpresaNome = "";
         AV18EmpresaCNPJ = "";
         AV20EmpresaFotoUrl = "";
         AV71Url = "";
         AV95Empresafoto_GXI = "";
         AV19EmpresaFoto = "";
         AV19EmpresaFoto = "";
         sImgUrl = "";
         P00895_A38GestaoServicoId = new long[1] ;
         P00895_A326TipoServicoNome = new string[] {""} ;
         P00895_A329TipoServicoEstimado = new short[1] ;
         P00895_A325TipoServicoId = new long[1] ;
         P00895_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV67TempoEstimado = "";
         AV91TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV68TerminoDate = DateTime.MinValue;
         AV80ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00896_A25NaturezaId = new long[1] ;
         P00896_A162NaturezaValor = new decimal[1] ;
         P00896_A289NaturezaCusto = new decimal[1] ;
         AV52NaturezaValorVarChar = "";
         AV51NaturezaCustoVarChar = "";
         AV70TotalVarChar = "";
         AV10TipoServicoNome = "";
         AV87GestaoServicoIdVarChar = "";
         P00897_A38GestaoServicoId = new long[1] ;
         P00897_A55ServicoExecutanteId = new long[1] ;
         P00897_n55ServicoExecutanteId = new bool[] {false} ;
         P00897_A131GestaoServicoExecutanteId = new long[1] ;
         AV60ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         AV88ServicoExecutanteIdVarChar = "";
         P00898_A9UsuarioId = new long[1] ;
         P00898_A173UsuarioFuncaoId = new long[1] ;
         P00898_n173UsuarioFuncaoId = new bool[] {false} ;
         P00898_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV8TecnicoNome = "";
         P00899_A341FuncaoTipoHHId = new long[1] ;
         P00899_A163FuncaoId = new long[1] ;
         P00899_A343FuncaoTipoHHDescricao = new string[] {""} ;
         P00899_A338FuncaoTipoHoraValor = new decimal[1] ;
         A343FuncaoTipoHHDescricao = "";
         AV81FuncaoTipoHoraDescricao = "";
         AV82FuncaoTipoHoraValorDescricao = "";
         P008910_A55ServicoExecutanteId = new long[1] ;
         P008910_n55ServicoExecutanteId = new bool[] {false} ;
         P008910_A38GestaoServicoId = new long[1] ;
         P008910_A423ExecutanteTipoHoraDescricao = new string[] {""} ;
         P008910_A424GestaoServicoExecutanteQtdHora = new short[1] ;
         P008910_A422ExecutanteTipoHoraId = new long[1] ;
         P008910_n422ExecutanteTipoHoraId = new bool[] {false} ;
         P008910_A131GestaoServicoExecutanteId = new long[1] ;
         A423ExecutanteTipoHoraDescricao = "";
         P008911_A341FuncaoTipoHHId = new long[1] ;
         P008911_A163FuncaoId = new long[1] ;
         P008911_A338FuncaoTipoHoraValor = new decimal[1] ;
         P008912_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008912_A145OrdemGestaoServicoId = new long[1] ;
         P008912_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008912_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008912_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008912_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008912_A140OrdemExecutanteComentario = new string[] {""} ;
         P008912_A142OrdemExecutanteValor = new decimal[1] ;
         P008912_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV61ServicoExecutanteNome = "";
         AV78Inicio = "";
         AV79Termino = "";
         AV31GestaoServicoComentario = "";
         AV46GestaoServicoValor = "";
         P008913_A55ServicoExecutanteId = new long[1] ;
         P008913_n55ServicoExecutanteId = new bool[] {false} ;
         P008913_A38GestaoServicoId = new long[1] ;
         P008913_A56ServicoExecutanteNome = new string[] {""} ;
         P008913_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV86MsgVarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcimpressaoosmodelo3__default(),
            new Object[][] {
                new Object[] {
               P00892_A36ServicoSetorId, P00892_A38GestaoServicoId, P00892_A77ServicoEmpresaId, P00892_A79GestaoServicoNumero, P00892_A40GestaoServicoDescricao, P00892_A35ServicoClienteNome, P00892_A37ServicoSetorNome, P00892_A54ServicoNaturezaNome, P00892_A41GestaoServicoPrioridade, P00892_A42GestaoServicoStatus,
               P00892_A43GestaoServicoDtProgramada, P00892_A39GestaoServicoDtHora, P00892_A157GestaoServicoPrecificacao, P00892_A53ServicoNaturezaId, P00892_n53ServicoNaturezaId, P00892_A129EnderecoId, P00892_n129EnderecoId, P00892_A34ServicoClienteId, P00892_A322GestaoServicoTipoDemanda, P00892_A420GestaoServicoTipoHH,
               P00892_n420GestaoServicoTipoHH
               }
               , new Object[] {
               P00893_A106ClienteEnderecoId, P00893_A17ClienteId, P00893_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00894_A1EmpresaId, P00894_A2EmpresaNome, P00894_A3EmpresaCNPJ, P00894_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00895_A38GestaoServicoId, P00895_A326TipoServicoNome, P00895_A329TipoServicoEstimado, P00895_A325TipoServicoId, P00895_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00896_A25NaturezaId, P00896_A162NaturezaValor, P00896_A289NaturezaCusto
               }
               , new Object[] {
               P00897_A38GestaoServicoId, P00897_A55ServicoExecutanteId, P00897_n55ServicoExecutanteId, P00897_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00898_A9UsuarioId, P00898_A173UsuarioFuncaoId, P00898_n173UsuarioFuncaoId, P00898_A10UsuarioNome
               }
               , new Object[] {
               P00899_A341FuncaoTipoHHId, P00899_A163FuncaoId, P00899_A343FuncaoTipoHHDescricao, P00899_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008910_A55ServicoExecutanteId, P008910_n55ServicoExecutanteId, P008910_A38GestaoServicoId, P008910_A423ExecutanteTipoHoraDescricao, P008910_A424GestaoServicoExecutanteQtdHora, P008910_A422ExecutanteTipoHoraId, P008910_n422ExecutanteTipoHoraId, P008910_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008911_A341FuncaoTipoHHId, P008911_A163FuncaoId, P008911_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008912_A133OrdemExecutanteUsuarioId, P008912_A145OrdemGestaoServicoId, P008912_A134OrdemExecutanteUsuarioNome, P008912_A137OrdemExecutanteHrInicio, P008912_A136OrdemExecutanteDtInicio, P008912_A139OrdemExecutanteHrConclusao, P008912_A140OrdemExecutanteComentario, P008912_A142OrdemExecutanteValor, P008912_A135OrdemExecutanteId
               }
               , new Object[] {
               P008913_A55ServicoExecutanteId, P008913_n55ServicoExecutanteId, P008913_A38GestaoServicoId, P008913_A56ServicoExecutanteNome, P008913_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV85Tela ;
      private short GxWebError ;
      private short AV55PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV42GestaoServicoPrecificacao ;
      private short AV45GestaoServicoStatus ;
      private short AV83GestaoServicoTipoHH ;
      private short A329TipoServicoEstimado ;
      private short AV84QtdHoras ;
      private short A424GestaoServicoExecutanteQtdHora ;
      private short AV106GXLvl124 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV97GXV1 ;
      private int AV100GXV2 ;
      private int AV101GXV3 ;
      private long AV39GestaoServicoId ;
      private long AV74UsuarioId ;
      private long AV21EmpresaId ;
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
      private long A341FuncaoTipoHHId ;
      private long A163FuncaoId ;
      private long A422ExecutanteTipoHoraId ;
      private long AV90ExecutanteTipoHoraId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV69Total ;
      private decimal A338FuncaoTipoHoraValor ;
      private decimal A142OrdemExecutanteValor ;
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
      private string A343FuncaoTipoHHDescricao ;
      private string AV81FuncaoTipoHoraDescricao ;
      private string A423ExecutanteTipoHoraDescricao ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV61ServicoExecutanteNome ;
      private string AV78Inicio ;
      private string AV79Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV16DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV35GestaoServicoDtHora ;
      private DateTime AV91TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV36GestaoServicoDtProgramada ;
      private DateTime AV68TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n420GestaoServicoTipoHH ;
      private bool n55ServicoExecutanteId ;
      private bool AV89IsExiste ;
      private bool n173UsuarioFuncaoId ;
      private bool n422ExecutanteTipoHoraId ;
      private string A40GestaoServicoDescricao ;
      private string AV34GestaoServicoDescricao ;
      private string AV43GestaoServicoPrecificacaoVarChar ;
      private string AV9TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV17Descricao ;
      private string AV20EmpresaFotoUrl ;
      private string AV71Url ;
      private string AV95Empresafoto_GXI ;
      private string AV67TempoEstimado ;
      private string AV52NaturezaValorVarChar ;
      private string AV51NaturezaCustoVarChar ;
      private string AV70TotalVarChar ;
      private string AV87GestaoServicoIdVarChar ;
      private string AV88ServicoExecutanteIdVarChar ;
      private string AV82FuncaoTipoHoraValorDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV31GestaoServicoComentario ;
      private string AV46GestaoServicoValor ;
      private string AV86MsgVarChar ;
      private string AV19EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV75WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV56SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00892_A36ServicoSetorId ;
      private long[] P00892_A38GestaoServicoId ;
      private long[] P00892_A77ServicoEmpresaId ;
      private long[] P00892_A79GestaoServicoNumero ;
      private string[] P00892_A40GestaoServicoDescricao ;
      private string[] P00892_A35ServicoClienteNome ;
      private string[] P00892_A37ServicoSetorNome ;
      private string[] P00892_A54ServicoNaturezaNome ;
      private short[] P00892_A41GestaoServicoPrioridade ;
      private short[] P00892_A42GestaoServicoStatus ;
      private DateTime[] P00892_A43GestaoServicoDtProgramada ;
      private DateTime[] P00892_A39GestaoServicoDtHora ;
      private short[] P00892_A157GestaoServicoPrecificacao ;
      private long[] P00892_A53ServicoNaturezaId ;
      private bool[] P00892_n53ServicoNaturezaId ;
      private long[] P00892_A129EnderecoId ;
      private bool[] P00892_n129EnderecoId ;
      private long[] P00892_A34ServicoClienteId ;
      private short[] P00892_A322GestaoServicoTipoDemanda ;
      private short[] P00892_A420GestaoServicoTipoHH ;
      private bool[] P00892_n420GestaoServicoTipoHH ;
      private long[] P00893_A106ClienteEnderecoId ;
      private long[] P00893_A17ClienteId ;
      private string[] P00893_A107ClienteEnderecoLocal ;
      private long[] P00894_A1EmpresaId ;
      private string[] P00894_A2EmpresaNome ;
      private string[] P00894_A3EmpresaCNPJ ;
      private string[] P00894_A40000EmpresaFoto_GXI ;
      private long[] P00895_A38GestaoServicoId ;
      private string[] P00895_A326TipoServicoNome ;
      private short[] P00895_A329TipoServicoEstimado ;
      private long[] P00895_A325TipoServicoId ;
      private long[] P00895_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV80ServicoNaturezaIdCollection ;
      private long[] P00896_A25NaturezaId ;
      private decimal[] P00896_A162NaturezaValor ;
      private decimal[] P00896_A289NaturezaCusto ;
      private long[] P00897_A38GestaoServicoId ;
      private long[] P00897_A55ServicoExecutanteId ;
      private bool[] P00897_n55ServicoExecutanteId ;
      private long[] P00897_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV60ServicoExecutanteIdCollection ;
      private long[] P00898_A9UsuarioId ;
      private long[] P00898_A173UsuarioFuncaoId ;
      private bool[] P00898_n173UsuarioFuncaoId ;
      private string[] P00898_A10UsuarioNome ;
      private long[] P00899_A341FuncaoTipoHHId ;
      private long[] P00899_A163FuncaoId ;
      private string[] P00899_A343FuncaoTipoHHDescricao ;
      private decimal[] P00899_A338FuncaoTipoHoraValor ;
      private long[] P008910_A55ServicoExecutanteId ;
      private bool[] P008910_n55ServicoExecutanteId ;
      private long[] P008910_A38GestaoServicoId ;
      private string[] P008910_A423ExecutanteTipoHoraDescricao ;
      private short[] P008910_A424GestaoServicoExecutanteQtdHora ;
      private long[] P008910_A422ExecutanteTipoHoraId ;
      private bool[] P008910_n422ExecutanteTipoHoraId ;
      private long[] P008910_A131GestaoServicoExecutanteId ;
      private long[] P008911_A341FuncaoTipoHHId ;
      private long[] P008911_A163FuncaoId ;
      private decimal[] P008911_A338FuncaoTipoHoraValor ;
      private long[] P008912_A133OrdemExecutanteUsuarioId ;
      private long[] P008912_A145OrdemGestaoServicoId ;
      private string[] P008912_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008912_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008912_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008912_A139OrdemExecutanteHrConclusao ;
      private string[] P008912_A140OrdemExecutanteComentario ;
      private decimal[] P008912_A142OrdemExecutanteValor ;
      private long[] P008912_A135OrdemExecutanteId ;
      private long[] P008913_A55ServicoExecutanteId ;
      private bool[] P008913_n55ServicoExecutanteId ;
      private long[] P008913_A38GestaoServicoId ;
      private string[] P008913_A56ServicoExecutanteNome ;
      private long[] P008913_A131GestaoServicoExecutanteId ;
   }

   public class aprcimpressaoosmodelo3__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00892;
          prmP00892 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00893;
          prmP00893 = new Object[] {
          new ParDef("@AV57ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV23EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00894;
          prmP00894 = new Object[] {
          new ParDef("@AV59ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00895;
          prmP00895 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00896;
          prmP00896 = new Object[] {
          new ParDef("@AV62ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00897;
          prmP00897 = new Object[] {
          new ParDef("@AV87GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP00898;
          prmP00898 = new Object[] {
          new ParDef("@AV77ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00899;
          prmP00899 = new Object[] {
          new ParDef("@AV73UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008910;
          prmP008910 = new Object[] {
          new ParDef("@AV87GestaoServicoIdVarChar",GXType.VarChar,40,0) ,
          new ParDef("@AV88ServicoExecutanteIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP008911;
          prmP008911 = new Object[] {
          new ParDef("@AV73UsuarioFuncaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV90ExecutanteTipoHoraId",GXType.Decimal,18,0)
          };
          Object[] prmP008912;
          prmP008912 = new Object[] {
          new ParDef("@AV39GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008913;
          prmP008913 = new Object[] {
          new ParDef("@AV87GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00892", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV39GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00892,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00893", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV57ServicoClienteId and [ClienteEnderecoId] = @AV23EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00893,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00894", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV59ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00894,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00895", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV39GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00895,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00896", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV62ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00896,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00897", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV87GestaoServicoIdVarChar) ORDER BY [GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00897,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00898", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV77ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00898,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00899", "SELECT T1.[FuncaoTipoHHId] AS FuncaoTipoHHId, T1.[FuncaoId], T2.[TipoHoraDescricao] AS FuncaoTipoHHDescricao, T1.[FuncaoTipoHoraValor] FROM ([FuncaoTipoHora] T1 INNER JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[FuncaoTipoHHId]) WHERE T1.[FuncaoId] = @AV73UsuarioFuncaoId ORDER BY T1.[FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00899,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008910", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[TipoHoraDescricao] AS ExecutanteTipoHoraDescricao, T1.[GestaoServicoExecutanteQtdHora], T1.[ExecutanteTipoHoraId] AS ExecutanteTipoHoraId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[ExecutanteTipoHoraId]) WHERE (T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV87GestaoServicoIdVarChar)) AND (T1.[ServicoExecutanteId] = CONVERT( DECIMAL(28,14), @AV88ServicoExecutanteIdVarChar)) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008910,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008911", "SELECT [FuncaoTipoHHId] AS FuncaoTipoHHId, [FuncaoId], [FuncaoTipoHoraValor] FROM [FuncaoTipoHora] WHERE [FuncaoId] = @AV73UsuarioFuncaoId and [FuncaoTipoHHId] = @AV90ExecutanteTipoHoraId ORDER BY [FuncaoId], [FuncaoTipoHHId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008911,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008912", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV39GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008912,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008913", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV87GestaoServicoIdVarChar) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008913,100, GxCacheFrequency.OFF ,false,false )
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
