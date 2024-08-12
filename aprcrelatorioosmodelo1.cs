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
   public class aprcrelatorioosmodelo1 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV54UsuarioId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV23GestaoServicoDataInicio = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataInicio"));
                  AV22GestaoServicoDataConclusao = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataConclusao"));
                  AV43ServicoEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoEmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AV41ServicoClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoClienteId"), "."), 18, MidpointRounding.ToEven));
                  AV48ServicoSetorId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoSetorId"), "."), 18, MidpointRounding.ToEven));
                  AV34GestaoServicoPrioridade = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoPrioridade"), "."), 18, MidpointRounding.ToEven));
                  AV35GestaoServicoStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoStatus"), "."), 18, MidpointRounding.ToEven));
                  AV40PerfilUsuario = (short)(Math.Round(NumberUtil.Val( GetPar( "PerfilUsuario"), "."), 18, MidpointRounding.ToEven));
                  AV84TecnicoLongVarChar = GetPar( "TecnicoLongVarChar");
                  AV85NaturezaLongVarChar = GetPar( "NaturezaLongVarChar");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatorioosmodelo1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatorioosmodelo1( IGxContext context )
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
         this.AV54UsuarioId = aP0_UsuarioId;
         this.AV23GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV22GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV43ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV41ServicoClienteId = aP4_ServicoClienteId;
         this.AV48ServicoSetorId = aP5_ServicoSetorId;
         this.AV34GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV35GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV40PerfilUsuario = aP8_PerfilUsuario;
         this.AV84TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV85NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         this.AV54UsuarioId = aP0_UsuarioId;
         this.AV23GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV22GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV43ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV41ServicoClienteId = aP4_ServicoClienteId;
         this.AV48ServicoSetorId = aP5_ServicoSetorId;
         this.AV34GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV35GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV40PerfilUsuario = aP8_PerfilUsuario;
         this.AV84TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV85NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         setOutputFileName("RelatorioOSM1.pdf");
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
            AV13DateTime = DateTimeUtil.Now( context);
            AV88ExecutanteIdCollection.FromJSonString(AV84TecnicoLongVarChar, null);
            AV86ServicoNaturezaIdCollection.FromJSonString(AV85NaturezaLongVarChar, null);
            /* Using cursor P008C2 */
            pr_default.execute(0, new Object[] {AV43ServicoEmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P008C2_A1EmpresaId[0];
               A2EmpresaNome = P008C2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P008C2_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P008C2_A40000EmpresaFoto_GXI[0];
               AV14Descricao = context.GetMessage( "REGISTRO DE ORDEM DE SERVIÇO", "");
               AV18EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV17EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV53Url = StringUtil.StringReplace( AV17EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV98Empresafoto_GXI = AV53Url;
               AV16EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV41ServicoClienteId ,
                                                 AV48ServicoSetorId ,
                                                 AV34GestaoServicoPrioridade ,
                                                 AV35GestaoServicoStatus ,
                                                 A34ServicoClienteId ,
                                                 A36ServicoSetorId ,
                                                 A41GestaoServicoPrioridade ,
                                                 A42GestaoServicoStatus ,
                                                 A39GestaoServicoDtHora ,
                                                 AV23GestaoServicoDataInicio ,
                                                 AV22GestaoServicoDataConclusao ,
                                                 A77ServicoEmpresaId ,
                                                 AV43ServicoEmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P008C3 */
            pr_default.execute(1, new Object[] {AV23GestaoServicoDataInicio, AV22GestaoServicoDataConclusao, AV43ServicoEmpresaId, AV41ServicoClienteId, AV48ServicoSetorId, AV34GestaoServicoPrioridade, AV35GestaoServicoStatus});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A77ServicoEmpresaId = P008C3_A77ServicoEmpresaId[0];
               A42GestaoServicoStatus = P008C3_A42GestaoServicoStatus[0];
               A41GestaoServicoPrioridade = P008C3_A41GestaoServicoPrioridade[0];
               A36ServicoSetorId = P008C3_A36ServicoSetorId[0];
               A34ServicoClienteId = P008C3_A34ServicoClienteId[0];
               A39GestaoServicoDtHora = P008C3_A39GestaoServicoDtHora[0];
               A38GestaoServicoId = P008C3_A38GestaoServicoId[0];
               A79GestaoServicoNumero = P008C3_A79GestaoServicoNumero[0];
               AV87GestaoServicoIdCollection.Add(A38GestaoServicoId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV100GXV1 = 1;
            while ( AV100GXV1 <= AV87GestaoServicoIdCollection.Count )
            {
               AV29GestaoServicoId = (long)(AV87GestaoServicoIdCollection.GetNumeric(AV100GXV1));
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
               if ( ( AV94IsExisteTipoServico ) && ( AV95IsExisteExecutante ) )
               {
                  /* Using cursor P008C4 */
                  pr_default.execute(2, new Object[] {AV29GestaoServicoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A36ServicoSetorId = P008C4_A36ServicoSetorId[0];
                     A53ServicoNaturezaId = P008C4_A53ServicoNaturezaId[0];
                     n53ServicoNaturezaId = P008C4_n53ServicoNaturezaId[0];
                     A38GestaoServicoId = P008C4_A38GestaoServicoId[0];
                     A79GestaoServicoNumero = P008C4_A79GestaoServicoNumero[0];
                     A40GestaoServicoDescricao = P008C4_A40GestaoServicoDescricao[0];
                     A35ServicoClienteNome = P008C4_A35ServicoClienteNome[0];
                     A37ServicoSetorNome = P008C4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008C4_A54ServicoNaturezaNome[0];
                     A41GestaoServicoPrioridade = P008C4_A41GestaoServicoPrioridade[0];
                     A42GestaoServicoStatus = P008C4_A42GestaoServicoStatus[0];
                     A43GestaoServicoDtProgramada = P008C4_A43GestaoServicoDtProgramada[0];
                     A39GestaoServicoDtHora = P008C4_A39GestaoServicoDtHora[0];
                     A157GestaoServicoPrecificacao = P008C4_A157GestaoServicoPrecificacao[0];
                     A129EnderecoId = P008C4_A129EnderecoId[0];
                     n129EnderecoId = P008C4_n129EnderecoId[0];
                     A322GestaoServicoTipoDemanda = P008C4_A322GestaoServicoTipoDemanda[0];
                     A34ServicoClienteId = P008C4_A34ServicoClienteId[0];
                     A37ServicoSetorNome = P008C4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008C4_A54ServicoNaturezaNome[0];
                     A35ServicoClienteNome = P008C4_A35ServicoClienteNome[0];
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
                     AV19EnderecoId = A129EnderecoId;
                     AV72TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
                     AV89AuxServicoClienteId = A34ServicoClienteId;
                     AV92StatusServico = A42GestaoServicoStatus;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P008C5 */
                  pr_default.execute(3, new Object[] {AV89AuxServicoClienteId, AV19EnderecoId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A106ClienteEnderecoId = P008C5_A106ClienteEnderecoId[0];
                     A17ClienteId = P008C5_A17ClienteId[0];
                     A107ClienteEnderecoLocal = P008C5_A107ClienteEnderecoLocal[0];
                     AV20EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  H8C0( false, 151) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Descricao, "")), 208, Gx_line+0, 558, Gx_line+33, 1, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16EmpresaFoto)) ? AV98Empresafoto_GXI : AV16EmpresaFoto);
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
                  H8C0( false, 259) ;
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
                  /* Using cursor P008C6 */
                  pr_default.execute(4, new Object[] {AV29GestaoServicoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A38GestaoServicoId = P008C6_A38GestaoServicoId[0];
                     A326TipoServicoNome = P008C6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008C6_A329TipoServicoEstimado[0];
                     A325TipoServicoId = P008C6_A325TipoServicoId[0];
                     A323GestaoServicoTipoId = P008C6_A323GestaoServicoTipoId[0];
                     A326TipoServicoNome = P008C6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008C6_A329TipoServicoEstimado[0];
                     AV73ServicoDescricao = context.GetMessage( "SERVIÇO", "");
                     AV47ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
                     AV70TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
                     AV96TerminoDateTime = DateTimeUtil.ResetTime( AV26GestaoServicoDtProgramada ) ;
                     AV69TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV96TerminoDateTime, 3600*(A329TipoServicoEstimado)));
                     AV83NaturezaIdCollection.Add(A325TipoServicoId, 0);
                     H8C0( false, 133) ;
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
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  if ( AV40PerfilUsuario != 4 )
                  {
                     if ( AV32GestaoServicoPrecificacao == 2 )
                     {
                        AV104GXV2 = 1;
                        while ( AV104GXV2 <= AV83NaturezaIdCollection.Count )
                        {
                           AV91NaturezaId = (long)(AV83NaturezaIdCollection.GetNumeric(AV104GXV2));
                           /* Using cursor P008C7 */
                           pr_default.execute(5, new Object[] {AV91NaturezaId});
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A25NaturezaId = P008C7_A25NaturezaId[0];
                              A26NaturezaNome = P008C7_A26NaturezaNome[0];
                              A162NaturezaValor = P008C7_A162NaturezaValor[0];
                              A289NaturezaCusto = P008C7_A289NaturezaCusto[0];
                              AV93NaturezaNome = StringUtil.Trim( A26NaturezaNome);
                              AV39NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                              AV38NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                              AV51Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                              AV52TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV51Total, 18, 2));
                              H8C0( false, 198) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+183, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "Custo:", ""), 142, Gx_line+117, 192, Gx_line+135, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Valor do Serviço:", ""), 142, Gx_line+83, 309, Gx_line+101, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Valor Total:", ""), 142, Gx_line+150, 275, Gx_line+168, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TotalVarChar, "")), 450, Gx_line+150, 608, Gx_line+168, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38NaturezaCustoVarChar, "")), 450, Gx_line+117, 608, Gx_line+135, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39NaturezaValorVarChar, "")), 450, Gx_line+83, 608, Gx_line+101, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 450, Gx_line+38, 0+256, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço:", ""), 142, Gx_line+50, 267, Gx_line+68, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93NaturezaNome, "")), 450, Gx_line+50, 604, Gx_line+67, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+198);
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(5);
                           AV104GXV2 = (int)(AV104GXV2+1);
                        }
                     }
                     else
                     {
                        if ( AV32GestaoServicoPrecificacao == 1 )
                        {
                           /* Using cursor P008C8 */
                           pr_default.execute(6, new Object[] {AV29GestaoServicoId});
                           while ( (pr_default.getStatus(6) != 101) )
                           {
                              A38GestaoServicoId = P008C8_A38GestaoServicoId[0];
                              A55ServicoExecutanteId = P008C8_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008C8_n55ServicoExecutanteId[0];
                              A131GestaoServicoExecutanteId = P008C8_A131GestaoServicoExecutanteId[0];
                              AV44ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                              pr_default.readNext(6);
                           }
                           pr_default.close(6);
                           AV107GXV3 = 1;
                           while ( AV107GXV3 <= AV44ServicoExecutanteIdCollection.Count )
                           {
                              AV74ServicoExecutanteId = (long)(AV44ServicoExecutanteIdCollection.GetNumeric(AV107GXV3));
                              /* Using cursor P008C9 */
                              pr_default.execute(7, new Object[] {AV74ServicoExecutanteId});
                              while ( (pr_default.getStatus(7) != 101) )
                              {
                                 A9UsuarioId = P008C9_A9UsuarioId[0];
                                 A173UsuarioFuncaoId = P008C9_A173UsuarioFuncaoId[0];
                                 n173UsuarioFuncaoId = P008C9_n173UsuarioFuncaoId[0];
                                 A10UsuarioNome = P008C9_A10UsuarioNome[0];
                                 AV62UsuarioFuncaoId = A173UsuarioFuncaoId;
                                 AV64OrcamentoTipoHH = context.GetMessage( "ORÇAMENTO - ", "") + StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(7);
                              /* Using cursor P008C10 */
                              pr_default.execute(8, new Object[] {AV62UsuarioFuncaoId});
                              while ( (pr_default.getStatus(8) != 101) )
                              {
                                 A163FuncaoId = P008C10_A163FuncaoId[0];
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(8);
                              H8C0( false, 257) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+183, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.GetMessage( "Hr 100%:", ""), 142, Gx_line+133, 217, Gx_line+151, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Hr Normal:", ""), 142, Gx_line+67, 225, Gx_line+85, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Hr 50%:", ""), 142, Gx_line+100, 209, Gx_line+118, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Diária:", ""), 450, Gx_line+133, 508, Gx_line+151, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Viagem:", ""), 450, Gx_line+67, 517, Gx_line+85, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.GetMessage( "Noturno:", ""), 450, Gx_line+100, 517, Gx_line+118, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FuncaoDiaria, "")), 500, Gx_line+133, 658, Gx_line+151, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FuncaoViagem, "")), 508, Gx_line+67, 666, Gx_line+85, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FuncaoNoturno, "")), 517, Gx_line+100, 675, Gx_line+118, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FuncaoHr100, "")), 208, Gx_line+133, 366, Gx_line+151, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FuncaoHr50, "")), 200, Gx_line+100, 358, Gx_line+118, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55FuncaoHrNormal, "")), 217, Gx_line+67, 375, Gx_line+85, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 13, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64OrcamentoTipoHH, "")), 176, Gx_line+17, 593, Gx_line+50, 1, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+257);
                              AV107GXV3 = (int)(AV107GXV3+1);
                           }
                        }
                     }
                  }
                  if ( AV92StatusServico != 1 )
                  {
                     H8C0( false, 85) ;
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
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+85);
                  }
                  AV110GXLvl110 = 0;
                  /* Using cursor P008C11 */
                  pr_default.execute(9, new Object[] {AV29GestaoServicoId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A133OrdemExecutanteUsuarioId = P008C11_A133OrdemExecutanteUsuarioId[0];
                     A145OrdemGestaoServicoId = P008C11_A145OrdemGestaoServicoId[0];
                     A134OrdemExecutanteUsuarioNome = P008C11_A134OrdemExecutanteUsuarioNome[0];
                     A137OrdemExecutanteHrInicio = P008C11_A137OrdemExecutanteHrInicio[0];
                     A136OrdemExecutanteDtInicio = P008C11_A136OrdemExecutanteDtInicio[0];
                     A139OrdemExecutanteHrConclusao = P008C11_A139OrdemExecutanteHrConclusao[0];
                     A140OrdemExecutanteComentario = P008C11_A140OrdemExecutanteComentario[0];
                     A142OrdemExecutanteValor = P008C11_A142OrdemExecutanteValor[0];
                     A135OrdemExecutanteId = P008C11_A135OrdemExecutanteId[0];
                     A134OrdemExecutanteUsuarioNome = P008C11_A134OrdemExecutanteUsuarioNome[0];
                     AV110GXLvl110 = 1;
                     AV45ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                     AV76Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                     AV77Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                     AV21GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                     if ( AV40PerfilUsuario != 4 )
                     {
                        AV36GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                     }
                     H8C0( false, 18) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 183, Gx_line+1, 275, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 292, Gx_line+1, 417, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 683, Gx_line+1, 775, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 433, Gx_line+1, 666, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(233, Gx_line+0, 283, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(375, Gx_line+0, 425, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(625, Gx_line+0, 675, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 175, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  if ( AV110GXLvl110 == 0 )
                  {
                     /* Using cursor P008C12 */
                     pr_default.execute(10, new Object[] {AV29GestaoServicoId});
                     while ( (pr_default.getStatus(10) != 101) )
                     {
                        A55ServicoExecutanteId = P008C12_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P008C12_n55ServicoExecutanteId[0];
                        A38GestaoServicoId = P008C12_A38GestaoServicoId[0];
                        A56ServicoExecutanteNome = P008C12_A56ServicoExecutanteNome[0];
                        A131GestaoServicoExecutanteId = P008C12_A131GestaoServicoExecutanteId[0];
                        A56ServicoExecutanteNome = P008C12_A56ServicoExecutanteNome[0];
                        AV45ServicoExecutanteNome = A56ServicoExecutanteNome;
                        H8C0( false, 18) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76Inicio, "")), 183, Gx_line+1, 275, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Termino, "")), 292, Gx_line+1, 417, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoValor, "")), 683, Gx_line+1, 775, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoComentario, "")), 433, Gx_line+1, 666, Gx_line+18, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(233, Gx_line+0, 283, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(375, Gx_line+0, 425, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(625, Gx_line+0, 675, Gx_line+17, 1, 169, 169, 169, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ServicoExecutanteNome, "")), 25, Gx_line+0, 175, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        pr_default.readNext(10);
                     }
                     pr_default.close(10);
                  }
                  H8C0( false, 223) ;
                  getPrinter().GxDrawLine(117, Gx_line+150, 367, Gx_line+150, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(450, Gx_line+150, 700, Gx_line+150, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 183, Gx_line+167, 287, Gx_line+181, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 500, Gx_line+167, 635, Gx_line+181, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+223);
                  /* Eject command */
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(P_lines+1);
                  AV44ServicoExecutanteIdCollection.Clear();
                  AV83NaturezaIdCollection.Clear();
               }
               AV100GXV1 = (int)(AV100GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8C0( true, 0) ;
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
         AV113GXLvl138 = 0;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              A325TipoServicoId ,
                                              AV86ServicoNaturezaIdCollection ,
                                              AV86ServicoNaturezaIdCollection.Count ,
                                              AV29GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008C13 */
         pr_default.execute(11, new Object[] {AV29GestaoServicoId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A325TipoServicoId = P008C13_A325TipoServicoId[0];
            A38GestaoServicoId = P008C13_A38GestaoServicoId[0];
            A323GestaoServicoTipoId = P008C13_A323GestaoServicoTipoId[0];
            AV113GXLvl138 = 1;
            AV94IsExisteTipoServico = true;
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( AV113GXLvl138 == 0 )
         {
            AV94IsExisteTipoServico = false;
         }
      }

      protected void S121( )
      {
         /* 'VERIFICAEXECUTANTE' Routine */
         returnInSub = false;
         AV114GXLvl148 = 0;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              A55ServicoExecutanteId ,
                                              AV88ExecutanteIdCollection ,
                                              AV88ExecutanteIdCollection.Count ,
                                              AV29GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008C14 */
         pr_default.execute(12, new Object[] {AV29GestaoServicoId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A55ServicoExecutanteId = P008C14_A55ServicoExecutanteId[0];
            n55ServicoExecutanteId = P008C14_n55ServicoExecutanteId[0];
            A38GestaoServicoId = P008C14_A38GestaoServicoId[0];
            A131GestaoServicoExecutanteId = P008C14_A131GestaoServicoExecutanteId[0];
            AV114GXLvl148 = 1;
            AV95IsExisteExecutante = true;
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( AV114GXLvl148 == 0 )
         {
            AV95IsExisteExecutante = false;
         }
      }

      protected void H8C0( bool bFoot ,
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
         AV13DateTime = (DateTime)(DateTime.MinValue);
         AV88ExecutanteIdCollection = new GxSimpleCollection<long>();
         AV86ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P008C2_A1EmpresaId = new long[1] ;
         P008C2_A2EmpresaNome = new string[] {""} ;
         P008C2_A3EmpresaCNPJ = new string[] {""} ;
         P008C2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV14Descricao = "";
         AV18EmpresaNome = "";
         AV15EmpresaCNPJ = "";
         AV17EmpresaFotoUrl = "";
         AV53Url = "";
         AV98Empresafoto_GXI = "";
         AV16EmpresaFoto = "";
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         P008C3_A77ServicoEmpresaId = new long[1] ;
         P008C3_A42GestaoServicoStatus = new short[1] ;
         P008C3_A41GestaoServicoPrioridade = new short[1] ;
         P008C3_A36ServicoSetorId = new long[1] ;
         P008C3_A34ServicoClienteId = new long[1] ;
         P008C3_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008C3_A38GestaoServicoId = new long[1] ;
         P008C3_A79GestaoServicoNumero = new long[1] ;
         AV87GestaoServicoIdCollection = new GxSimpleCollection<long>();
         P008C4_A36ServicoSetorId = new long[1] ;
         P008C4_A53ServicoNaturezaId = new long[1] ;
         P008C4_n53ServicoNaturezaId = new bool[] {false} ;
         P008C4_A38GestaoServicoId = new long[1] ;
         P008C4_A79GestaoServicoNumero = new long[1] ;
         P008C4_A40GestaoServicoDescricao = new string[] {""} ;
         P008C4_A35ServicoClienteNome = new string[] {""} ;
         P008C4_A37ServicoSetorNome = new string[] {""} ;
         P008C4_A54ServicoNaturezaNome = new string[] {""} ;
         P008C4_A41GestaoServicoPrioridade = new short[1] ;
         P008C4_A42GestaoServicoStatus = new short[1] ;
         P008C4_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P008C4_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008C4_A157GestaoServicoPrecificacao = new short[1] ;
         P008C4_A129EnderecoId = new long[1] ;
         P008C4_n129EnderecoId = new bool[] {false} ;
         P008C4_A322GestaoServicoTipoDemanda = new short[1] ;
         P008C4_A34ServicoClienteId = new long[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
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
         P008C5_A106ClienteEnderecoId = new long[1] ;
         P008C5_A17ClienteId = new long[1] ;
         P008C5_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV20EnderecoLocal = "";
         AV16EmpresaFoto = "";
         sImgUrl = "";
         P008C6_A38GestaoServicoId = new long[1] ;
         P008C6_A326TipoServicoNome = new string[] {""} ;
         P008C6_A329TipoServicoEstimado = new short[1] ;
         P008C6_A325TipoServicoId = new long[1] ;
         P008C6_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV73ServicoDescricao = "";
         AV70TempoEstimado = "";
         AV96TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV69TerminoDate = DateTime.MinValue;
         AV83NaturezaIdCollection = new GxSimpleCollection<long>();
         P008C7_A25NaturezaId = new long[1] ;
         P008C7_A26NaturezaNome = new string[] {""} ;
         P008C7_A162NaturezaValor = new decimal[1] ;
         P008C7_A289NaturezaCusto = new decimal[1] ;
         A26NaturezaNome = "";
         AV93NaturezaNome = "";
         AV39NaturezaValorVarChar = "";
         AV38NaturezaCustoVarChar = "";
         AV52TotalVarChar = "";
         P008C8_A38GestaoServicoId = new long[1] ;
         P008C8_A55ServicoExecutanteId = new long[1] ;
         P008C8_n55ServicoExecutanteId = new bool[] {false} ;
         P008C8_A131GestaoServicoExecutanteId = new long[1] ;
         AV44ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P008C9_A9UsuarioId = new long[1] ;
         P008C9_A173UsuarioFuncaoId = new long[1] ;
         P008C9_n173UsuarioFuncaoId = new bool[] {false} ;
         P008C9_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV64OrcamentoTipoHH = "";
         P008C10_A163FuncaoId = new long[1] ;
         AV60FuncaoDiaria = "";
         AV58FuncaoViagem = "";
         AV59FuncaoNoturno = "";
         AV57FuncaoHr100 = "";
         AV56FuncaoHr50 = "";
         AV55FuncaoHrNormal = "";
         P008C11_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008C11_A145OrdemGestaoServicoId = new long[1] ;
         P008C11_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008C11_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008C11_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008C11_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008C11_A140OrdemExecutanteComentario = new string[] {""} ;
         P008C11_A142OrdemExecutanteValor = new decimal[1] ;
         P008C11_A135OrdemExecutanteId = new long[1] ;
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
         P008C12_A55ServicoExecutanteId = new long[1] ;
         P008C12_n55ServicoExecutanteId = new bool[] {false} ;
         P008C12_A38GestaoServicoId = new long[1] ;
         P008C12_A56ServicoExecutanteNome = new string[] {""} ;
         P008C12_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         P008C13_A325TipoServicoId = new long[1] ;
         P008C13_A38GestaoServicoId = new long[1] ;
         P008C13_A323GestaoServicoTipoId = new long[1] ;
         P008C14_A55ServicoExecutanteId = new long[1] ;
         P008C14_n55ServicoExecutanteId = new bool[] {false} ;
         P008C14_A38GestaoServicoId = new long[1] ;
         P008C14_A131GestaoServicoExecutanteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatorioosmodelo1__default(),
            new Object[][] {
                new Object[] {
               P008C2_A1EmpresaId, P008C2_A2EmpresaNome, P008C2_A3EmpresaCNPJ, P008C2_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P008C3_A77ServicoEmpresaId, P008C3_A42GestaoServicoStatus, P008C3_A41GestaoServicoPrioridade, P008C3_A36ServicoSetorId, P008C3_A34ServicoClienteId, P008C3_A39GestaoServicoDtHora, P008C3_A38GestaoServicoId, P008C3_A79GestaoServicoNumero
               }
               , new Object[] {
               P008C4_A36ServicoSetorId, P008C4_A53ServicoNaturezaId, P008C4_n53ServicoNaturezaId, P008C4_A38GestaoServicoId, P008C4_A79GestaoServicoNumero, P008C4_A40GestaoServicoDescricao, P008C4_A35ServicoClienteNome, P008C4_A37ServicoSetorNome, P008C4_A54ServicoNaturezaNome, P008C4_A41GestaoServicoPrioridade,
               P008C4_A42GestaoServicoStatus, P008C4_A43GestaoServicoDtProgramada, P008C4_A39GestaoServicoDtHora, P008C4_A157GestaoServicoPrecificacao, P008C4_A129EnderecoId, P008C4_n129EnderecoId, P008C4_A322GestaoServicoTipoDemanda, P008C4_A34ServicoClienteId
               }
               , new Object[] {
               P008C5_A106ClienteEnderecoId, P008C5_A17ClienteId, P008C5_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P008C6_A38GestaoServicoId, P008C6_A326TipoServicoNome, P008C6_A329TipoServicoEstimado, P008C6_A325TipoServicoId, P008C6_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008C7_A25NaturezaId, P008C7_A26NaturezaNome, P008C7_A162NaturezaValor, P008C7_A289NaturezaCusto
               }
               , new Object[] {
               P008C8_A38GestaoServicoId, P008C8_A55ServicoExecutanteId, P008C8_n55ServicoExecutanteId, P008C8_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008C9_A9UsuarioId, P008C9_A173UsuarioFuncaoId, P008C9_n173UsuarioFuncaoId, P008C9_A10UsuarioNome
               }
               , new Object[] {
               P008C10_A163FuncaoId
               }
               , new Object[] {
               P008C11_A133OrdemExecutanteUsuarioId, P008C11_A145OrdemGestaoServicoId, P008C11_A134OrdemExecutanteUsuarioNome, P008C11_A137OrdemExecutanteHrInicio, P008C11_A136OrdemExecutanteDtInicio, P008C11_A139OrdemExecutanteHrConclusao, P008C11_A140OrdemExecutanteComentario, P008C11_A142OrdemExecutanteValor, P008C11_A135OrdemExecutanteId
               }
               , new Object[] {
               P008C12_A55ServicoExecutanteId, P008C12_n55ServicoExecutanteId, P008C12_A38GestaoServicoId, P008C12_A56ServicoExecutanteNome, P008C12_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008C13_A325TipoServicoId, P008C13_A38GestaoServicoId, P008C13_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008C14_A55ServicoExecutanteId, P008C14_n55ServicoExecutanteId, P008C14_A38GestaoServicoId, P008C14_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV34GestaoServicoPrioridade ;
      private short AV35GestaoServicoStatus ;
      private short AV40PerfilUsuario ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short AV32GestaoServicoPrecificacao ;
      private short AV92StatusServico ;
      private short A329TipoServicoEstimado ;
      private short AV110GXLvl110 ;
      private short AV113GXLvl138 ;
      private short AV114GXLvl148 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV100GXV1 ;
      private int Gx_OldLine ;
      private int AV104GXV2 ;
      private int AV107GXV3 ;
      private int AV86ServicoNaturezaIdCollection_Count ;
      private int AV88ExecutanteIdCollection_Count ;
      private long AV54UsuarioId ;
      private long AV43ServicoEmpresaId ;
      private long AV41ServicoClienteId ;
      private long AV48ServicoSetorId ;
      private long A1EmpresaId ;
      private long A34ServicoClienteId ;
      private long A36ServicoSetorId ;
      private long A77ServicoEmpresaId ;
      private long A38GestaoServicoId ;
      private long A79GestaoServicoNumero ;
      private long AV29GestaoServicoId ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long AV30GestaoServicoNumero ;
      private long AV19EnderecoId ;
      private long AV89AuxServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long AV91NaturezaId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV74ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV62UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV51Total ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV18EmpresaNome ;
      private string AV15EmpresaCNPJ ;
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
      private string sImgUrl ;
      private string A326TipoServicoNome ;
      private string A26NaturezaNome ;
      private string AV93NaturezaNome ;
      private string A10UsuarioNome ;
      private string AV64OrcamentoTipoHH ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV45ServicoExecutanteNome ;
      private string AV76Inicio ;
      private string AV77Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV13DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV25GestaoServicoDtHora ;
      private DateTime AV96TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime AV23GestaoServicoDataInicio ;
      private DateTime AV22GestaoServicoDataConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV26GestaoServicoDtProgramada ;
      private DateTime AV69TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV94IsExisteTipoServico ;
      private bool AV95IsExisteExecutante ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string AV84TecnicoLongVarChar ;
      private string AV85NaturezaLongVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV14Descricao ;
      private string AV17EmpresaFotoUrl ;
      private string AV53Url ;
      private string AV98Empresafoto_GXI ;
      private string A40GestaoServicoDescricao ;
      private string AV24GestaoServicoDescricao ;
      private string AV33GestaoServicoPrecificacaoVarChar ;
      private string AV72TipoDemandaVarChar ;
      private string AV73ServicoDescricao ;
      private string AV70TempoEstimado ;
      private string AV39NaturezaValorVarChar ;
      private string AV38NaturezaCustoVarChar ;
      private string AV52TotalVarChar ;
      private string AV60FuncaoDiaria ;
      private string AV58FuncaoViagem ;
      private string AV59FuncaoNoturno ;
      private string AV57FuncaoHr100 ;
      private string AV56FuncaoHr50 ;
      private string AV55FuncaoHrNormal ;
      private string A140OrdemExecutanteComentario ;
      private string AV21GestaoServicoComentario ;
      private string AV36GestaoServicoValor ;
      private string AV16EmpresaFoto ;
      private string Empresafoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV88ExecutanteIdCollection ;
      private GxSimpleCollection<long> AV86ServicoNaturezaIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P008C2_A1EmpresaId ;
      private string[] P008C2_A2EmpresaNome ;
      private string[] P008C2_A3EmpresaCNPJ ;
      private string[] P008C2_A40000EmpresaFoto_GXI ;
      private long[] P008C3_A77ServicoEmpresaId ;
      private short[] P008C3_A42GestaoServicoStatus ;
      private short[] P008C3_A41GestaoServicoPrioridade ;
      private long[] P008C3_A36ServicoSetorId ;
      private long[] P008C3_A34ServicoClienteId ;
      private DateTime[] P008C3_A39GestaoServicoDtHora ;
      private long[] P008C3_A38GestaoServicoId ;
      private long[] P008C3_A79GestaoServicoNumero ;
      private GxSimpleCollection<long> AV87GestaoServicoIdCollection ;
      private long[] P008C4_A36ServicoSetorId ;
      private long[] P008C4_A53ServicoNaturezaId ;
      private bool[] P008C4_n53ServicoNaturezaId ;
      private long[] P008C4_A38GestaoServicoId ;
      private long[] P008C4_A79GestaoServicoNumero ;
      private string[] P008C4_A40GestaoServicoDescricao ;
      private string[] P008C4_A35ServicoClienteNome ;
      private string[] P008C4_A37ServicoSetorNome ;
      private string[] P008C4_A54ServicoNaturezaNome ;
      private short[] P008C4_A41GestaoServicoPrioridade ;
      private short[] P008C4_A42GestaoServicoStatus ;
      private DateTime[] P008C4_A43GestaoServicoDtProgramada ;
      private DateTime[] P008C4_A39GestaoServicoDtHora ;
      private short[] P008C4_A157GestaoServicoPrecificacao ;
      private long[] P008C4_A129EnderecoId ;
      private bool[] P008C4_n129EnderecoId ;
      private short[] P008C4_A322GestaoServicoTipoDemanda ;
      private long[] P008C4_A34ServicoClienteId ;
      private long[] P008C5_A106ClienteEnderecoId ;
      private long[] P008C5_A17ClienteId ;
      private string[] P008C5_A107ClienteEnderecoLocal ;
      private long[] P008C6_A38GestaoServicoId ;
      private string[] P008C6_A326TipoServicoNome ;
      private short[] P008C6_A329TipoServicoEstimado ;
      private long[] P008C6_A325TipoServicoId ;
      private long[] P008C6_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV83NaturezaIdCollection ;
      private long[] P008C7_A25NaturezaId ;
      private string[] P008C7_A26NaturezaNome ;
      private decimal[] P008C7_A162NaturezaValor ;
      private decimal[] P008C7_A289NaturezaCusto ;
      private long[] P008C8_A38GestaoServicoId ;
      private long[] P008C8_A55ServicoExecutanteId ;
      private bool[] P008C8_n55ServicoExecutanteId ;
      private long[] P008C8_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV44ServicoExecutanteIdCollection ;
      private long[] P008C9_A9UsuarioId ;
      private long[] P008C9_A173UsuarioFuncaoId ;
      private bool[] P008C9_n173UsuarioFuncaoId ;
      private string[] P008C9_A10UsuarioNome ;
      private long[] P008C10_A163FuncaoId ;
      private long[] P008C11_A133OrdemExecutanteUsuarioId ;
      private long[] P008C11_A145OrdemGestaoServicoId ;
      private string[] P008C11_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008C11_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008C11_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008C11_A139OrdemExecutanteHrConclusao ;
      private string[] P008C11_A140OrdemExecutanteComentario ;
      private decimal[] P008C11_A142OrdemExecutanteValor ;
      private long[] P008C11_A135OrdemExecutanteId ;
      private long[] P008C12_A55ServicoExecutanteId ;
      private bool[] P008C12_n55ServicoExecutanteId ;
      private long[] P008C12_A38GestaoServicoId ;
      private string[] P008C12_A56ServicoExecutanteNome ;
      private long[] P008C12_A131GestaoServicoExecutanteId ;
      private long[] P008C13_A325TipoServicoId ;
      private long[] P008C13_A38GestaoServicoId ;
      private long[] P008C13_A323GestaoServicoTipoId ;
      private long[] P008C14_A55ServicoExecutanteId ;
      private bool[] P008C14_n55ServicoExecutanteId ;
      private long[] P008C14_A38GestaoServicoId ;
      private long[] P008C14_A131GestaoServicoExecutanteId ;
   }

   public class aprcrelatorioosmodelo1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008C3( IGxContext context ,
                                             long AV41ServicoClienteId ,
                                             long AV48ServicoSetorId ,
                                             short AV34GestaoServicoPrioridade ,
                                             short AV35GestaoServicoStatus ,
                                             long A34ServicoClienteId ,
                                             long A36ServicoSetorId ,
                                             short A41GestaoServicoPrioridade ,
                                             short A42GestaoServicoStatus ,
                                             DateTime A39GestaoServicoDtHora ,
                                             DateTime AV23GestaoServicoDataInicio ,
                                             DateTime AV22GestaoServicoDataConclusao ,
                                             long A77ServicoEmpresaId ,
                                             long AV43ServicoEmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ServicoEmpresaId], [GestaoServicoStatus], [GestaoServicoPrioridade], [ServicoSetorId] AS ServicoSetorId, [ServicoClienteId] AS ServicoClienteId, [GestaoServicoDtHora], [GestaoServicoId], [GestaoServicoNumero] FROM [GestaoServico]";
         AddWhere(sWhereString, "([GestaoServicoDtHora] >= @AV23GestaoServicoDataInicio and [GestaoServicoDtHora] <= @AV22GestaoServicoDataConclusao)");
         AddWhere(sWhereString, "([ServicoEmpresaId] = @AV43ServicoEmpresaId)");
         if ( ! (0==AV41ServicoClienteId) )
         {
            AddWhere(sWhereString, "([ServicoClienteId] = @AV41ServicoClienteId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV48ServicoSetorId) )
         {
            AddWhere(sWhereString, "([ServicoSetorId] = @AV48ServicoSetorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV34GestaoServicoPrioridade) )
         {
            AddWhere(sWhereString, "([GestaoServicoPrioridade] = @AV34GestaoServicoPrioridade)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV35GestaoServicoStatus) )
         {
            AddWhere(sWhereString, "([GestaoServicoStatus] = @AV35GestaoServicoStatus)");
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

      protected Object[] conditional_P008C13( IGxContext context ,
                                              long A325TipoServicoId ,
                                              GxSimpleCollection<long> AV86ServicoNaturezaIdCollection ,
                                              int AV86ServicoNaturezaIdCollection_Count ,
                                              long AV29GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipoServicoId] AS TipoServicoId, [GestaoServicoId], [GestaoServicoTipoId] FROM [GestaoServicoTipo]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV29GestaoServicoId)");
         if ( ! ( AV86ServicoNaturezaIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86ServicoNaturezaIdCollection, "[TipoServicoId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008C14( IGxContext context ,
                                              long A55ServicoExecutanteId ,
                                              GxSimpleCollection<long> AV88ExecutanteIdCollection ,
                                              int AV88ExecutanteIdCollection_Count ,
                                              long AV29GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV29GestaoServicoId)");
         if ( ! ( AV88ExecutanteIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV88ExecutanteIdCollection, "[ServicoExecutanteId] IN (", ")")+")");
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
                     return conditional_P008C3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 11 :
                     return conditional_P008C13(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 12 :
                     return conditional_P008C14(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
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
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP008C4;
          prmP008C4 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C5;
          prmP008C5 = new Object[] {
          new ParDef("@AV89AuxServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C6;
          prmP008C6 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C7;
          prmP008C7 = new Object[] {
          new ParDef("@AV91NaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP008C8;
          prmP008C8 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C9;
          prmP008C9 = new Object[] {
          new ParDef("@AV74ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP008C10;
          prmP008C10 = new Object[] {
          new ParDef("@AV62UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C11;
          prmP008C11 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C12;
          prmP008C12 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("@AV23GestaoServicoDataInicio",GXType.Date,8,0) ,
          new ParDef("@AV22GestaoServicoDataConclusao",GXType.Date,8,0) ,
          new ParDef("@AV43ServicoEmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV41ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV48ServicoSetorId",GXType.Decimal,18,0) ,
          new ParDef("@AV34GestaoServicoPrioridade",GXType.Int16,4,0) ,
          new ParDef("@AV35GestaoServicoStatus",GXType.Int16,4,0)
          };
          Object[] prmP008C13;
          prmP008C13 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008C14;
          prmP008C14 = new Object[] {
          new ParDef("@AV29GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV43ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C4", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[GestaoServicoId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[EnderecoId], T1.[GestaoServicoTipoDemanda], T1.[ServicoClienteId] AS ServicoClienteId FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C5", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV89AuxServicoClienteId and [ClienteEnderecoId] = @AV19EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C6", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C7", "SELECT [NaturezaId], [NaturezaNome], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV91NaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C8", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV29GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C9", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV74ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C10", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV62UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008C11", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C12", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV29GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C14,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 60);
                ((string[]) buf[7])[0] = rslt.getString(7, 60);
                ((string[]) buf[8])[0] = rslt.getString(8, 60);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
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
