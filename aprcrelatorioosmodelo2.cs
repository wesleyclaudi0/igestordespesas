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
   public class aprcrelatorioosmodelo2 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "UsuarioId");
            if ( ! entryPointCalled )
            {
               AV75UsuarioId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV31GestaoServicoDataInicio = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataInicio"));
                  AV30GestaoServicoDataConclusao = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataConclusao"));
                  AV56ServicoEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoEmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AV54ServicoClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoClienteId"), "."), 18, MidpointRounding.ToEven));
                  AV61ServicoSetorId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoSetorId"), "."), 18, MidpointRounding.ToEven));
                  AV42GestaoServicoPrioridade = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoPrioridade"), "."), 18, MidpointRounding.ToEven));
                  AV43GestaoServicoStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoStatus"), "."), 18, MidpointRounding.ToEven));
                  AV53PerfilUsuario = (short)(Math.Round(NumberUtil.Val( GetPar( "PerfilUsuario"), "."), 18, MidpointRounding.ToEven));
                  AV79TecnicoLongVarChar = GetPar( "TecnicoLongVarChar");
                  AV80NaturezaLongVarChar = GetPar( "NaturezaLongVarChar");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatorioosmodelo2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatorioosmodelo2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           DateTime aP1_GestaoServicoDataInicio ,
                           DateTime aP2_GestaoServicoDataConclusao ,
                           long aP3_ServicoEmpresaId ,
                           long aP4_ServicoClienteId ,
                           long aP5_ServicoSetorId ,
                           short aP6_GestaoServicoPrioridade ,
                           short aP7_GestaoServicoStatus ,
                           short aP8_PerfilUsuario ,
                           string aP9_TecnicoLongVarChar ,
                           string aP10_NaturezaLongVarChar )
      {
         this.AV75UsuarioId = aP0_UsuarioId;
         this.AV31GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV30GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV56ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV54ServicoClienteId = aP4_ServicoClienteId;
         this.AV61ServicoSetorId = aP5_ServicoSetorId;
         this.AV42GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV43GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV53PerfilUsuario = aP8_PerfilUsuario;
         this.AV79TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV80NaturezaLongVarChar = aP10_NaturezaLongVarChar;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 DateTime aP1_GestaoServicoDataInicio ,
                                 DateTime aP2_GestaoServicoDataConclusao ,
                                 long aP3_ServicoEmpresaId ,
                                 long aP4_ServicoClienteId ,
                                 long aP5_ServicoSetorId ,
                                 short aP6_GestaoServicoPrioridade ,
                                 short aP7_GestaoServicoStatus ,
                                 short aP8_PerfilUsuario ,
                                 string aP9_TecnicoLongVarChar ,
                                 string aP10_NaturezaLongVarChar )
      {
         this.AV75UsuarioId = aP0_UsuarioId;
         this.AV31GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV30GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV56ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV54ServicoClienteId = aP4_ServicoClienteId;
         this.AV61ServicoSetorId = aP5_ServicoSetorId;
         this.AV42GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV43GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV53PerfilUsuario = aP8_PerfilUsuario;
         this.AV79TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV80NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         setOutputFileName("RelatorioOSM2.pdf");
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
            AV14DateTime = DateTimeUtil.Now( context);
            AV81ExecutanteIdCollection.FromJSonString(AV79TecnicoLongVarChar, null);
            AV78ServicoNaturezaIdCollection.FromJSonString(AV80NaturezaLongVarChar, null);
            /* Using cursor P008E2 */
            pr_default.execute(0, new Object[] {AV56ServicoEmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P008E2_A1EmpresaId[0];
               A2EmpresaNome = P008E2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P008E2_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P008E2_A40000EmpresaFoto_GXI[0];
               AV15Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV20EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV16EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV18EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV72Url = StringUtil.StringReplace( AV18EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV92Empresafoto_GXI = AV72Url;
               AV17EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV54ServicoClienteId ,
                                                 AV61ServicoSetorId ,
                                                 AV42GestaoServicoPrioridade ,
                                                 AV43GestaoServicoStatus ,
                                                 A34ServicoClienteId ,
                                                 A36ServicoSetorId ,
                                                 A41GestaoServicoPrioridade ,
                                                 A42GestaoServicoStatus ,
                                                 A39GestaoServicoDtHora ,
                                                 AV31GestaoServicoDataInicio ,
                                                 AV30GestaoServicoDataConclusao ,
                                                 A77ServicoEmpresaId ,
                                                 AV56ServicoEmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P008E3 */
            pr_default.execute(1, new Object[] {AV31GestaoServicoDataInicio, AV30GestaoServicoDataConclusao, AV56ServicoEmpresaId, AV54ServicoClienteId, AV61ServicoSetorId, AV42GestaoServicoPrioridade, AV43GestaoServicoStatus});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A77ServicoEmpresaId = P008E3_A77ServicoEmpresaId[0];
               A42GestaoServicoStatus = P008E3_A42GestaoServicoStatus[0];
               A41GestaoServicoPrioridade = P008E3_A41GestaoServicoPrioridade[0];
               A36ServicoSetorId = P008E3_A36ServicoSetorId[0];
               A34ServicoClienteId = P008E3_A34ServicoClienteId[0];
               A39GestaoServicoDtHora = P008E3_A39GestaoServicoDtHora[0];
               A38GestaoServicoId = P008E3_A38GestaoServicoId[0];
               A79GestaoServicoNumero = P008E3_A79GestaoServicoNumero[0];
               AV82GestaoServicoIdCollection.Add(A38GestaoServicoId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV94GXV1 = 1;
            while ( AV94GXV1 <= AV82GestaoServicoIdCollection.Count )
            {
               AV37GestaoServicoId = (long)(AV82GestaoServicoIdCollection.GetNumeric(AV94GXV1));
               /* Execute user subroutine: 'VERIFICATIPOSERVICO' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'VERIFICAEXECUTANTE' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV83IsExisteTipoServico ) && ( AV84IsExisteExecutante ) )
               {
                  /* Using cursor P008E4 */
                  pr_default.execute(2, new Object[] {AV37GestaoServicoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A36ServicoSetorId = P008E4_A36ServicoSetorId[0];
                     A38GestaoServicoId = P008E4_A38GestaoServicoId[0];
                     A79GestaoServicoNumero = P008E4_A79GestaoServicoNumero[0];
                     A40GestaoServicoDescricao = P008E4_A40GestaoServicoDescricao[0];
                     A35ServicoClienteNome = P008E4_A35ServicoClienteNome[0];
                     A37ServicoSetorNome = P008E4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008E4_A54ServicoNaturezaNome[0];
                     A41GestaoServicoPrioridade = P008E4_A41GestaoServicoPrioridade[0];
                     A42GestaoServicoStatus = P008E4_A42GestaoServicoStatus[0];
                     A43GestaoServicoDtProgramada = P008E4_A43GestaoServicoDtProgramada[0];
                     A39GestaoServicoDtHora = P008E4_A39GestaoServicoDtHora[0];
                     A157GestaoServicoPrecificacao = P008E4_A157GestaoServicoPrecificacao[0];
                     A53ServicoNaturezaId = P008E4_A53ServicoNaturezaId[0];
                     n53ServicoNaturezaId = P008E4_n53ServicoNaturezaId[0];
                     A129EnderecoId = P008E4_A129EnderecoId[0];
                     n129EnderecoId = P008E4_n129EnderecoId[0];
                     A322GestaoServicoTipoDemanda = P008E4_A322GestaoServicoTipoDemanda[0];
                     A34ServicoClienteId = P008E4_A34ServicoClienteId[0];
                     A37ServicoSetorNome = P008E4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008E4_A54ServicoNaturezaNome[0];
                     A35ServicoClienteNome = P008E4_A35ServicoClienteNome[0];
                     AV38GestaoServicoNumero = A79GestaoServicoNumero;
                     AV32GestaoServicoDescricao = A40GestaoServicoDescricao;
                     AV55ServicoClienteNome = A35ServicoClienteNome;
                     AV62ServicoSetorNome = A37ServicoSetorNome;
                     AV60ServicoNaturezaNome = A54ServicoNaturezaNome;
                     AV11AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
                     AV12AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
                     AV34GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
                     AV33GestaoServicoDtHora = A39GestaoServicoDtHora;
                     AV40GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
                     AV41GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
                     AV59ServicoNaturezaId = A53ServicoNaturezaId;
                     AV21EnderecoId = A129EnderecoId;
                     AV67TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
                     AV85AuxServicoClienteId = A34ServicoClienteId;
                     AV86StatusServico = A42GestaoServicoStatus;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P008E5 */
                  pr_default.execute(3, new Object[] {AV85AuxServicoClienteId, AV21EnderecoId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A106ClienteEnderecoId = P008E5_A106ClienteEnderecoId[0];
                     A17ClienteId = P008E5_A17ClienteId[0];
                     A107ClienteEnderecoLocal = P008E5_A107ClienteEnderecoLocal[0];
                     AV22EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  H8E0( false, 184) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Descricao, "")), 110, Gx_line+67, 343, Gx_line+100, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpresaNome, "")), 550, Gx_line+33, 767, Gx_line+48, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(533, Gx_line+17, 775, Gx_line+150, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Nº da OS:", ""), 550, Gx_line+67, 625, Gx_line+85, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 617, Gx_line+69, 709, Gx_line+84, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Abertura:", ""), 550, Gx_line+83, 617, Gx_line+101, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV33GestaoServicoDtHora, "99/99/9999 99:99:99"), 610, Gx_line+84, 710, Gx_line+101, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 550, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12AuxGestaoServicoStatus, "")), 597, Gx_line+119, 739, Gx_line+134, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Programada para:", ""), 550, Gx_line+100, 675, Gx_line+118, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV34GestaoServicoDtProgramada, "99/99/99"), 661, Gx_line+102, 753, Gx_line+117, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+184);
                  H8E0( false, 151) ;
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
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55ServicoClienteNome, "")), 89, Gx_line+18, 306, Gx_line+33, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62ServicoSetorNome, "")), 86, Gx_line+51, 244, Gx_line+66, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EnderecoLocal, "")), 111, Gx_line+34, 311, Gx_line+49, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11AuxGestaoServicoPrioridade, "")), 478, Gx_line+18, 695, Gx_line+33, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 400, Gx_line+17, 500, Gx_line+35, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(392, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TipoDemandaVarChar, "")), 521, Gx_line+51, 663, Gx_line+66, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo de Demanda:", ""), 400, Gx_line+50, 533, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32GestaoServicoDescricao, "")), 111, Gx_line+68, 675, Gx_line+83, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41GestaoServicoPrecificacaoVarChar, "")), 486, Gx_line+35, 653, Gx_line+50, 0, 0, 0, 0) ;
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
                  /* Using cursor P008E6 */
                  pr_default.execute(4, new Object[] {AV37GestaoServicoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A38GestaoServicoId = P008E6_A38GestaoServicoId[0];
                     A326TipoServicoNome = P008E6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008E6_A329TipoServicoEstimado[0];
                     A325TipoServicoId = P008E6_A325TipoServicoId[0];
                     A323GestaoServicoTipoId = P008E6_A323GestaoServicoTipoId[0];
                     A326TipoServicoNome = P008E6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008E6_A329TipoServicoEstimado[0];
                     AV60ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
                     AV65TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
                     AV90TerminoDateTime = DateTimeUtil.ResetTime( AV34GestaoServicoDtProgramada ) ;
                     AV66TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV90TerminoDateTime, 3600*(A329TipoServicoEstimado)));
                     AV88NaturezaIdCollection.Add(A325TipoServicoId, 0);
                     H8E0( false, 18) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60ServicoNaturezaNome, "")), 33, Gx_line+1, 191, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TempoEstimado, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV66TerminoDate, "99/99/99"), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  if ( AV53PerfilUsuario != 4 )
                  {
                     if ( AV40GestaoServicoPrecificacao == 2 )
                     {
                        H8E0( false, 51) ;
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
                        AV98GXV2 = 1;
                        while ( AV98GXV2 <= AV88NaturezaIdCollection.Count )
                        {
                           AV89NaturezaId = (long)(AV88NaturezaIdCollection.GetNumeric(AV98GXV2));
                           /* Using cursor P008E7 */
                           pr_default.execute(5, new Object[] {AV89NaturezaId});
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A25NaturezaId = P008E7_A25NaturezaId[0];
                              A26NaturezaNome = P008E7_A26NaturezaNome[0];
                              A162NaturezaValor = P008E7_A162NaturezaValor[0];
                              A289NaturezaCusto = P008E7_A289NaturezaCusto[0];
                              AV69TipoServicoNome = StringUtil.Trim( A26NaturezaNome);
                              AV50NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                              AV49NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                              AV70Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                              AV71TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV70Total, 18, 2));
                              H8E0( false, 17) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49NaturezaCustoVarChar, "")), 492, Gx_line+1, 650, Gx_line+16, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50NaturezaValorVarChar, "")), 258, Gx_line+1, 416, Gx_line+16, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(483, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TipoServicoNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(5);
                           AV98GXV2 = (int)(AV98GXV2+1);
                        }
                        H8E0( false, 35) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TotalVarChar, "")), 592, Gx_line+18, 750, Gx_line+33, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+17, 550, Gx_line+35, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(483, Gx_line+17, 777, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(483, Gx_line+17, 583, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+35);
                     }
                     else
                     {
                        if ( AV40GestaoServicoPrecificacao == 1 )
                        {
                           H8E0( false, 68) ;
                           getPrinter().GxDrawRect(567, Gx_line+50, 684, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 692, Gx_line+50, 750, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+50, 650, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(483, Gx_line+50, 583, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(367, Gx_line+50, 492, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+50, 467, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+50, 358, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+50, 550, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+50, 283, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(283, Gx_line+50, 391, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+33, 441, Gx_line+51, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(200, Gx_line+50, 300, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(17, Gx_line+50, 192, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(17, Gx_line+50, 775, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(17, Gx_line+33, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+68);
                           /* Using cursor P008E8 */
                           pr_default.execute(6, new Object[] {AV37GestaoServicoId});
                           while ( (pr_default.getStatus(6) != 101) )
                           {
                              A38GestaoServicoId = P008E8_A38GestaoServicoId[0];
                              A55ServicoExecutanteId = P008E8_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008E8_n55ServicoExecutanteId[0];
                              A131GestaoServicoExecutanteId = P008E8_A131GestaoServicoExecutanteId[0];
                              AV57ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                              pr_default.readNext(6);
                           }
                           pr_default.close(6);
                           AV101GXV3 = 1;
                           while ( AV101GXV3 <= AV57ServicoExecutanteIdCollection.Count )
                           {
                              AV8ServicoExecutanteId = (long)(AV57ServicoExecutanteIdCollection.GetNumeric(AV101GXV3));
                              /* Using cursor P008E9 */
                              pr_default.execute(7, new Object[] {AV8ServicoExecutanteId});
                              while ( (pr_default.getStatus(7) != 101) )
                              {
                                 A9UsuarioId = P008E9_A9UsuarioId[0];
                                 A173UsuarioFuncaoId = P008E9_A173UsuarioFuncaoId[0];
                                 n173UsuarioFuncaoId = P008E9_n173UsuarioFuncaoId[0];
                                 A10UsuarioNome = P008E9_A10UsuarioNome[0];
                                 AV74UsuarioFuncaoId = A173UsuarioFuncaoId;
                                 AV64TecnicoNome = StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(7);
                              /* Using cursor P008E10 */
                              pr_default.execute(8, new Object[] {AV74UsuarioFuncaoId});
                              while ( (pr_default.getStatus(8) != 101) )
                              {
                                 A163FuncaoId = P008E10_A163FuncaoId[0];
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(8);
                              H8E0( false, 17) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FuncaoDiaria, "")), 692, Gx_line+0, 767, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27FuncaoNoturno, "")), 592, Gx_line+0, 675, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25FuncaoHr50, "")), 308, Gx_line+0, 391, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TecnicoNome, "")), 25, Gx_line+0, 200, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 200, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(683, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              AV101GXV3 = (int)(AV101GXV3+1);
                           }
                        }
                     }
                  }
                  if ( AV86StatusServico != 1 )
                  {
                     H8E0( false, 68) ;
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
                  }
                  AV104GXLvl112 = 0;
                  /* Using cursor P008E11 */
                  pr_default.execute(9, new Object[] {AV37GestaoServicoId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A133OrdemExecutanteUsuarioId = P008E11_A133OrdemExecutanteUsuarioId[0];
                     A145OrdemGestaoServicoId = P008E11_A145OrdemGestaoServicoId[0];
                     A134OrdemExecutanteUsuarioNome = P008E11_A134OrdemExecutanteUsuarioNome[0];
                     A137OrdemExecutanteHrInicio = P008E11_A137OrdemExecutanteHrInicio[0];
                     A136OrdemExecutanteDtInicio = P008E11_A136OrdemExecutanteDtInicio[0];
                     A139OrdemExecutanteHrConclusao = P008E11_A139OrdemExecutanteHrConclusao[0];
                     A140OrdemExecutanteComentario = P008E11_A140OrdemExecutanteComentario[0];
                     A142OrdemExecutanteValor = P008E11_A142OrdemExecutanteValor[0];
                     A135OrdemExecutanteId = P008E11_A135OrdemExecutanteId[0];
                     A134OrdemExecutanteUsuarioNome = P008E11_A134OrdemExecutanteUsuarioNome[0];
                     AV104GXLvl112 = 1;
                     AV58ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                     AV76Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                     AV77Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                     AV29GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                     if ( AV53PerfilUsuario != 4 )
                     {
                        AV44GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                     }
                     H8E0( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58ServicoExecutanteNome, "")), 25, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(617, Gx_line+0, 667, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29GestaoServicoComentario, "")), 425, Gx_line+0, 650, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44GestaoServicoValor, "")), 675, Gx_line+0, 767, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  if ( AV104GXLvl112 == 0 )
                  {
                     /* Using cursor P008E12 */
                     pr_default.execute(10, new Object[] {AV37GestaoServicoId});
                     while ( (pr_default.getStatus(10) != 101) )
                     {
                        A55ServicoExecutanteId = P008E12_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P008E12_n55ServicoExecutanteId[0];
                        A38GestaoServicoId = P008E12_A38GestaoServicoId[0];
                        A56ServicoExecutanteNome = P008E12_A56ServicoExecutanteNome[0];
                        A131GestaoServicoExecutanteId = P008E12_A131GestaoServicoExecutanteId[0];
                        A56ServicoExecutanteNome = P008E12_A56ServicoExecutanteNome[0];
                        AV58ServicoExecutanteNome = A56ServicoExecutanteNome;
                        H8E0( false, 17) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58ServicoExecutanteNome, "")), 25, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(617, Gx_line+0, 667, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29GestaoServicoComentario, "")), 425, Gx_line+0, 650, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44GestaoServicoValor, "")), 675, Gx_line+0, 767, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        pr_default.readNext(10);
                     }
                     pr_default.close(10);
                  }
                  H8E0( false, 272) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 500, Gx_line+183, 635, Gx_line+197, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 183, Gx_line+183, 287, Gx_line+197, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(450, Gx_line+167, 700, Gx_line+167, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(117, Gx_line+167, 367, Gx_line+167, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+272);
                  /* Eject command */
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(P_lines+1);
                  AV57ServicoExecutanteIdCollection.Clear();
                  AV88NaturezaIdCollection.Clear();
               }
               AV94GXV1 = (int)(AV94GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8E0( true, 0) ;
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

      protected void S111( )
      {
         /* 'VERIFICATIPOSERVICO' Routine */
         returnInSub = false;
         AV107GXLvl141 = 0;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              A325TipoServicoId ,
                                              AV78ServicoNaturezaIdCollection ,
                                              AV78ServicoNaturezaIdCollection.Count ,
                                              AV37GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008E13 */
         pr_default.execute(11, new Object[] {AV37GestaoServicoId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A325TipoServicoId = P008E13_A325TipoServicoId[0];
            A38GestaoServicoId = P008E13_A38GestaoServicoId[0];
            A323GestaoServicoTipoId = P008E13_A323GestaoServicoTipoId[0];
            AV107GXLvl141 = 1;
            AV83IsExisteTipoServico = true;
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( AV107GXLvl141 == 0 )
         {
            AV83IsExisteTipoServico = false;
         }
      }

      protected void S121( )
      {
         /* 'VERIFICAEXECUTANTE' Routine */
         returnInSub = false;
         AV108GXLvl151 = 0;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              A55ServicoExecutanteId ,
                                              AV81ExecutanteIdCollection ,
                                              AV81ExecutanteIdCollection.Count ,
                                              AV37GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008E14 */
         pr_default.execute(12, new Object[] {AV37GestaoServicoId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A55ServicoExecutanteId = P008E14_A55ServicoExecutanteId[0];
            n55ServicoExecutanteId = P008E14_n55ServicoExecutanteId[0];
            A38GestaoServicoId = P008E14_A38GestaoServicoId[0];
            A131GestaoServicoExecutanteId = P008E14_A131GestaoServicoExecutanteId[0];
            AV108GXLvl151 = 1;
            AV84IsExisteExecutante = true;
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( AV108GXLvl151 == 0 )
         {
            AV84IsExisteExecutante = false;
         }
      }

      protected void H8E0( bool bFoot ,
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
         AV14DateTime = (DateTime)(DateTime.MinValue);
         AV81ExecutanteIdCollection = new GxSimpleCollection<long>();
         AV78ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P008E2_A1EmpresaId = new long[1] ;
         P008E2_A2EmpresaNome = new string[] {""} ;
         P008E2_A3EmpresaCNPJ = new string[] {""} ;
         P008E2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV15Descricao = "";
         AV20EmpresaNome = "";
         AV16EmpresaCNPJ = "";
         AV18EmpresaFotoUrl = "";
         AV72Url = "";
         AV92Empresafoto_GXI = "";
         AV17EmpresaFoto = "";
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         P008E3_A77ServicoEmpresaId = new long[1] ;
         P008E3_A42GestaoServicoStatus = new short[1] ;
         P008E3_A41GestaoServicoPrioridade = new short[1] ;
         P008E3_A36ServicoSetorId = new long[1] ;
         P008E3_A34ServicoClienteId = new long[1] ;
         P008E3_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008E3_A38GestaoServicoId = new long[1] ;
         P008E3_A79GestaoServicoNumero = new long[1] ;
         AV82GestaoServicoIdCollection = new GxSimpleCollection<long>();
         P008E4_A36ServicoSetorId = new long[1] ;
         P008E4_A38GestaoServicoId = new long[1] ;
         P008E4_A79GestaoServicoNumero = new long[1] ;
         P008E4_A40GestaoServicoDescricao = new string[] {""} ;
         P008E4_A35ServicoClienteNome = new string[] {""} ;
         P008E4_A37ServicoSetorNome = new string[] {""} ;
         P008E4_A54ServicoNaturezaNome = new string[] {""} ;
         P008E4_A41GestaoServicoPrioridade = new short[1] ;
         P008E4_A42GestaoServicoStatus = new short[1] ;
         P008E4_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P008E4_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008E4_A157GestaoServicoPrecificacao = new short[1] ;
         P008E4_A53ServicoNaturezaId = new long[1] ;
         P008E4_n53ServicoNaturezaId = new bool[] {false} ;
         P008E4_A129EnderecoId = new long[1] ;
         P008E4_n129EnderecoId = new bool[] {false} ;
         P008E4_A322GestaoServicoTipoDemanda = new short[1] ;
         P008E4_A34ServicoClienteId = new long[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         AV32GestaoServicoDescricao = "";
         AV55ServicoClienteNome = "";
         AV62ServicoSetorNome = "";
         AV60ServicoNaturezaNome = "";
         AV11AuxGestaoServicoPrioridade = "";
         AV12AuxGestaoServicoStatus = "";
         AV34GestaoServicoDtProgramada = DateTime.MinValue;
         AV33GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV41GestaoServicoPrecificacaoVarChar = "";
         AV67TipoDemandaVarChar = "";
         P008E5_A106ClienteEnderecoId = new long[1] ;
         P008E5_A17ClienteId = new long[1] ;
         P008E5_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV22EnderecoLocal = "";
         P008E6_A38GestaoServicoId = new long[1] ;
         P008E6_A326TipoServicoNome = new string[] {""} ;
         P008E6_A329TipoServicoEstimado = new short[1] ;
         P008E6_A325TipoServicoId = new long[1] ;
         P008E6_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV65TempoEstimado = "";
         AV90TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV66TerminoDate = DateTime.MinValue;
         AV88NaturezaIdCollection = new GxSimpleCollection<long>();
         P008E7_A25NaturezaId = new long[1] ;
         P008E7_A26NaturezaNome = new string[] {""} ;
         P008E7_A162NaturezaValor = new decimal[1] ;
         P008E7_A289NaturezaCusto = new decimal[1] ;
         A26NaturezaNome = "";
         AV69TipoServicoNome = "";
         AV50NaturezaValorVarChar = "";
         AV49NaturezaCustoVarChar = "";
         AV71TotalVarChar = "";
         P008E8_A38GestaoServicoId = new long[1] ;
         P008E8_A55ServicoExecutanteId = new long[1] ;
         P008E8_n55ServicoExecutanteId = new bool[] {false} ;
         P008E8_A131GestaoServicoExecutanteId = new long[1] ;
         AV57ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P008E9_A9UsuarioId = new long[1] ;
         P008E9_A173UsuarioFuncaoId = new long[1] ;
         P008E9_n173UsuarioFuncaoId = new bool[] {false} ;
         P008E9_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV64TecnicoNome = "";
         P008E10_A163FuncaoId = new long[1] ;
         AV23FuncaoDiaria = "";
         AV28FuncaoViagem = "";
         AV27FuncaoNoturno = "";
         AV24FuncaoHr100 = "";
         AV25FuncaoHr50 = "";
         AV26FuncaoHrNormal = "";
         P008E11_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008E11_A145OrdemGestaoServicoId = new long[1] ;
         P008E11_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008E11_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008E11_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008E11_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008E11_A140OrdemExecutanteComentario = new string[] {""} ;
         P008E11_A142OrdemExecutanteValor = new decimal[1] ;
         P008E11_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV58ServicoExecutanteNome = "";
         AV76Inicio = "";
         AV77Termino = "";
         AV29GestaoServicoComentario = "";
         AV44GestaoServicoValor = "";
         P008E12_A55ServicoExecutanteId = new long[1] ;
         P008E12_n55ServicoExecutanteId = new bool[] {false} ;
         P008E12_A38GestaoServicoId = new long[1] ;
         P008E12_A56ServicoExecutanteNome = new string[] {""} ;
         P008E12_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         P008E13_A325TipoServicoId = new long[1] ;
         P008E13_A38GestaoServicoId = new long[1] ;
         P008E13_A323GestaoServicoTipoId = new long[1] ;
         P008E14_A55ServicoExecutanteId = new long[1] ;
         P008E14_n55ServicoExecutanteId = new bool[] {false} ;
         P008E14_A38GestaoServicoId = new long[1] ;
         P008E14_A131GestaoServicoExecutanteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatorioosmodelo2__default(),
            new Object[][] {
                new Object[] {
               P008E2_A1EmpresaId, P008E2_A2EmpresaNome, P008E2_A3EmpresaCNPJ, P008E2_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P008E3_A77ServicoEmpresaId, P008E3_A42GestaoServicoStatus, P008E3_A41GestaoServicoPrioridade, P008E3_A36ServicoSetorId, P008E3_A34ServicoClienteId, P008E3_A39GestaoServicoDtHora, P008E3_A38GestaoServicoId, P008E3_A79GestaoServicoNumero
               }
               , new Object[] {
               P008E4_A36ServicoSetorId, P008E4_A38GestaoServicoId, P008E4_A79GestaoServicoNumero, P008E4_A40GestaoServicoDescricao, P008E4_A35ServicoClienteNome, P008E4_A37ServicoSetorNome, P008E4_A54ServicoNaturezaNome, P008E4_A41GestaoServicoPrioridade, P008E4_A42GestaoServicoStatus, P008E4_A43GestaoServicoDtProgramada,
               P008E4_A39GestaoServicoDtHora, P008E4_A157GestaoServicoPrecificacao, P008E4_A53ServicoNaturezaId, P008E4_n53ServicoNaturezaId, P008E4_A129EnderecoId, P008E4_n129EnderecoId, P008E4_A322GestaoServicoTipoDemanda, P008E4_A34ServicoClienteId
               }
               , new Object[] {
               P008E5_A106ClienteEnderecoId, P008E5_A17ClienteId, P008E5_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P008E6_A38GestaoServicoId, P008E6_A326TipoServicoNome, P008E6_A329TipoServicoEstimado, P008E6_A325TipoServicoId, P008E6_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008E7_A25NaturezaId, P008E7_A26NaturezaNome, P008E7_A162NaturezaValor, P008E7_A289NaturezaCusto
               }
               , new Object[] {
               P008E8_A38GestaoServicoId, P008E8_A55ServicoExecutanteId, P008E8_n55ServicoExecutanteId, P008E8_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008E9_A9UsuarioId, P008E9_A173UsuarioFuncaoId, P008E9_n173UsuarioFuncaoId, P008E9_A10UsuarioNome
               }
               , new Object[] {
               P008E10_A163FuncaoId
               }
               , new Object[] {
               P008E11_A133OrdemExecutanteUsuarioId, P008E11_A145OrdemGestaoServicoId, P008E11_A134OrdemExecutanteUsuarioNome, P008E11_A137OrdemExecutanteHrInicio, P008E11_A136OrdemExecutanteDtInicio, P008E11_A139OrdemExecutanteHrConclusao, P008E11_A140OrdemExecutanteComentario, P008E11_A142OrdemExecutanteValor, P008E11_A135OrdemExecutanteId
               }
               , new Object[] {
               P008E12_A55ServicoExecutanteId, P008E12_n55ServicoExecutanteId, P008E12_A38GestaoServicoId, P008E12_A56ServicoExecutanteNome, P008E12_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008E13_A325TipoServicoId, P008E13_A38GestaoServicoId, P008E13_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008E14_A55ServicoExecutanteId, P008E14_n55ServicoExecutanteId, P008E14_A38GestaoServicoId, P008E14_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV42GestaoServicoPrioridade ;
      private short AV43GestaoServicoStatus ;
      private short AV53PerfilUsuario ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short AV40GestaoServicoPrecificacao ;
      private short AV86StatusServico ;
      private short A329TipoServicoEstimado ;
      private short AV104GXLvl112 ;
      private short AV107GXLvl141 ;
      private short AV108GXLvl151 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV94GXV1 ;
      private int Gx_OldLine ;
      private int AV98GXV2 ;
      private int AV101GXV3 ;
      private int AV78ServicoNaturezaIdCollection_Count ;
      private int AV81ExecutanteIdCollection_Count ;
      private long AV75UsuarioId ;
      private long AV56ServicoEmpresaId ;
      private long AV54ServicoClienteId ;
      private long AV61ServicoSetorId ;
      private long A1EmpresaId ;
      private long A34ServicoClienteId ;
      private long A36ServicoSetorId ;
      private long A77ServicoEmpresaId ;
      private long A38GestaoServicoId ;
      private long A79GestaoServicoNumero ;
      private long AV37GestaoServicoId ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long AV38GestaoServicoNumero ;
      private long AV59ServicoNaturezaId ;
      private long AV21EnderecoId ;
      private long AV85AuxServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long AV89NaturezaId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV8ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV74UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV70Total ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV20EmpresaNome ;
      private string AV16EmpresaCNPJ ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV55ServicoClienteNome ;
      private string AV62ServicoSetorNome ;
      private string AV60ServicoNaturezaNome ;
      private string AV11AuxGestaoServicoPrioridade ;
      private string AV12AuxGestaoServicoStatus ;
      private string A107ClienteEnderecoLocal ;
      private string AV22EnderecoLocal ;
      private string A326TipoServicoNome ;
      private string A26NaturezaNome ;
      private string AV69TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV64TecnicoNome ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV58ServicoExecutanteNome ;
      private string AV76Inicio ;
      private string AV77Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV14DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV33GestaoServicoDtHora ;
      private DateTime AV90TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime AV31GestaoServicoDataInicio ;
      private DateTime AV30GestaoServicoDataConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV34GestaoServicoDtProgramada ;
      private DateTime AV66TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV83IsExisteTipoServico ;
      private bool AV84IsExisteExecutante ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string AV79TecnicoLongVarChar ;
      private string AV80NaturezaLongVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV15Descricao ;
      private string AV18EmpresaFotoUrl ;
      private string AV72Url ;
      private string AV92Empresafoto_GXI ;
      private string A40GestaoServicoDescricao ;
      private string AV32GestaoServicoDescricao ;
      private string AV41GestaoServicoPrecificacaoVarChar ;
      private string AV67TipoDemandaVarChar ;
      private string AV65TempoEstimado ;
      private string AV50NaturezaValorVarChar ;
      private string AV49NaturezaCustoVarChar ;
      private string AV71TotalVarChar ;
      private string AV23FuncaoDiaria ;
      private string AV28FuncaoViagem ;
      private string AV27FuncaoNoturno ;
      private string AV24FuncaoHr100 ;
      private string AV25FuncaoHr50 ;
      private string AV26FuncaoHrNormal ;
      private string A140OrdemExecutanteComentario ;
      private string AV29GestaoServicoComentario ;
      private string AV44GestaoServicoValor ;
      private string AV17EmpresaFoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV81ExecutanteIdCollection ;
      private GxSimpleCollection<long> AV78ServicoNaturezaIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P008E2_A1EmpresaId ;
      private string[] P008E2_A2EmpresaNome ;
      private string[] P008E2_A3EmpresaCNPJ ;
      private string[] P008E2_A40000EmpresaFoto_GXI ;
      private long[] P008E3_A77ServicoEmpresaId ;
      private short[] P008E3_A42GestaoServicoStatus ;
      private short[] P008E3_A41GestaoServicoPrioridade ;
      private long[] P008E3_A36ServicoSetorId ;
      private long[] P008E3_A34ServicoClienteId ;
      private DateTime[] P008E3_A39GestaoServicoDtHora ;
      private long[] P008E3_A38GestaoServicoId ;
      private long[] P008E3_A79GestaoServicoNumero ;
      private GxSimpleCollection<long> AV82GestaoServicoIdCollection ;
      private long[] P008E4_A36ServicoSetorId ;
      private long[] P008E4_A38GestaoServicoId ;
      private long[] P008E4_A79GestaoServicoNumero ;
      private string[] P008E4_A40GestaoServicoDescricao ;
      private string[] P008E4_A35ServicoClienteNome ;
      private string[] P008E4_A37ServicoSetorNome ;
      private string[] P008E4_A54ServicoNaturezaNome ;
      private short[] P008E4_A41GestaoServicoPrioridade ;
      private short[] P008E4_A42GestaoServicoStatus ;
      private DateTime[] P008E4_A43GestaoServicoDtProgramada ;
      private DateTime[] P008E4_A39GestaoServicoDtHora ;
      private short[] P008E4_A157GestaoServicoPrecificacao ;
      private long[] P008E4_A53ServicoNaturezaId ;
      private bool[] P008E4_n53ServicoNaturezaId ;
      private long[] P008E4_A129EnderecoId ;
      private bool[] P008E4_n129EnderecoId ;
      private short[] P008E4_A322GestaoServicoTipoDemanda ;
      private long[] P008E4_A34ServicoClienteId ;
      private long[] P008E5_A106ClienteEnderecoId ;
      private long[] P008E5_A17ClienteId ;
      private string[] P008E5_A107ClienteEnderecoLocal ;
      private long[] P008E6_A38GestaoServicoId ;
      private string[] P008E6_A326TipoServicoNome ;
      private short[] P008E6_A329TipoServicoEstimado ;
      private long[] P008E6_A325TipoServicoId ;
      private long[] P008E6_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV88NaturezaIdCollection ;
      private long[] P008E7_A25NaturezaId ;
      private string[] P008E7_A26NaturezaNome ;
      private decimal[] P008E7_A162NaturezaValor ;
      private decimal[] P008E7_A289NaturezaCusto ;
      private long[] P008E8_A38GestaoServicoId ;
      private long[] P008E8_A55ServicoExecutanteId ;
      private bool[] P008E8_n55ServicoExecutanteId ;
      private long[] P008E8_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV57ServicoExecutanteIdCollection ;
      private long[] P008E9_A9UsuarioId ;
      private long[] P008E9_A173UsuarioFuncaoId ;
      private bool[] P008E9_n173UsuarioFuncaoId ;
      private string[] P008E9_A10UsuarioNome ;
      private long[] P008E10_A163FuncaoId ;
      private long[] P008E11_A133OrdemExecutanteUsuarioId ;
      private long[] P008E11_A145OrdemGestaoServicoId ;
      private string[] P008E11_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008E11_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008E11_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008E11_A139OrdemExecutanteHrConclusao ;
      private string[] P008E11_A140OrdemExecutanteComentario ;
      private decimal[] P008E11_A142OrdemExecutanteValor ;
      private long[] P008E11_A135OrdemExecutanteId ;
      private long[] P008E12_A55ServicoExecutanteId ;
      private bool[] P008E12_n55ServicoExecutanteId ;
      private long[] P008E12_A38GestaoServicoId ;
      private string[] P008E12_A56ServicoExecutanteNome ;
      private long[] P008E12_A131GestaoServicoExecutanteId ;
      private long[] P008E13_A325TipoServicoId ;
      private long[] P008E13_A38GestaoServicoId ;
      private long[] P008E13_A323GestaoServicoTipoId ;
      private long[] P008E14_A55ServicoExecutanteId ;
      private bool[] P008E14_n55ServicoExecutanteId ;
      private long[] P008E14_A38GestaoServicoId ;
      private long[] P008E14_A131GestaoServicoExecutanteId ;
   }

   public class aprcrelatorioosmodelo2__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008E3( IGxContext context ,
                                             long AV54ServicoClienteId ,
                                             long AV61ServicoSetorId ,
                                             short AV42GestaoServicoPrioridade ,
                                             short AV43GestaoServicoStatus ,
                                             long A34ServicoClienteId ,
                                             long A36ServicoSetorId ,
                                             short A41GestaoServicoPrioridade ,
                                             short A42GestaoServicoStatus ,
                                             DateTime A39GestaoServicoDtHora ,
                                             DateTime AV31GestaoServicoDataInicio ,
                                             DateTime AV30GestaoServicoDataConclusao ,
                                             long A77ServicoEmpresaId ,
                                             long AV56ServicoEmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ServicoEmpresaId], [GestaoServicoStatus], [GestaoServicoPrioridade], [ServicoSetorId] AS ServicoSetorId, [ServicoClienteId] AS ServicoClienteId, [GestaoServicoDtHora], [GestaoServicoId], [GestaoServicoNumero] FROM [GestaoServico]";
         AddWhere(sWhereString, "([GestaoServicoDtHora] >= @AV31GestaoServicoDataInicio and [GestaoServicoDtHora] <= @AV30GestaoServicoDataConclusao)");
         AddWhere(sWhereString, "([ServicoEmpresaId] = @AV56ServicoEmpresaId)");
         if ( ! (0==AV54ServicoClienteId) )
         {
            AddWhere(sWhereString, "([ServicoClienteId] = @AV54ServicoClienteId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV61ServicoSetorId) )
         {
            AddWhere(sWhereString, "([ServicoSetorId] = @AV61ServicoSetorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV42GestaoServicoPrioridade) )
         {
            AddWhere(sWhereString, "([GestaoServicoPrioridade] = @AV42GestaoServicoPrioridade)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV43GestaoServicoStatus) )
         {
            AddWhere(sWhereString, "([GestaoServicoStatus] = @AV43GestaoServicoStatus)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoNumero] DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008E13( IGxContext context ,
                                              long A325TipoServicoId ,
                                              GxSimpleCollection<long> AV78ServicoNaturezaIdCollection ,
                                              int AV78ServicoNaturezaIdCollection_Count ,
                                              long AV37GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipoServicoId] AS TipoServicoId, [GestaoServicoId], [GestaoServicoTipoId] FROM [GestaoServicoTipo]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV37GestaoServicoId)");
         if ( ! ( AV78ServicoNaturezaIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78ServicoNaturezaIdCollection, "[TipoServicoId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008E14( IGxContext context ,
                                              long A55ServicoExecutanteId ,
                                              GxSimpleCollection<long> AV81ExecutanteIdCollection ,
                                              int AV81ExecutanteIdCollection_Count ,
                                              long AV37GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV37GestaoServicoId)");
         if ( ! ( AV81ExecutanteIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81ExecutanteIdCollection, "[ServicoExecutanteId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoId]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P008E3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 11 :
                     return conditional_P008E13(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 12 :
                     return conditional_P008E14(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008E2;
          prmP008E2 = new Object[] {
          new ParDef("@AV56ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP008E4;
          prmP008E4 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E5;
          prmP008E5 = new Object[] {
          new ParDef("@AV85AuxServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV21EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E6;
          prmP008E6 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E7;
          prmP008E7 = new Object[] {
          new ParDef("@AV89NaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP008E8;
          prmP008E8 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E9;
          prmP008E9 = new Object[] {
          new ParDef("@AV8ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP008E10;
          prmP008E10 = new Object[] {
          new ParDef("@AV74UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E11;
          prmP008E11 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E12;
          prmP008E12 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E3;
          prmP008E3 = new Object[] {
          new ParDef("@AV31GestaoServicoDataInicio",GXType.Date,8,0) ,
          new ParDef("@AV30GestaoServicoDataConclusao",GXType.Date,8,0) ,
          new ParDef("@AV56ServicoEmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV54ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV61ServicoSetorId",GXType.Decimal,18,0) ,
          new ParDef("@AV42GestaoServicoPrioridade",GXType.Int16,4,0) ,
          new ParDef("@AV43GestaoServicoStatus",GXType.Int16,4,0)
          };
          Object[] prmP008E13;
          prmP008E13 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008E14;
          prmP008E14 = new Object[] {
          new ParDef("@AV37GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008E2", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV56ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E4", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[GestaoServicoTipoDemanda], T1.[ServicoClienteId] AS ServicoClienteId FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV37GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E5", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV85AuxServicoClienteId and [ClienteEnderecoId] = @AV21EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E6", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV37GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E7", "SELECT [NaturezaId], [NaturezaNome], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV89NaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E8", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV37GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E9", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV8ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E10", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV74UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008E11", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV37GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E12", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV37GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E14,100, GxCacheFrequency.OFF ,false,false )
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
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((long[]) buf[12])[0] = rslt.getLong(13);
                ((bool[]) buf[13])[0] = rslt.wasNull(13);
                ((long[]) buf[14])[0] = rslt.getLong(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
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
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
