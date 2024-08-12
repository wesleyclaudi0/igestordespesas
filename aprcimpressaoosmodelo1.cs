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
   public class aprcimpressaoosmodelo1 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
                  AV95Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcimpressaoosmodelo1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcimpressaoosmodelo1( IGxContext context )
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
         this.AV95Tela = aP1_Tela;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 short aP1_Tela )
      {
         this.AV29GestaoServicoId = aP0_GestaoServicoId;
         this.AV95Tela = aP1_Tela;
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
         setOutputFileName("ImpressaoM1.pdf");
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
            AV65SDTContexto.FromJSonString(AV67WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV54UsuarioId = AV65SDTContexto.gxTpr_Usuarioid;
            AV66EmpresaId = AV65SDTContexto.gxTpr_Empresaid;
            AV40PerfilUsuario = AV65SDTContexto.gxTpr_Usuarioperfil;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00872 */
            pr_default.execute(0, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36ServicoSetorId = P00872_A36ServicoSetorId[0];
               A38GestaoServicoId = P00872_A38GestaoServicoId[0];
               A77ServicoEmpresaId = P00872_A77ServicoEmpresaId[0];
               A79GestaoServicoNumero = P00872_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00872_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00872_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00872_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00872_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00872_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00872_A42GestaoServicoStatus[0];
               A43GestaoServicoDtProgramada = P00872_A43GestaoServicoDtProgramada[0];
               A39GestaoServicoDtHora = P00872_A39GestaoServicoDtHora[0];
               A157GestaoServicoPrecificacao = P00872_A157GestaoServicoPrecificacao[0];
               A53ServicoNaturezaId = P00872_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00872_n53ServicoNaturezaId[0];
               A129EnderecoId = P00872_A129EnderecoId[0];
               n129EnderecoId = P00872_n129EnderecoId[0];
               A34ServicoClienteId = P00872_A34ServicoClienteId[0];
               A322GestaoServicoTipoDemanda = P00872_A322GestaoServicoTipoDemanda[0];
               A420GestaoServicoTipoHH = P00872_A420GestaoServicoTipoHH[0];
               n420GestaoServicoTipoHH = P00872_n420GestaoServicoTipoHH[0];
               A37ServicoSetorNome = P00872_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00872_A54ServicoNaturezaNome[0];
               A35ServicoClienteNome = P00872_A35ServicoClienteNome[0];
               AV43ServicoEmpresaId = A77ServicoEmpresaId;
               AV30GestaoServicoNumero = A79GestaoServicoNumero;
               AV24GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV42ServicoClienteNome = A35ServicoClienteNome;
               AV49ServicoSetorNome = A37ServicoSetorNome;
               AV47ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV10AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV11AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               AV35GestaoServicoStatus = A42GestaoServicoStatus;
               AV26GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
               AV25GestaoServicoDtHora = A39GestaoServicoDtHora;
               AV32GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
               AV33GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
               AV46ServicoNaturezaId = A53ServicoNaturezaId;
               AV19EnderecoId = A129EnderecoId;
               AV41ServicoClienteId = A34ServicoClienteId;
               AV72TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
               AV94GestaoServicoTipoHH = A420GestaoServicoTipoHH;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00873 */
            pr_default.execute(1, new Object[] {AV41ServicoClienteId, AV19EnderecoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106ClienteEnderecoId = P00873_A106ClienteEnderecoId[0];
               A17ClienteId = P00873_A17ClienteId[0];
               A107ClienteEnderecoLocal = P00873_A107ClienteEnderecoLocal[0];
               AV20EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00874 */
            pr_default.execute(2, new Object[] {AV43ServicoEmpresaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1EmpresaId = P00874_A1EmpresaId[0];
               A2EmpresaNome = P00874_A2EmpresaNome[0];
               A3EmpresaCNPJ = P00874_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P00874_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "REGISTRO DE ORDEM DE SERVIÇO", "");
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV105Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            H870( false, 151) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 208, Gx_line+0, 558, Gx_line+33, 1, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16EmpresaFoto)) ? AV105Empresafoto_GXI : AV16EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 17, Gx_line+50, 182, Gx_line+115) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15EmpresaCNPJ, "")), 200, Gx_line+83, 442, Gx_line+98, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpresaNome, "")), 200, Gx_line+67, 442, Gx_line+82, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(533, Gx_line+66, 775, Gx_line+116, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "O.S Nº: ", ""), 617, Gx_line+68, 673, Gx_line+86, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 674, Gx_line+69, 766, Gx_line+86, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Data da Abertura:", ""), 564, Gx_line+94, 672, Gx_line+112, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25GestaoServicoDtHora, "99/99/9999 99:99:99"), 668, Gx_line+95, 768, Gx_line+112, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+151);
            H870( false, 259) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+242, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 142, Gx_line+67, 200, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 142, Gx_line+133, 192, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 450, Gx_line+67, 533, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 142, Gx_line+100, 225, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 450, Gx_line+100, 508, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ServicoClienteNome, "")), 200, Gx_line+68, 417, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49ServicoSetorNome, "")), 192, Gx_line+134, 350, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10AuxGestaoServicoPrioridade, "")), 524, Gx_line+68, 666, Gx_line+85, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoStatus, "")), 499, Gx_line+101, 641, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "DADOS GERAIS", ""), 325, Gx_line+17, 469, Gx_line+38, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EnderecoLocal, "")), 217, Gx_line+101, 417, Gx_line+118, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoPrecificacaoVarChar, "")), 539, Gx_line+134, 756, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 450, Gx_line+133, 550, Gx_line+151, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Programada para:", ""), 142, Gx_line+167, 275, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV26GestaoServicoDtProgramada, "99/99/99"), 267, Gx_line+168, 392, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 142, Gx_line+200, 225, Gx_line+218, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24GestaoServicoDescricao, "")), 217, Gx_line+201, 750, Gx_line+218, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Demanda:", ""), 450, Gx_line+167, 592, Gx_line+185, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TipoDemandaVarChar, "")), 572, Gx_line+168, 722, Gx_line+185, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+259);
            /* Using cursor P00875 */
            pr_default.execute(3, new Object[] {AV29GestaoServicoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A38GestaoServicoId = P00875_A38GestaoServicoId[0];
               A326TipoServicoNome = P00875_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00875_A329TipoServicoEstimado[0];
               A325TipoServicoId = P00875_A325TipoServicoId[0];
               A323GestaoServicoTipoId = P00875_A323GestaoServicoTipoId[0];
               A326TipoServicoNome = P00875_A326TipoServicoNome[0];
               A329TipoServicoEstimado = P00875_A329TipoServicoEstimado[0];
               AV73ServicoDescricao = context.GetMessage( "SERVIÇO", "");
               AV47ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
               AV70TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
               AV101TerminoDateTime = DateTimeUtil.ResetTime( AV26GestaoServicoDtProgramada ) ;
               AV69TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV101TerminoDateTime, 3600*(A329TipoServicoEstimado)));
               AV89ServicoNaturezaIdCollection.Add(A325TipoServicoId, 0);
               H870( false, 133) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+117, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ServicoNaturezaNome, "")), 250, Gx_line+51, 404, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço:", ""), 142, Gx_line+50, 267, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término Previsto:", ""), 142, Gx_line+83, 275, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Tempo Estimado:", ""), 450, Gx_line+50, 583, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV69TerminoDate, "99/99/99"), 262, Gx_line+84, 420, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73ServicoDescricao, "")), 182, Gx_line+9, 599, Gx_line+42, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TempoEstimado, "")), 572, Gx_line+51, 672, Gx_line+68, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+133);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV40PerfilUsuario != 4 )
            {
               if ( AV32GestaoServicoPrecificacao == 2 )
               {
                  AV107GXV1 = 1;
                  while ( AV107GXV1 <= AV89ServicoNaturezaIdCollection.Count )
                  {
                     AV46ServicoNaturezaId = (long)(AV89ServicoNaturezaIdCollection.GetNumeric(AV107GXV1));
                     /* Using cursor P00876 */
                     pr_default.execute(4, new Object[] {AV46ServicoNaturezaId});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A25NaturezaId = P00876_A25NaturezaId[0];
                        A162NaturezaValor = P00876_A162NaturezaValor[0];
                        A289NaturezaCusto = P00876_A289NaturezaCusto[0];
                        AV39NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                        AV38NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                        AV51Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                        AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
                        H870( false, 188) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+167, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Custo:", ""), 142, Gx_line+83, 192, Gx_line+101, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor do Serviço:", ""), 142, Gx_line+50, 309, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Valor Total:", ""), 142, Gx_line+117, 275, Gx_line+135, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TotalVarChar, "")), 450, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 450, Gx_line+83, 608, Gx_line+101, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 450, Gx_line+50, 608, Gx_line+68, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 450, Gx_line+38, 0+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+188);
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     AV107GXV1 = (int)(AV107GXV1+1);
                  }
               }
               else
               {
                  AV97GestaoServicoIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV29GestaoServicoId), 18, 0));
                  if ( AV32GestaoServicoPrecificacao == 1 )
                  {
                     /* Using cursor P00877 */
                     pr_default.execute(5, new Object[] {AV97GestaoServicoIdVarChar});
                     while ( (pr_default.getStatus(5) != 101) )
                     {
                        A38GestaoServicoId = P00877_A38GestaoServicoId[0];
                        A55ServicoExecutanteId = P00877_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P00877_n55ServicoExecutanteId[0];
                        A131GestaoServicoExecutanteId = P00877_A131GestaoServicoExecutanteId[0];
                        AV110GXV2 = 1;
                        while ( AV110GXV2 <= AV44ServicoExecutanteIdCollection.Count )
                        {
                           AV74ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV110GXV2));
                           if ( AV74ServicoExecutanteId == A55ServicoExecutanteId )
                           {
                              AV100IsExiste = true;
                           }
                           else
                           {
                              AV100IsExiste = false;
                           }
                           AV110GXV2 = (int)(AV110GXV2+1);
                        }
                        if ( ! AV100IsExiste )
                        {
                           AV44ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                        }
                        pr_default.readNext(5);
                     }
                     pr_default.close(5);
                     AV111GXV3 = 1;
                     while ( AV111GXV3 <= AV44ServicoExecutanteIdCollection.Count )
                     {
                        AV74ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV111GXV3));
                        AV98ServicoExecutanteIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV74ServicoExecutanteId), 18, 0));
                        /* Using cursor P00878 */
                        pr_default.execute(6, new Object[] {AV74ServicoExecutanteId});
                        while ( (pr_default.getStatus(6) != 101) )
                        {
                           A9UsuarioId = P00878_A9UsuarioId[0];
                           A173UsuarioFuncaoId = P00878_A173UsuarioFuncaoId[0];
                           n173UsuarioFuncaoId = P00878_n173UsuarioFuncaoId[0];
                           A10UsuarioNome = P00878_A10UsuarioNome[0];
                           AV62UsuarioFuncaoId = A173UsuarioFuncaoId;
                           AV64OrcamentoTipoHH = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                           /* Exiting from a For First loop. */
                           if (true) break;
                        }
                        pr_default.close(6);
                        H870( false, 84) ;
                        getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64OrcamentoTipoHH, "")), 175, Gx_line+33, 592, Gx_line+66, 1, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+84);
                        if ( AV94GestaoServicoTipoHH == 2 )
                        {
                           /* Using cursor P00879 */
                           pr_default.execute(7, new Object[] {AV62UsuarioFuncaoId});
                           while ( (pr_default.getStatus(7) != 101) )
                           {
                              A341FuncaoTipoHHId = P00879_A341FuncaoTipoHHId[0];
                              A163FuncaoId = P00879_A163FuncaoId[0];
                              A343FuncaoTipoHHDescricao = P00879_A343FuncaoTipoHHDescricao[0];
                              A338FuncaoTipoHoraValor = P00879_A338FuncaoTipoHoraValor[0];
                              A343FuncaoTipoHHDescricao = P00879_A343FuncaoTipoHHDescricao[0];
                              AV90FuncaoTipoHoraDescricao = A343FuncaoTipoHHDescricao;
                              AV92FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                              H870( false, 50) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+50, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90FuncaoTipoHoraDescricao, "")), 125, Gx_line+18, 283, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92FuncaoTipoHoraValorDescricao, "")), 650, Gx_line+18, 767, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV93QtdHoras), "ZZZ9")), 426, Gx_line+18, 468, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "Valor por Hora:", ""), 542, Gx_line+17, 650, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Qtd de Horas:", ""), 333, Gx_line+17, 425, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Tipo de Hora:", ""), 33, Gx_line+17, 125, Gx_line+35, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+50);
                              pr_default.readNext(7);
                           }
                           pr_default.close(7);
                        }
                        else
                        {
                           /* Using cursor P008710 */
                           pr_default.execute(8, new Object[] {AV97GestaoServicoIdVarChar, AV98ServicoExecutanteIdVarChar});
                           while ( (pr_default.getStatus(8) != 101) )
                           {
                              A55ServicoExecutanteId = P008710_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008710_n55ServicoExecutanteId[0];
                              A38GestaoServicoId = P008710_A38GestaoServicoId[0];
                              A423ExecutanteTipoHoraDescricao = P008710_A423ExecutanteTipoHoraDescricao[0];
                              A422ExecutanteTipoHoraId = P008710_A422ExecutanteTipoHoraId[0];
                              n422ExecutanteTipoHoraId = P008710_n422ExecutanteTipoHoraId[0];
                              A131GestaoServicoExecutanteId = P008710_A131GestaoServicoExecutanteId[0];
                              A423ExecutanteTipoHoraDescricao = P008710_A423ExecutanteTipoHoraDescricao[0];
                              AV90FuncaoTipoHoraDescricao = A423ExecutanteTipoHoraDescricao;
                              AV99ExecutanteTipoHoraId = A422ExecutanteTipoHoraId;
                              /* Using cursor P008711 */
                              pr_default.execute(9, new Object[] {AV62UsuarioFuncaoId, AV99ExecutanteTipoHoraId});
                              while ( (pr_default.getStatus(9) != 101) )
                              {
                                 A341FuncaoTipoHHId = P008711_A341FuncaoTipoHHId[0];
                                 A163FuncaoId = P008711_A163FuncaoId[0];
                                 A338FuncaoTipoHoraValor = P008711_A338FuncaoTipoHoraValor[0];
                                 AV92FuncaoTipoHoraValorDescricao = context.GetMessage( "R$", "") + StringUtil.Trim( StringUtil.Str( A338FuncaoTipoHoraValor, 18, 2));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(9);
                              H870( false, 50) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+50, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90FuncaoTipoHoraDescricao, "")), 125, Gx_line+18, 283, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92FuncaoTipoHoraValorDescricao, "")), 650, Gx_line+18, 767, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV93QtdHoras), "ZZZ9")), 426, Gx_line+18, 468, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "Valor por Hora:", ""), 542, Gx_line+17, 650, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Qtd de Horas:", ""), 333, Gx_line+17, 425, Gx_line+35, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Tipo de Hora:", ""), 33, Gx_line+17, 125, Gx_line+35, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+50);
                              pr_default.readNext(8);
                           }
                           pr_default.close(8);
                        }
                        AV111GXV3 = (int)(AV111GXV3+1);
                     }
                  }
               }
            }
            if ( AV95Tela == 1 )
            {
               H870( false, 85) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Atividades", ""), 267, Gx_line+33, 525, Gx_line+51, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Início", ""), 183, Gx_line+67, 283, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Término", ""), 292, Gx_line+67, 417, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 433, Gx_line+67, 566, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 25, Gx_line+67, 133, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 683, Gx_line+67, 741, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+67, 775, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(125, Gx_line+67, 175, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(258, Gx_line+67, 283, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(400, Gx_line+67, 425, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(583, Gx_line+67, 675, Gx_line+84, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+50, 1, 169, 169, 169, 0, 255, 255, 255, 0, 1, 1, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+85);
               AV116GXLvl125 = 0;
               /* Using cursor P008712 */
               pr_default.execute(10, new Object[] {AV29GestaoServicoId});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A133OrdemExecutanteUsuarioId = P008712_A133OrdemExecutanteUsuarioId[0];
                  A145OrdemGestaoServicoId = P008712_A145OrdemGestaoServicoId[0];
                  A134OrdemExecutanteUsuarioNome = P008712_A134OrdemExecutanteUsuarioNome[0];
                  A137OrdemExecutanteHrInicio = P008712_A137OrdemExecutanteHrInicio[0];
                  A136OrdemExecutanteDtInicio = P008712_A136OrdemExecutanteDtInicio[0];
                  A139OrdemExecutanteHrConclusao = P008712_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P008712_A140OrdemExecutanteComentario[0];
                  A142OrdemExecutanteValor = P008712_A142OrdemExecutanteValor[0];
                  A135OrdemExecutanteId = P008712_A135OrdemExecutanteId[0];
                  A134OrdemExecutanteUsuarioNome = P008712_A134OrdemExecutanteUsuarioNome[0];
                  AV116GXLvl125 = 1;
                  AV45ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                  AV77Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                  AV78Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                  AV21GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                  if ( AV40PerfilUsuario != 4 )
                  {
                     AV36GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                  }
                  H870( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Inicio, "")), 183, Gx_line+1, 275, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Termino, "")), 292, Gx_line+1, 417, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 683, Gx_line+1, 775, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 433, Gx_line+1, 666, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(233, Gx_line+0, 283, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(375, Gx_line+0, 425, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(625, Gx_line+0, 675, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 175, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  pr_default.readNext(10);
               }
               pr_default.close(10);
               if ( AV116GXLvl125 == 0 )
               {
                  /* Using cursor P008713 */
                  pr_default.execute(11, new Object[] {AV97GestaoServicoIdVarChar});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A55ServicoExecutanteId = P008713_A55ServicoExecutanteId[0];
                     n55ServicoExecutanteId = P008713_n55ServicoExecutanteId[0];
                     A38GestaoServicoId = P008713_A38GestaoServicoId[0];
                     A56ServicoExecutanteNome = P008713_A56ServicoExecutanteNome[0];
                     A131GestaoServicoExecutanteId = P008713_A131GestaoServicoExecutanteId[0];
                     A56ServicoExecutanteNome = P008713_A56ServicoExecutanteNome[0];
                     AV45ServicoExecutanteNome = A56ServicoExecutanteNome;
                     H870( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Inicio, "")), 183, Gx_line+1, 275, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Termino, "")), 292, Gx_line+1, 417, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 683, Gx_line+1, 775, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 433, Gx_line+1, 666, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(233, Gx_line+0, 283, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(375, Gx_line+0, 425, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(625, Gx_line+0, 675, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 175, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                     pr_default.readNext(11);
                  }
                  pr_default.close(11);
               }
            }
            if ( AV94GestaoServicoTipoHH == 2 )
            {
               AV96MsgVarChar = context.GetMessage( "OBS: A ordem de serviço está marcada como HH por DEMANDA. O orçamento completo será exibido no final da OS.", "");
            }
            H870( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96MsgVarChar, "")), 17, Gx_line+17, 775, Gx_line+35, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            H870( false, 223) ;
            getPrinter().GxDrawLine(117, Gx_line+150, 367, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(450, Gx_line+150, 700, Gx_line+150, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 183, Gx_line+167, 287, Gx_line+181, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 500, Gx_line+167, 635, Gx_line+181, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+223);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H870( true, 0) ;
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

      protected void H870( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV13DateTime, "99/99/99 99:99"), 292, Gx_line+0, 475, Gx_line+15, 1, 0, 0, 0) ;
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
         AV65SDTContexto = new SdtSDTContexto(context);
         AV67WebSession = context.GetSession();
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P00872_A36ServicoSetorId = new long[1] ;
         P00872_A38GestaoServicoId = new long[1] ;
         P00872_A77ServicoEmpresaId = new long[1] ;
         P00872_A79GestaoServicoNumero = new long[1] ;
         P00872_A40GestaoServicoDescricao = new string[] {""} ;
         P00872_A35ServicoClienteNome = new string[] {""} ;
         P00872_A37ServicoSetorNome = new string[] {""} ;
         P00872_A54ServicoNaturezaNome = new string[] {""} ;
         P00872_A41GestaoServicoPrioridade = new short[1] ;
         P00872_A42GestaoServicoStatus = new short[1] ;
         P00872_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P00872_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00872_A157GestaoServicoPrecificacao = new short[1] ;
         P00872_A53ServicoNaturezaId = new long[1] ;
         P00872_n53ServicoNaturezaId = new bool[] {false} ;
         P00872_A129EnderecoId = new long[1] ;
         P00872_n129EnderecoId = new bool[] {false} ;
         P00872_A34ServicoClienteId = new long[1] ;
         P00872_A322GestaoServicoTipoDemanda = new short[1] ;
         P00872_A420GestaoServicoTipoHH = new short[1] ;
         P00872_n420GestaoServicoTipoHH = new bool[] {false} ;
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
         AV72TipoDemandaVarChar = "";
         P00873_A106ClienteEnderecoId = new long[1] ;
         P00873_A17ClienteId = new long[1] ;
         P00873_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV20EnderecoLocal = "";
         P00874_A1EmpresaId = new long[1] ;
         P00874_A2EmpresaNome = new string[] {""} ;
         P00874_A3EmpresaCNPJ = new string[] {""} ;
         P00874_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV105Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         AV16EmpresaFoto = "";
         sImgUrl = "";
         P00875_A38GestaoServicoId = new long[1] ;
         P00875_A326TipoServicoNome = new string[] {""} ;
         P00875_A329TipoServicoEstimado = new short[1] ;
         P00875_A325TipoServicoId = new long[1] ;
         P00875_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV73ServicoDescricao = "";
         AV70TempoEstimado = "";
         AV101TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV69TerminoDate = DateTime.MinValue;
         AV89ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P00876_A25NaturezaId = new long[1] ;
         P00876_A162NaturezaValor = new decimal[1] ;
         P00876_A289NaturezaCusto = new decimal[1] ;
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         AV97GestaoServicoIdVarChar = "";
         P00877_A38GestaoServicoId = new long[1] ;
         P00877_A55ServicoExecutanteId = new long[1] ;
         P00877_n55ServicoExecutanteId = new bool[] {false} ;
         P00877_A131GestaoServicoExecutanteId = new long[1] ;
         AV44ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         AV98ServicoExecutanteIdVarChar = "";
         P00878_A9UsuarioId = new long[1] ;
         P00878_A173UsuarioFuncaoId = new long[1] ;
         P00878_n173UsuarioFuncaoId = new bool[] {false} ;
         P00878_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV64OrcamentoTipoHH = "";
         P00879_A341FuncaoTipoHHId = new long[1] ;
         P00879_A163FuncaoId = new long[1] ;
         P00879_A343FuncaoTipoHHDescricao = new string[] {""} ;
         P00879_A338FuncaoTipoHoraValor = new decimal[1] ;
         A343FuncaoTipoHHDescricao = "";
         AV90FuncaoTipoHoraDescricao = "";
         AV92FuncaoTipoHoraValorDescricao = "";
         P008710_A55ServicoExecutanteId = new long[1] ;
         P008710_n55ServicoExecutanteId = new bool[] {false} ;
         P008710_A38GestaoServicoId = new long[1] ;
         P008710_A423ExecutanteTipoHoraDescricao = new string[] {""} ;
         P008710_A422ExecutanteTipoHoraId = new long[1] ;
         P008710_n422ExecutanteTipoHoraId = new bool[] {false} ;
         P008710_A131GestaoServicoExecutanteId = new long[1] ;
         A423ExecutanteTipoHoraDescricao = "";
         P008711_A341FuncaoTipoHHId = new long[1] ;
         P008711_A163FuncaoId = new long[1] ;
         P008711_A338FuncaoTipoHoraValor = new decimal[1] ;
         P008712_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008712_A145OrdemGestaoServicoId = new long[1] ;
         P008712_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008712_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008712_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008712_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008712_A140OrdemExecutanteComentario = new string[] {""} ;
         P008712_A142OrdemExecutanteValor = new decimal[1] ;
         P008712_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV45ServicoExecutanteNome = "";
         AV77Inicio = "";
         AV78Termino = "";
         AV21GestaoServicoComentario = "";
         AV36GestaoServicoValor = "";
         P008713_A55ServicoExecutanteId = new long[1] ;
         P008713_n55ServicoExecutanteId = new bool[] {false} ;
         P008713_A38GestaoServicoId = new long[1] ;
         P008713_A56ServicoExecutanteNome = new string[] {""} ;
         P008713_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV96MsgVarChar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcimpressaoosmodelo1__default(),
            new Object[][] {
                new Object[] {
               P00872_A36ServicoSetorId, P00872_A38GestaoServicoId, P00872_A77ServicoEmpresaId, P00872_A79GestaoServicoNumero, P00872_A40GestaoServicoDescricao, P00872_A35ServicoClienteNome, P00872_A37ServicoSetorNome, P00872_A54ServicoNaturezaNome, P00872_A41GestaoServicoPrioridade, P00872_A42GestaoServicoStatus,
               P00872_A43GestaoServicoDtProgramada, P00872_A39GestaoServicoDtHora, P00872_A157GestaoServicoPrecificacao, P00872_A53ServicoNaturezaId, P00872_n53ServicoNaturezaId, P00872_A129EnderecoId, P00872_n129EnderecoId, P00872_A34ServicoClienteId, P00872_A322GestaoServicoTipoDemanda, P00872_A420GestaoServicoTipoHH,
               P00872_n420GestaoServicoTipoHH
               }
               , new Object[] {
               P00873_A106ClienteEnderecoId, P00873_A17ClienteId, P00873_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P00874_A1EmpresaId, P00874_A2EmpresaNome, P00874_A3EmpresaCNPJ, P00874_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00875_A38GestaoServicoId, P00875_A326TipoServicoNome, P00875_A329TipoServicoEstimado, P00875_A325TipoServicoId, P00875_A323GestaoServicoTipoId
               }
               , new Object[] {
               P00876_A25NaturezaId, P00876_A162NaturezaValor, P00876_A289NaturezaCusto
               }
               , new Object[] {
               P00877_A38GestaoServicoId, P00877_A55ServicoExecutanteId, P00877_n55ServicoExecutanteId, P00877_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00878_A9UsuarioId, P00878_A173UsuarioFuncaoId, P00878_n173UsuarioFuncaoId, P00878_A10UsuarioNome
               }
               , new Object[] {
               P00879_A341FuncaoTipoHHId, P00879_A163FuncaoId, P00879_A343FuncaoTipoHHDescricao, P00879_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008710_A55ServicoExecutanteId, P008710_n55ServicoExecutanteId, P008710_A38GestaoServicoId, P008710_A423ExecutanteTipoHoraDescricao, P008710_A422ExecutanteTipoHoraId, P008710_n422ExecutanteTipoHoraId, P008710_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008711_A341FuncaoTipoHHId, P008711_A163FuncaoId, P008711_A338FuncaoTipoHoraValor
               }
               , new Object[] {
               P008712_A133OrdemExecutanteUsuarioId, P008712_A145OrdemGestaoServicoId, P008712_A134OrdemExecutanteUsuarioNome, P008712_A137OrdemExecutanteHrInicio, P008712_A136OrdemExecutanteDtInicio, P008712_A139OrdemExecutanteHrConclusao, P008712_A140OrdemExecutanteComentario, P008712_A142OrdemExecutanteValor, P008712_A135OrdemExecutanteId
               }
               , new Object[] {
               P008713_A55ServicoExecutanteId, P008713_n55ServicoExecutanteId, P008713_A38GestaoServicoId, P008713_A56ServicoExecutanteNome, P008713_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV95Tela ;
      private short GxWebError ;
      private short AV40PerfilUsuario ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short A420GestaoServicoTipoHH ;
      private short AV35GestaoServicoStatus ;
      private short AV32GestaoServicoPrecificacao ;
      private short AV94GestaoServicoTipoHH ;
      private short A329TipoServicoEstimado ;
      private short AV93QtdHoras ;
      private short AV116GXLvl125 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV107GXV1 ;
      private int AV110GXV2 ;
      private int AV111GXV3 ;
      private long AV29GestaoServicoId ;
      private long AV54UsuarioId ;
      private long AV66EmpresaId ;
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
      private long AV74ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV62UsuarioFuncaoId ;
      private long A341FuncaoTipoHHId ;
      private long A163FuncaoId ;
      private long A422ExecutanteTipoHoraId ;
      private long AV99ExecutanteTipoHoraId ;
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
      private string sImgUrl ;
      private string A326TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV64OrcamentoTipoHH ;
      private string A343FuncaoTipoHHDescricao ;
      private string AV90FuncaoTipoHoraDescricao ;
      private string A423ExecutanteTipoHoraDescricao ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV45ServicoExecutanteNome ;
      private string AV77Inicio ;
      private string AV78Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV13DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV101TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime AV69TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n420GestaoServicoTipoHH ;
      private bool n55ServicoExecutanteId ;
      private bool AV100IsExiste ;
      private bool n173UsuarioFuncaoId ;
      private bool n422ExecutanteTipoHoraId ;
      private string A40GestaoServicoDescricao ;
      private string AV24GestaoServicoDescricao ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV72TipoDemandaVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV105Empresafoto_GXI ;
      private string AV73ServicoDescricao ;
      private string AV70TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV97GestaoServicoIdVarChar ;
      private string AV98ServicoExecutanteIdVarChar ;
      private string AV92FuncaoTipoHoraValorDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV21GestaoServicoComentario ;
      private string AV36GestaoServicoValor ;
      private string AV96MsgVarChar ;
      private string AV16EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV67WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV65SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00872_A36ServicoSetorId ;
      private long[] P00872_A38GestaoServicoId ;
      private long[] P00872_A77ServicoEmpresaId ;
      private long[] P00872_A79GestaoServicoNumero ;
      private string[] P00872_A40GestaoServicoDescricao ;
      private string[] P00872_A35ServicoClienteNome ;
      private string[] P00872_A37ServicoSetorNome ;
      private string[] P00872_A54ServicoNaturezaNome ;
      private short[] P00872_A41GestaoServicoPrioridade ;
      private short[] P00872_A42GestaoServicoStatus ;
      private DateTime[] P00872_A43GestaoServicoDtProgramada ;
      private DateTime[] P00872_A39GestaoServicoDtHora ;
      private short[] P00872_A157GestaoServicoPrecificacao ;
      private long[] P00872_A53ServicoNaturezaId ;
      private bool[] P00872_n53ServicoNaturezaId ;
      private long[] P00872_A129EnderecoId ;
      private bool[] P00872_n129EnderecoId ;
      private long[] P00872_A34ServicoClienteId ;
      private short[] P00872_A322GestaoServicoTipoDemanda ;
      private short[] P00872_A420GestaoServicoTipoHH ;
      private bool[] P00872_n420GestaoServicoTipoHH ;
      private long[] P00873_A106ClienteEnderecoId ;
      private long[] P00873_A17ClienteId ;
      private string[] P00873_A107ClienteEnderecoLocal ;
      private long[] P00874_A1EmpresaId ;
      private string[] P00874_A2EmpresaNome ;
      private string[] P00874_A3EmpresaCNPJ ;
      private string[] P00874_A40000EmpresaFoto_GXI ;
      private long[] P00875_A38GestaoServicoId ;
      private string[] P00875_A326TipoServicoNome ;
      private short[] P00875_A329TipoServicoEstimado ;
      private long[] P00875_A325TipoServicoId ;
      private long[] P00875_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV89ServicoNaturezaIdCollection ;
      private long[] P00876_A25NaturezaId ;
      private decimal[] P00876_A162NaturezaValor ;
      private decimal[] P00876_A289NaturezaCusto ;
      private long[] P00877_A38GestaoServicoId ;
      private long[] P00877_A55ServicoExecutanteId ;
      private bool[] P00877_n55ServicoExecutanteId ;
      private long[] P00877_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV44ServicoExecutanteIdCollection ;
      private long[] P00878_A9UsuarioId ;
      private long[] P00878_A173UsuarioFuncaoId ;
      private bool[] P00878_n173UsuarioFuncaoId ;
      private string[] P00878_A10UsuarioNome ;
      private long[] P00879_A341FuncaoTipoHHId ;
      private long[] P00879_A163FuncaoId ;
      private string[] P00879_A343FuncaoTipoHHDescricao ;
      private decimal[] P00879_A338FuncaoTipoHoraValor ;
      private long[] P008710_A55ServicoExecutanteId ;
      private bool[] P008710_n55ServicoExecutanteId ;
      private long[] P008710_A38GestaoServicoId ;
      private string[] P008710_A423ExecutanteTipoHoraDescricao ;
      private long[] P008710_A422ExecutanteTipoHoraId ;
      private bool[] P008710_n422ExecutanteTipoHoraId ;
      private long[] P008710_A131GestaoServicoExecutanteId ;
      private long[] P008711_A341FuncaoTipoHHId ;
      private long[] P008711_A163FuncaoId ;
      private decimal[] P008711_A338FuncaoTipoHoraValor ;
      private long[] P008712_A133OrdemExecutanteUsuarioId ;
      private long[] P008712_A145OrdemGestaoServicoId ;
      private string[] P008712_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008712_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008712_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008712_A139OrdemExecutanteHrConclusao ;
      private string[] P008712_A140OrdemExecutanteComentario ;
      private decimal[] P008712_A142OrdemExecutanteValor ;
      private long[] P008712_A135OrdemExecutanteId ;
      private long[] P008713_A55ServicoExecutanteId ;
      private bool[] P008713_n55ServicoExecutanteId ;
      private long[] P008713_A38GestaoServicoId ;
      private string[] P008713_A56ServicoExecutanteNome ;
      private long[] P008713_A131GestaoServicoExecutanteId ;
   }

   public class aprcimpressaoosmodelo1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00872;
          prmP00872 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00873;
          prmP00873 = new Object[] {
          new ParDef("@AV41ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP00874;
          prmP00874 = new Object[] {
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00875;
          prmP00875 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00876;
          prmP00876 = new Object[] {
          new ParDef("@AV46ServicoNaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP00877;
          prmP00877 = new Object[] {
          new ParDef("@AV97GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP00878;
          prmP00878 = new Object[] {
          new ParDef("@AV74ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP00879;
          prmP00879 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008710;
          prmP008710 = new Object[] {
          new ParDef("@AV97GestaoServicoIdVarChar",GXType.VarChar,40,0) ,
          new ParDef("@AV98ServicoExecutanteIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP008711;
          prmP008711 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV99ExecutanteTipoHoraId",GXType.Decimal,18,0)
          };
          Object[] prmP008712;
          prmP008712 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008713;
          prmP008713 = new Object[] {
          new ParDef("@AV97GestaoServicoIdVarChar",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00872", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[ServicoEmpresaId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[ServicoClienteId] AS ServicoClienteId, T1.[GestaoServicoTipoDemanda], T1.[GestaoServicoTipoHH] FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00872,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00873", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV41ServicoClienteId and [ClienteEnderecoId] = @AV19EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00873,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00874", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV43ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00874,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00875", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00875,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00876", "SELECT [NaturezaId], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV46ServicoNaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00876,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00877", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV97GestaoServicoIdVarChar) ORDER BY [GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00877,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00878", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV74ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00878,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00879", "SELECT T1.[FuncaoTipoHHId] AS FuncaoTipoHHId, T1.[FuncaoId], T2.[TipoHoraDescricao] AS FuncaoTipoHHDescricao, T1.[FuncaoTipoHoraValor] FROM ([FuncaoTipoHora] T1 INNER JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[FuncaoTipoHHId]) WHERE T1.[FuncaoId] = @AV62UsuarioFuncaoId ORDER BY T1.[FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00879,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008710", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[TipoHoraDescricao] AS ExecutanteTipoHoraDescricao, T1.[ExecutanteTipoHoraId] AS ExecutanteTipoHoraId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [TipoHora] T2 ON T2.[TipoHoraId] = T1.[ExecutanteTipoHoraId]) WHERE (T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV97GestaoServicoIdVarChar)) AND (T1.[ServicoExecutanteId] = CONVERT( DECIMAL(28,14), @AV98ServicoExecutanteIdVarChar)) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008710,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008711", "SELECT [FuncaoTipoHHId] AS FuncaoTipoHHId, [FuncaoId], [FuncaoTipoHoraValor] FROM [FuncaoTipoHora] WHERE [FuncaoId] = @AV62UsuarioFuncaoId and [FuncaoTipoHHId] = @AV99ExecutanteTipoHoraId ORDER BY [FuncaoId], [FuncaoTipoHHId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008711,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008712", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008712,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008713", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = CONVERT( DECIMAL(28,14), @AV97GestaoServicoIdVarChar) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008713,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
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
