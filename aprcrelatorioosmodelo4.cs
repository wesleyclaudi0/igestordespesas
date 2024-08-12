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
   public class aprcrelatorioosmodelo4 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV78UsuarioId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV35GestaoServicoDataInicio = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataInicio"));
                  AV34GestaoServicoDataConclusao = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataConclusao"));
                  AV61ServicoEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoEmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AV59ServicoClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoClienteId"), "."), 18, MidpointRounding.ToEven));
                  AV66ServicoSetorId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoSetorId"), "."), 18, MidpointRounding.ToEven));
                  AV46GestaoServicoPrioridade = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoPrioridade"), "."), 18, MidpointRounding.ToEven));
                  AV47GestaoServicoStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoStatus"), "."), 18, MidpointRounding.ToEven));
                  AV57PerfilUsuario = (short)(Math.Round(NumberUtil.Val( GetPar( "PerfilUsuario"), "."), 18, MidpointRounding.ToEven));
                  AV84TecnicoLongVarChar = GetPar( "TecnicoLongVarChar");
                  AV83NaturezaLongVarChar = GetPar( "NaturezaLongVarChar");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatorioosmodelo4( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatorioosmodelo4( IGxContext context )
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
         this.AV78UsuarioId = aP0_UsuarioId;
         this.AV35GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV34GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV61ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV59ServicoClienteId = aP4_ServicoClienteId;
         this.AV66ServicoSetorId = aP5_ServicoSetorId;
         this.AV46GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV47GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV57PerfilUsuario = aP8_PerfilUsuario;
         this.AV84TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV83NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         this.AV78UsuarioId = aP0_UsuarioId;
         this.AV35GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV34GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV61ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV59ServicoClienteId = aP4_ServicoClienteId;
         this.AV66ServicoSetorId = aP5_ServicoSetorId;
         this.AV46GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV47GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV57PerfilUsuario = aP8_PerfilUsuario;
         this.AV84TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV83NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         setOutputFileName("RelatorioOSM4.pdf");
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
            AV16DateTime = DateTimeUtil.Now( context);
            AV91ExecutanteIdCollection.FromJSonString(AV84TecnicoLongVarChar, null);
            AV82ServicoNaturezaIdCollection.FromJSonString(AV83NaturezaLongVarChar, null);
            /* Using cursor P008G2 */
            pr_default.execute(0, new Object[] {AV61ServicoEmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P008G2_A1EmpresaId[0];
               A2EmpresaNome = P008G2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P008G2_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P008G2_A40000EmpresaFoto_GXI[0];
               AV17Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV24EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV18EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV22EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV75Url = StringUtil.StringReplace( AV22EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV95Empresafoto_GXI = AV75Url;
               AV21EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV59ServicoClienteId ,
                                                 AV66ServicoSetorId ,
                                                 AV46GestaoServicoPrioridade ,
                                                 AV47GestaoServicoStatus ,
                                                 A34ServicoClienteId ,
                                                 A36ServicoSetorId ,
                                                 A41GestaoServicoPrioridade ,
                                                 A42GestaoServicoStatus ,
                                                 A39GestaoServicoDtHora ,
                                                 AV35GestaoServicoDataInicio ,
                                                 AV34GestaoServicoDataConclusao ,
                                                 A77ServicoEmpresaId ,
                                                 AV61ServicoEmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P008G3 */
            pr_default.execute(1, new Object[] {AV35GestaoServicoDataInicio, AV34GestaoServicoDataConclusao, AV61ServicoEmpresaId, AV59ServicoClienteId, AV66ServicoSetorId, AV46GestaoServicoPrioridade, AV47GestaoServicoStatus});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A77ServicoEmpresaId = P008G3_A77ServicoEmpresaId[0];
               A42GestaoServicoStatus = P008G3_A42GestaoServicoStatus[0];
               A41GestaoServicoPrioridade = P008G3_A41GestaoServicoPrioridade[0];
               A36ServicoSetorId = P008G3_A36ServicoSetorId[0];
               A34ServicoClienteId = P008G3_A34ServicoClienteId[0];
               A39GestaoServicoDtHora = P008G3_A39GestaoServicoDtHora[0];
               A38GestaoServicoId = P008G3_A38GestaoServicoId[0];
               A79GestaoServicoNumero = P008G3_A79GestaoServicoNumero[0];
               AV92GestaoServicoIdCollection.Add(A38GestaoServicoId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV97GXV1 = 1;
            while ( AV97GXV1 <= AV92GestaoServicoIdCollection.Count )
            {
               AV41GestaoServicoId = (long)(AV92GestaoServicoIdCollection.GetNumeric(AV97GXV1));
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
               if ( ( AV86IsExisteTipoServico ) && ( AV85IsExisteExecutante ) )
               {
                  /* Using cursor P008G4 */
                  pr_default.execute(2, new Object[] {AV41GestaoServicoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A36ServicoSetorId = P008G4_A36ServicoSetorId[0];
                     A38GestaoServicoId = P008G4_A38GestaoServicoId[0];
                     A79GestaoServicoNumero = P008G4_A79GestaoServicoNumero[0];
                     A40GestaoServicoDescricao = P008G4_A40GestaoServicoDescricao[0];
                     A35ServicoClienteNome = P008G4_A35ServicoClienteNome[0];
                     A37ServicoSetorNome = P008G4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008G4_A54ServicoNaturezaNome[0];
                     A41GestaoServicoPrioridade = P008G4_A41GestaoServicoPrioridade[0];
                     A42GestaoServicoStatus = P008G4_A42GestaoServicoStatus[0];
                     A43GestaoServicoDtProgramada = P008G4_A43GestaoServicoDtProgramada[0];
                     A39GestaoServicoDtHora = P008G4_A39GestaoServicoDtHora[0];
                     A157GestaoServicoPrecificacao = P008G4_A157GestaoServicoPrecificacao[0];
                     A53ServicoNaturezaId = P008G4_A53ServicoNaturezaId[0];
                     n53ServicoNaturezaId = P008G4_n53ServicoNaturezaId[0];
                     A129EnderecoId = P008G4_A129EnderecoId[0];
                     n129EnderecoId = P008G4_n129EnderecoId[0];
                     A322GestaoServicoTipoDemanda = P008G4_A322GestaoServicoTipoDemanda[0];
                     A34ServicoClienteId = P008G4_A34ServicoClienteId[0];
                     A37ServicoSetorNome = P008G4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008G4_A54ServicoNaturezaNome[0];
                     A35ServicoClienteNome = P008G4_A35ServicoClienteNome[0];
                     AV42GestaoServicoNumero = A79GestaoServicoNumero;
                     AV36GestaoServicoDescricao = A40GestaoServicoDescricao;
                     AV60ServicoClienteNome = A35ServicoClienteNome;
                     AV67ServicoSetorNome = A37ServicoSetorNome;
                     AV65ServicoNaturezaNome = A54ServicoNaturezaNome;
                     AV13AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
                     AV14AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
                     AV38GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
                     AV37GestaoServicoDtHora = A39GestaoServicoDtHora;
                     AV44GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
                     AV45GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
                     AV64ServicoNaturezaId = A53ServicoNaturezaId;
                     AV25EnderecoId = A129EnderecoId;
                     AV10TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
                     AV90AuxServicoClienteId = A34ServicoClienteId;
                     AV87StatusServico = A42GestaoServicoStatus;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P008G5 */
                  pr_default.execute(3, new Object[] {AV90AuxServicoClienteId, AV25EnderecoId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A106ClienteEnderecoId = P008G5_A106ClienteEnderecoId[0];
                     A17ClienteId = P008G5_A17ClienteId[0];
                     A107ClienteEnderecoLocal = P008G5_A107ClienteEnderecoLocal[0];
                     AV26EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  H8G0( false, 234) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 128, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Descricao, "")), 197, Gx_line+0, 547, Gx_line+33, 1, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaFoto)) ? AV95Empresafoto_GXI : AV21EmpresaFoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 133, Gx_line+35, 298, Gx_line+98) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpresaCNPJ, "")), 75, Gx_line+118, 317, Gx_line+133, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24EmpresaNome, "")), 75, Gx_line+101, 317, Gx_line+116, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "O.S Nº: ", ""), 408, Gx_line+33, 464, Gx_line+51, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 475, Gx_line+33, 567, Gx_line+50, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Data:", ""), 408, Gx_line+50, 450, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV37GestaoServicoDtHora, "99/99/9999 99:99:99"), 446, Gx_line+51, 546, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+33, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(358, Gx_line+33, 683, Gx_line+50, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+150, 684, Gx_line+167, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+133, 684, Gx_line+150, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+117, 684, Gx_line+134, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+100, 684, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+33, 684, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+33, 358, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpresaContato, "")), 75, Gx_line+151, 450, Gx_line+166, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpresaEndereco, "")), 75, Gx_line+134, 650, Gx_line+149, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(358, Gx_line+50, 683, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(358, Gx_line+67, 683, Gx_line+84, 1, 192, 192, 192, 1, 0, 128, 0, 1, 0, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 492, Gx_line+67, 550, Gx_line+85, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60ServicoClienteNome, "")), 408, Gx_line+84, 666, Gx_line+99, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26EnderecoLocal, "")), 433, Gx_line+118, 683, Gx_line+133, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67ServicoSetorNome, "")), 408, Gx_line+101, 675, Gx_line+116, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(358, Gx_line+100, 683, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(358, Gx_line+117, 683, Gx_line+134, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(67, Gx_line+167, 684, Gx_line+184, 1, 192, 192, 192, 1, 0, 128, 0, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Status", ""), 542, Gx_line+167, 600, Gx_line+185, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Prioridade", ""), 333, Gx_line+167, 425, Gx_line+185, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Descrição", ""), 75, Gx_line+167, 158, Gx_line+185, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13AuxGestaoServicoPrioridade, "")), 333, Gx_line+184, 475, Gx_line+199, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AuxGestaoServicoStatus, "")), 542, Gx_line+184, 684, Gx_line+199, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36GestaoServicoDescricao, "")), 75, Gx_line+183, 325, Gx_line+200, 0, 0, 0, 0) ;
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
                  /* Using cursor P008G6 */
                  pr_default.execute(4, new Object[] {AV41GestaoServicoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A38GestaoServicoId = P008G6_A38GestaoServicoId[0];
                     A326TipoServicoNome = P008G6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008G6_A329TipoServicoEstimado[0];
                     A325TipoServicoId = P008G6_A325TipoServicoId[0];
                     A323GestaoServicoTipoId = P008G6_A323GestaoServicoTipoId[0];
                     A326TipoServicoNome = P008G6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008G6_A329TipoServicoEstimado[0];
                     AV65ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
                     AV69TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
                     AV93TerminoDateTime = DateTimeUtil.ResetTime( AV38GestaoServicoDtProgramada ) ;
                     AV70TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV93TerminoDateTime, 3600*(A329TipoServicoEstimado)));
                     AV89NaturezaIdCollection.Add(A325TipoServicoId, 0);
                     H8G0( false, 17) ;
                     getPrinter().GxDrawRect(325, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65ServicoNaturezaNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TempoEstimado, "")), 333, Gx_line+0, 491, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV70TerminoDate, "99/99/99"), 542, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  if ( AV57PerfilUsuario != 4 )
                  {
                     if ( AV44GestaoServicoPrecificacao == 2 )
                     {
                        H8G0( false, 34) ;
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
                        AV101GXV2 = 1;
                        while ( AV101GXV2 <= AV89NaturezaIdCollection.Count )
                        {
                           AV88NaturezaId = (long)(AV89NaturezaIdCollection.GetNumeric(AV101GXV2));
                           /* Using cursor P008G7 */
                           pr_default.execute(5, new Object[] {AV88NaturezaId});
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A25NaturezaId = P008G7_A25NaturezaId[0];
                              A26NaturezaNome = P008G7_A26NaturezaNome[0];
                              A162NaturezaValor = P008G7_A162NaturezaValor[0];
                              A289NaturezaCusto = P008G7_A289NaturezaCusto[0];
                              AV71TipoServicoNome = StringUtil.Trim( A26NaturezaNome);
                              AV54NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                              AV53NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                              AV72Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                              AV74TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV72Total, 18, 2));
                              H8G0( false, 17) ;
                              getPrinter().GxDrawRect(275, Gx_line+0, 408, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(408, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TotalVarChar, "")), 542, Gx_line+0, 667, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53NaturezaCustoVarChar, "")), 417, Gx_line+0, 534, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54NaturezaValorVarChar, "")), 283, Gx_line+0, 400, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TipoServicoNome, "")), 75, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(5);
                           AV101GXV2 = (int)(AV101GXV2+1);
                        }
                        H8G0( false, 17) ;
                        getPrinter().GxDrawRect(408, Gx_line+0, 533, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Total2VarChar, "")), 542, Gx_line+1, 667, Gx_line+16, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+1, 525, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(275, Gx_line+0, 408, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                     }
                     else
                     {
                        if ( AV44GestaoServicoPrecificacao == 1 )
                        {
                           H8G0( false, 18) ;
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
                           /* Using cursor P008G8 */
                           pr_default.execute(6, new Object[] {AV41GestaoServicoId});
                           while ( (pr_default.getStatus(6) != 101) )
                           {
                              A38GestaoServicoId = P008G8_A38GestaoServicoId[0];
                              A55ServicoExecutanteId = P008G8_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008G8_n55ServicoExecutanteId[0];
                              A131GestaoServicoExecutanteId = P008G8_A131GestaoServicoExecutanteId[0];
                              AV62ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                              pr_default.readNext(6);
                           }
                           pr_default.close(6);
                           AV104GXV3 = 1;
                           while ( AV104GXV3 <= AV62ServicoExecutanteIdCollection.Count )
                           {
                              AV8ServicoExecutanteId = (long)(AV62ServicoExecutanteIdCollection.GetNumeric(AV104GXV3));
                              /* Using cursor P008G9 */
                              pr_default.execute(7, new Object[] {AV8ServicoExecutanteId});
                              while ( (pr_default.getStatus(7) != 101) )
                              {
                                 A9UsuarioId = P008G9_A9UsuarioId[0];
                                 A173UsuarioFuncaoId = P008G9_A173UsuarioFuncaoId[0];
                                 n173UsuarioFuncaoId = P008G9_n173UsuarioFuncaoId[0];
                                 A10UsuarioNome = P008G9_A10UsuarioNome[0];
                                 AV77UsuarioFuncaoId = A173UsuarioFuncaoId;
                                 AV9TecnicoNome = StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(7);
                              /* Using cursor P008G10 */
                              pr_default.execute(8, new Object[] {AV77UsuarioFuncaoId});
                              while ( (pr_default.getStatus(8) != 101) )
                              {
                                 A163FuncaoId = P008G10_A163FuncaoId[0];
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(8);
                              H8G0( false, 17) ;
                              getPrinter().GxDrawRect(617, Gx_line+0, 619, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(542, Gx_line+0, 545, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(417, Gx_line+0, 467, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(342, Gx_line+0, 375, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(192, Gx_line+0, 284, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27FuncaoDiaria, "")), 625, Gx_line+0, 683, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31FuncaoNoturno, "")), 550, Gx_line+0, 617, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32FuncaoViagem, "")), 475, Gx_line+0, 533, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FuncaoHr50, "")), 292, Gx_line+0, 367, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30FuncaoHrNormal, "")), 200, Gx_line+0, 267, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9TecnicoNome, "")), 75, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FuncaoHr100, "")), 383, Gx_line+0, 458, Gx_line+17, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              AV104GXV3 = (int)(AV104GXV3+1);
                           }
                        }
                     }
                  }
                  if ( AV87StatusServico != 1 )
                  {
                     H8G0( false, 18) ;
                     getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 1, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Executante", ""), 75, Gx_line+0, 158, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Comentário", ""), 383, Gx_line+0, 466, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Término", ""), 283, Gx_line+0, 366, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Início", ""), 183, Gx_line+0, 266, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 583, Gx_line+0, 666, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(275, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(375, Gx_line+0, 377, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(575, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(150, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                  }
                  AV107GXLvl112 = 0;
                  /* Using cursor P008G11 */
                  pr_default.execute(9, new Object[] {AV41GestaoServicoId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A133OrdemExecutanteUsuarioId = P008G11_A133OrdemExecutanteUsuarioId[0];
                     A145OrdemGestaoServicoId = P008G11_A145OrdemGestaoServicoId[0];
                     A134OrdemExecutanteUsuarioNome = P008G11_A134OrdemExecutanteUsuarioNome[0];
                     A137OrdemExecutanteHrInicio = P008G11_A137OrdemExecutanteHrInicio[0];
                     A136OrdemExecutanteDtInicio = P008G11_A136OrdemExecutanteDtInicio[0];
                     A139OrdemExecutanteHrConclusao = P008G11_A139OrdemExecutanteHrConclusao[0];
                     A140OrdemExecutanteComentario = P008G11_A140OrdemExecutanteComentario[0];
                     A142OrdemExecutanteValor = P008G11_A142OrdemExecutanteValor[0];
                     A135OrdemExecutanteId = P008G11_A135OrdemExecutanteId[0];
                     A134OrdemExecutanteUsuarioNome = P008G11_A134OrdemExecutanteUsuarioNome[0];
                     AV107GXLvl112 = 1;
                     AV63ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                     AV80Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                     AV81Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                     AV33GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                     if ( AV57PerfilUsuario != 4 )
                     {
                        AV48GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                     }
                     H8G0( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63ServicoExecutanteNome, "")), 75, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(527, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(326, Gx_line+0, 376, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoComentario, "")), 383, Gx_line+0, 558, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48GestaoServicoValor, "")), 583, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 183, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 283, Gx_line+0, 375, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(227, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  if ( AV107GXLvl112 == 0 )
                  {
                     /* Using cursor P008G12 */
                     pr_default.execute(10, new Object[] {AV41GestaoServicoId});
                     while ( (pr_default.getStatus(10) != 101) )
                     {
                        A55ServicoExecutanteId = P008G12_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P008G12_n55ServicoExecutanteId[0];
                        A38GestaoServicoId = P008G12_A38GestaoServicoId[0];
                        A56ServicoExecutanteNome = P008G12_A56ServicoExecutanteNome[0];
                        A131GestaoServicoExecutanteId = P008G12_A131GestaoServicoExecutanteId[0];
                        A56ServicoExecutanteNome = P008G12_A56ServicoExecutanteNome[0];
                        AV63ServicoExecutanteNome = A56ServicoExecutanteNome;
                        H8G0( false, 17) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63ServicoExecutanteNome, "")), 75, Gx_line+0, 167, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(527, Gx_line+0, 577, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(326, Gx_line+0, 376, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(125, Gx_line+0, 175, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(67, Gx_line+0, 684, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33GestaoServicoComentario, "")), 383, Gx_line+0, 558, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48GestaoServicoValor, "")), 583, Gx_line+0, 675, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Inicio, "")), 183, Gx_line+0, 275, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Termino, "")), 283, Gx_line+0, 375, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(227, Gx_line+0, 277, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        pr_default.readNext(10);
                     }
                     pr_default.close(10);
                  }
                  H8G0( false, 202) ;
                  getPrinter().GxDrawLine(83, Gx_line+150, 333, Gx_line+150, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(417, Gx_line+150, 667, Gx_line+150, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 150, Gx_line+167, 254, Gx_line+181, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 467, Gx_line+167, 602, Gx_line+181, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawRect(375, Gx_line+100, 400, Gx_line+117, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+202);
                  /* Eject command */
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(P_lines+1);
                  AV62ServicoExecutanteIdCollection.Clear();
                  AV89NaturezaIdCollection.Clear();
               }
               AV97GXV1 = (int)(AV97GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8G0( true, 0) ;
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
         AV110GXLvl141 = 0;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              A325TipoServicoId ,
                                              AV82ServicoNaturezaIdCollection ,
                                              AV82ServicoNaturezaIdCollection.Count ,
                                              AV41GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008G13 */
         pr_default.execute(11, new Object[] {AV41GestaoServicoId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A325TipoServicoId = P008G13_A325TipoServicoId[0];
            A38GestaoServicoId = P008G13_A38GestaoServicoId[0];
            A323GestaoServicoTipoId = P008G13_A323GestaoServicoTipoId[0];
            AV110GXLvl141 = 1;
            AV86IsExisteTipoServico = true;
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( AV110GXLvl141 == 0 )
         {
            AV86IsExisteTipoServico = false;
         }
      }

      protected void S121( )
      {
         /* 'VERIFICAEXECUTANTE' Routine */
         returnInSub = false;
         AV111GXLvl151 = 0;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              A55ServicoExecutanteId ,
                                              AV91ExecutanteIdCollection ,
                                              AV91ExecutanteIdCollection.Count ,
                                              AV41GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008G14 */
         pr_default.execute(12, new Object[] {AV41GestaoServicoId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A55ServicoExecutanteId = P008G14_A55ServicoExecutanteId[0];
            n55ServicoExecutanteId = P008G14_n55ServicoExecutanteId[0];
            A38GestaoServicoId = P008G14_A38GestaoServicoId[0];
            A131GestaoServicoExecutanteId = P008G14_A131GestaoServicoExecutanteId[0];
            AV111GXLvl151 = 1;
            AV85IsExisteExecutante = true;
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( AV111GXLvl151 == 0 )
         {
            AV85IsExisteExecutante = false;
         }
      }

      protected void H8G0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV16DateTime, "99/99/99 99:99"), 275, Gx_line+33, 458, Gx_line+48, 1, 0, 0, 0) ;
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
         AV16DateTime = (DateTime)(DateTime.MinValue);
         AV91ExecutanteIdCollection = new GxSimpleCollection<long>();
         AV82ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P008G2_A1EmpresaId = new long[1] ;
         P008G2_A2EmpresaNome = new string[] {""} ;
         P008G2_A3EmpresaCNPJ = new string[] {""} ;
         P008G2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV17Descricao = "";
         AV24EmpresaNome = "";
         AV18EmpresaCNPJ = "";
         AV22EmpresaFotoUrl = "";
         AV75Url = "";
         AV95Empresafoto_GXI = "";
         AV21EmpresaFoto = "";
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         P008G3_A77ServicoEmpresaId = new long[1] ;
         P008G3_A42GestaoServicoStatus = new short[1] ;
         P008G3_A41GestaoServicoPrioridade = new short[1] ;
         P008G3_A36ServicoSetorId = new long[1] ;
         P008G3_A34ServicoClienteId = new long[1] ;
         P008G3_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008G3_A38GestaoServicoId = new long[1] ;
         P008G3_A79GestaoServicoNumero = new long[1] ;
         AV92GestaoServicoIdCollection = new GxSimpleCollection<long>();
         P008G4_A36ServicoSetorId = new long[1] ;
         P008G4_A38GestaoServicoId = new long[1] ;
         P008G4_A79GestaoServicoNumero = new long[1] ;
         P008G4_A40GestaoServicoDescricao = new string[] {""} ;
         P008G4_A35ServicoClienteNome = new string[] {""} ;
         P008G4_A37ServicoSetorNome = new string[] {""} ;
         P008G4_A54ServicoNaturezaNome = new string[] {""} ;
         P008G4_A41GestaoServicoPrioridade = new short[1] ;
         P008G4_A42GestaoServicoStatus = new short[1] ;
         P008G4_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P008G4_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008G4_A157GestaoServicoPrecificacao = new short[1] ;
         P008G4_A53ServicoNaturezaId = new long[1] ;
         P008G4_n53ServicoNaturezaId = new bool[] {false} ;
         P008G4_A129EnderecoId = new long[1] ;
         P008G4_n129EnderecoId = new bool[] {false} ;
         P008G4_A322GestaoServicoTipoDemanda = new short[1] ;
         P008G4_A34ServicoClienteId = new long[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         AV36GestaoServicoDescricao = "";
         AV60ServicoClienteNome = "";
         AV67ServicoSetorNome = "";
         AV65ServicoNaturezaNome = "";
         AV13AuxGestaoServicoPrioridade = "";
         AV14AuxGestaoServicoStatus = "";
         AV38GestaoServicoDtProgramada = DateTime.MinValue;
         AV37GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV45GestaoServicoPrecificacaoVarChar = "";
         AV10TipoDemandaVarChar = "";
         P008G5_A106ClienteEnderecoId = new long[1] ;
         P008G5_A17ClienteId = new long[1] ;
         P008G5_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV26EnderecoLocal = "";
         AV21EmpresaFoto = "";
         sImgUrl = "";
         AV19EmpresaContato = "";
         AV20EmpresaEndereco = "";
         P008G6_A38GestaoServicoId = new long[1] ;
         P008G6_A326TipoServicoNome = new string[] {""} ;
         P008G6_A329TipoServicoEstimado = new short[1] ;
         P008G6_A325TipoServicoId = new long[1] ;
         P008G6_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV69TempoEstimado = "";
         AV93TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV70TerminoDate = DateTime.MinValue;
         AV89NaturezaIdCollection = new GxSimpleCollection<long>();
         P008G7_A25NaturezaId = new long[1] ;
         P008G7_A26NaturezaNome = new string[] {""} ;
         P008G7_A162NaturezaValor = new decimal[1] ;
         P008G7_A289NaturezaCusto = new decimal[1] ;
         A26NaturezaNome = "";
         AV71TipoServicoNome = "";
         AV54NaturezaValorVarChar = "";
         AV53NaturezaCustoVarChar = "";
         AV74TotalVarChar = "";
         AV73Total2VarChar = "";
         P008G8_A38GestaoServicoId = new long[1] ;
         P008G8_A55ServicoExecutanteId = new long[1] ;
         P008G8_n55ServicoExecutanteId = new bool[] {false} ;
         P008G8_A131GestaoServicoExecutanteId = new long[1] ;
         AV62ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P008G9_A9UsuarioId = new long[1] ;
         P008G9_A173UsuarioFuncaoId = new long[1] ;
         P008G9_n173UsuarioFuncaoId = new bool[] {false} ;
         P008G9_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV9TecnicoNome = "";
         P008G10_A163FuncaoId = new long[1] ;
         AV27FuncaoDiaria = "";
         AV31FuncaoNoturno = "";
         AV32FuncaoViagem = "";
         AV29FuncaoHr50 = "";
         AV30FuncaoHrNormal = "";
         AV28FuncaoHr100 = "";
         P008G11_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008G11_A145OrdemGestaoServicoId = new long[1] ;
         P008G11_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008G11_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008G11_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008G11_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008G11_A140OrdemExecutanteComentario = new string[] {""} ;
         P008G11_A142OrdemExecutanteValor = new decimal[1] ;
         P008G11_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV63ServicoExecutanteNome = "";
         AV80Inicio = "";
         AV81Termino = "";
         AV33GestaoServicoComentario = "";
         AV48GestaoServicoValor = "";
         P008G12_A55ServicoExecutanteId = new long[1] ;
         P008G12_n55ServicoExecutanteId = new bool[] {false} ;
         P008G12_A38GestaoServicoId = new long[1] ;
         P008G12_A56ServicoExecutanteNome = new string[] {""} ;
         P008G12_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         P008G13_A325TipoServicoId = new long[1] ;
         P008G13_A38GestaoServicoId = new long[1] ;
         P008G13_A323GestaoServicoTipoId = new long[1] ;
         P008G14_A55ServicoExecutanteId = new long[1] ;
         P008G14_n55ServicoExecutanteId = new bool[] {false} ;
         P008G14_A38GestaoServicoId = new long[1] ;
         P008G14_A131GestaoServicoExecutanteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatorioosmodelo4__default(),
            new Object[][] {
                new Object[] {
               P008G2_A1EmpresaId, P008G2_A2EmpresaNome, P008G2_A3EmpresaCNPJ, P008G2_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P008G3_A77ServicoEmpresaId, P008G3_A42GestaoServicoStatus, P008G3_A41GestaoServicoPrioridade, P008G3_A36ServicoSetorId, P008G3_A34ServicoClienteId, P008G3_A39GestaoServicoDtHora, P008G3_A38GestaoServicoId, P008G3_A79GestaoServicoNumero
               }
               , new Object[] {
               P008G4_A36ServicoSetorId, P008G4_A38GestaoServicoId, P008G4_A79GestaoServicoNumero, P008G4_A40GestaoServicoDescricao, P008G4_A35ServicoClienteNome, P008G4_A37ServicoSetorNome, P008G4_A54ServicoNaturezaNome, P008G4_A41GestaoServicoPrioridade, P008G4_A42GestaoServicoStatus, P008G4_A43GestaoServicoDtProgramada,
               P008G4_A39GestaoServicoDtHora, P008G4_A157GestaoServicoPrecificacao, P008G4_A53ServicoNaturezaId, P008G4_n53ServicoNaturezaId, P008G4_A129EnderecoId, P008G4_n129EnderecoId, P008G4_A322GestaoServicoTipoDemanda, P008G4_A34ServicoClienteId
               }
               , new Object[] {
               P008G5_A106ClienteEnderecoId, P008G5_A17ClienteId, P008G5_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P008G6_A38GestaoServicoId, P008G6_A326TipoServicoNome, P008G6_A329TipoServicoEstimado, P008G6_A325TipoServicoId, P008G6_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008G7_A25NaturezaId, P008G7_A26NaturezaNome, P008G7_A162NaturezaValor, P008G7_A289NaturezaCusto
               }
               , new Object[] {
               P008G8_A38GestaoServicoId, P008G8_A55ServicoExecutanteId, P008G8_n55ServicoExecutanteId, P008G8_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008G9_A9UsuarioId, P008G9_A173UsuarioFuncaoId, P008G9_n173UsuarioFuncaoId, P008G9_A10UsuarioNome
               }
               , new Object[] {
               P008G10_A163FuncaoId
               }
               , new Object[] {
               P008G11_A133OrdemExecutanteUsuarioId, P008G11_A145OrdemGestaoServicoId, P008G11_A134OrdemExecutanteUsuarioNome, P008G11_A137OrdemExecutanteHrInicio, P008G11_A136OrdemExecutanteDtInicio, P008G11_A139OrdemExecutanteHrConclusao, P008G11_A140OrdemExecutanteComentario, P008G11_A142OrdemExecutanteValor, P008G11_A135OrdemExecutanteId
               }
               , new Object[] {
               P008G12_A55ServicoExecutanteId, P008G12_n55ServicoExecutanteId, P008G12_A38GestaoServicoId, P008G12_A56ServicoExecutanteNome, P008G12_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008G13_A325TipoServicoId, P008G13_A38GestaoServicoId, P008G13_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008G14_A55ServicoExecutanteId, P008G14_n55ServicoExecutanteId, P008G14_A38GestaoServicoId, P008G14_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV46GestaoServicoPrioridade ;
      private short AV47GestaoServicoStatus ;
      private short AV57PerfilUsuario ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short AV44GestaoServicoPrecificacao ;
      private short AV87StatusServico ;
      private short A329TipoServicoEstimado ;
      private short AV107GXLvl112 ;
      private short AV110GXLvl141 ;
      private short AV111GXLvl151 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV97GXV1 ;
      private int Gx_OldLine ;
      private int AV101GXV2 ;
      private int AV104GXV3 ;
      private int AV82ServicoNaturezaIdCollection_Count ;
      private int AV91ExecutanteIdCollection_Count ;
      private long AV78UsuarioId ;
      private long AV61ServicoEmpresaId ;
      private long AV59ServicoClienteId ;
      private long AV66ServicoSetorId ;
      private long A1EmpresaId ;
      private long A34ServicoClienteId ;
      private long A36ServicoSetorId ;
      private long A77ServicoEmpresaId ;
      private long A38GestaoServicoId ;
      private long A79GestaoServicoNumero ;
      private long AV41GestaoServicoId ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long AV42GestaoServicoNumero ;
      private long AV64ServicoNaturezaId ;
      private long AV25EnderecoId ;
      private long AV90AuxServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long AV88NaturezaId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV8ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV77UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV72Total ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV24EmpresaNome ;
      private string AV18EmpresaCNPJ ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV60ServicoClienteNome ;
      private string AV67ServicoSetorNome ;
      private string AV65ServicoNaturezaNome ;
      private string AV13AuxGestaoServicoPrioridade ;
      private string AV14AuxGestaoServicoStatus ;
      private string A107ClienteEnderecoLocal ;
      private string AV26EnderecoLocal ;
      private string sImgUrl ;
      private string AV19EmpresaContato ;
      private string A326TipoServicoNome ;
      private string A26NaturezaNome ;
      private string AV71TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV9TecnicoNome ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV63ServicoExecutanteNome ;
      private string AV80Inicio ;
      private string AV81Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV16DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV37GestaoServicoDtHora ;
      private DateTime AV93TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime AV35GestaoServicoDataInicio ;
      private DateTime AV34GestaoServicoDataConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV38GestaoServicoDtProgramada ;
      private DateTime AV70TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV86IsExisteTipoServico ;
      private bool AV85IsExisteExecutante ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string AV84TecnicoLongVarChar ;
      private string AV83NaturezaLongVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV17Descricao ;
      private string AV22EmpresaFotoUrl ;
      private string AV75Url ;
      private string AV95Empresafoto_GXI ;
      private string A40GestaoServicoDescricao ;
      private string AV36GestaoServicoDescricao ;
      private string AV45GestaoServicoPrecificacaoVarChar ;
      private string AV10TipoDemandaVarChar ;
      private string AV20EmpresaEndereco ;
      private string AV69TempoEstimado ;
      private string AV54NaturezaValorVarChar ;
      private string AV53NaturezaCustoVarChar ;
      private string AV74TotalVarChar ;
      private string AV73Total2VarChar ;
      private string AV27FuncaoDiaria ;
      private string AV31FuncaoNoturno ;
      private string AV32FuncaoViagem ;
      private string AV29FuncaoHr50 ;
      private string AV30FuncaoHrNormal ;
      private string AV28FuncaoHr100 ;
      private string A140OrdemExecutanteComentario ;
      private string AV33GestaoServicoComentario ;
      private string AV48GestaoServicoValor ;
      private string AV21EmpresaFoto ;
      private string Empresafoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV91ExecutanteIdCollection ;
      private GxSimpleCollection<long> AV82ServicoNaturezaIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P008G2_A1EmpresaId ;
      private string[] P008G2_A2EmpresaNome ;
      private string[] P008G2_A3EmpresaCNPJ ;
      private string[] P008G2_A40000EmpresaFoto_GXI ;
      private long[] P008G3_A77ServicoEmpresaId ;
      private short[] P008G3_A42GestaoServicoStatus ;
      private short[] P008G3_A41GestaoServicoPrioridade ;
      private long[] P008G3_A36ServicoSetorId ;
      private long[] P008G3_A34ServicoClienteId ;
      private DateTime[] P008G3_A39GestaoServicoDtHora ;
      private long[] P008G3_A38GestaoServicoId ;
      private long[] P008G3_A79GestaoServicoNumero ;
      private GxSimpleCollection<long> AV92GestaoServicoIdCollection ;
      private long[] P008G4_A36ServicoSetorId ;
      private long[] P008G4_A38GestaoServicoId ;
      private long[] P008G4_A79GestaoServicoNumero ;
      private string[] P008G4_A40GestaoServicoDescricao ;
      private string[] P008G4_A35ServicoClienteNome ;
      private string[] P008G4_A37ServicoSetorNome ;
      private string[] P008G4_A54ServicoNaturezaNome ;
      private short[] P008G4_A41GestaoServicoPrioridade ;
      private short[] P008G4_A42GestaoServicoStatus ;
      private DateTime[] P008G4_A43GestaoServicoDtProgramada ;
      private DateTime[] P008G4_A39GestaoServicoDtHora ;
      private short[] P008G4_A157GestaoServicoPrecificacao ;
      private long[] P008G4_A53ServicoNaturezaId ;
      private bool[] P008G4_n53ServicoNaturezaId ;
      private long[] P008G4_A129EnderecoId ;
      private bool[] P008G4_n129EnderecoId ;
      private short[] P008G4_A322GestaoServicoTipoDemanda ;
      private long[] P008G4_A34ServicoClienteId ;
      private long[] P008G5_A106ClienteEnderecoId ;
      private long[] P008G5_A17ClienteId ;
      private string[] P008G5_A107ClienteEnderecoLocal ;
      private long[] P008G6_A38GestaoServicoId ;
      private string[] P008G6_A326TipoServicoNome ;
      private short[] P008G6_A329TipoServicoEstimado ;
      private long[] P008G6_A325TipoServicoId ;
      private long[] P008G6_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV89NaturezaIdCollection ;
      private long[] P008G7_A25NaturezaId ;
      private string[] P008G7_A26NaturezaNome ;
      private decimal[] P008G7_A162NaturezaValor ;
      private decimal[] P008G7_A289NaturezaCusto ;
      private long[] P008G8_A38GestaoServicoId ;
      private long[] P008G8_A55ServicoExecutanteId ;
      private bool[] P008G8_n55ServicoExecutanteId ;
      private long[] P008G8_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV62ServicoExecutanteIdCollection ;
      private long[] P008G9_A9UsuarioId ;
      private long[] P008G9_A173UsuarioFuncaoId ;
      private bool[] P008G9_n173UsuarioFuncaoId ;
      private string[] P008G9_A10UsuarioNome ;
      private long[] P008G10_A163FuncaoId ;
      private long[] P008G11_A133OrdemExecutanteUsuarioId ;
      private long[] P008G11_A145OrdemGestaoServicoId ;
      private string[] P008G11_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008G11_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008G11_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008G11_A139OrdemExecutanteHrConclusao ;
      private string[] P008G11_A140OrdemExecutanteComentario ;
      private decimal[] P008G11_A142OrdemExecutanteValor ;
      private long[] P008G11_A135OrdemExecutanteId ;
      private long[] P008G12_A55ServicoExecutanteId ;
      private bool[] P008G12_n55ServicoExecutanteId ;
      private long[] P008G12_A38GestaoServicoId ;
      private string[] P008G12_A56ServicoExecutanteNome ;
      private long[] P008G12_A131GestaoServicoExecutanteId ;
      private long[] P008G13_A325TipoServicoId ;
      private long[] P008G13_A38GestaoServicoId ;
      private long[] P008G13_A323GestaoServicoTipoId ;
      private long[] P008G14_A55ServicoExecutanteId ;
      private bool[] P008G14_n55ServicoExecutanteId ;
      private long[] P008G14_A38GestaoServicoId ;
      private long[] P008G14_A131GestaoServicoExecutanteId ;
   }

   public class aprcrelatorioosmodelo4__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008G3( IGxContext context ,
                                             long AV59ServicoClienteId ,
                                             long AV66ServicoSetorId ,
                                             short AV46GestaoServicoPrioridade ,
                                             short AV47GestaoServicoStatus ,
                                             long A34ServicoClienteId ,
                                             long A36ServicoSetorId ,
                                             short A41GestaoServicoPrioridade ,
                                             short A42GestaoServicoStatus ,
                                             DateTime A39GestaoServicoDtHora ,
                                             DateTime AV35GestaoServicoDataInicio ,
                                             DateTime AV34GestaoServicoDataConclusao ,
                                             long A77ServicoEmpresaId ,
                                             long AV61ServicoEmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ServicoEmpresaId], [GestaoServicoStatus], [GestaoServicoPrioridade], [ServicoSetorId] AS ServicoSetorId, [ServicoClienteId] AS ServicoClienteId, [GestaoServicoDtHora], [GestaoServicoId], [GestaoServicoNumero] FROM [GestaoServico]";
         AddWhere(sWhereString, "([GestaoServicoDtHora] >= @AV35GestaoServicoDataInicio and [GestaoServicoDtHora] <= @AV34GestaoServicoDataConclusao)");
         AddWhere(sWhereString, "([ServicoEmpresaId] = @AV61ServicoEmpresaId)");
         if ( ! (0==AV59ServicoClienteId) )
         {
            AddWhere(sWhereString, "([ServicoClienteId] = @AV59ServicoClienteId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV66ServicoSetorId) )
         {
            AddWhere(sWhereString, "([ServicoSetorId] = @AV66ServicoSetorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV46GestaoServicoPrioridade) )
         {
            AddWhere(sWhereString, "([GestaoServicoPrioridade] = @AV46GestaoServicoPrioridade)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV47GestaoServicoStatus) )
         {
            AddWhere(sWhereString, "([GestaoServicoStatus] = @AV47GestaoServicoStatus)");
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

      protected Object[] conditional_P008G13( IGxContext context ,
                                              long A325TipoServicoId ,
                                              GxSimpleCollection<long> AV82ServicoNaturezaIdCollection ,
                                              int AV82ServicoNaturezaIdCollection_Count ,
                                              long AV41GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipoServicoId] AS TipoServicoId, [GestaoServicoId], [GestaoServicoTipoId] FROM [GestaoServicoTipo]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV41GestaoServicoId)");
         if ( ! ( AV82ServicoNaturezaIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82ServicoNaturezaIdCollection, "[TipoServicoId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008G14( IGxContext context ,
                                              long A55ServicoExecutanteId ,
                                              GxSimpleCollection<long> AV91ExecutanteIdCollection ,
                                              int AV91ExecutanteIdCollection_Count ,
                                              long AV41GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV41GestaoServicoId)");
         if ( ! ( AV91ExecutanteIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91ExecutanteIdCollection, "[ServicoExecutanteId] IN (", ")")+")");
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
                     return conditional_P008G3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 11 :
                     return conditional_P008G13(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 12 :
                     return conditional_P008G14(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
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
          Object[] prmP008G2;
          prmP008G2 = new Object[] {
          new ParDef("@AV61ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP008G4;
          prmP008G4 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G5;
          prmP008G5 = new Object[] {
          new ParDef("@AV90AuxServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV25EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G6;
          prmP008G6 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G7;
          prmP008G7 = new Object[] {
          new ParDef("@AV88NaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP008G8;
          prmP008G8 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G9;
          prmP008G9 = new Object[] {
          new ParDef("@AV8ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP008G10;
          prmP008G10 = new Object[] {
          new ParDef("@AV77UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G11;
          prmP008G11 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G12;
          prmP008G12 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G3;
          prmP008G3 = new Object[] {
          new ParDef("@AV35GestaoServicoDataInicio",GXType.Date,8,0) ,
          new ParDef("@AV34GestaoServicoDataConclusao",GXType.Date,8,0) ,
          new ParDef("@AV61ServicoEmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV59ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV66ServicoSetorId",GXType.Decimal,18,0) ,
          new ParDef("@AV46GestaoServicoPrioridade",GXType.Int16,4,0) ,
          new ParDef("@AV47GestaoServicoStatus",GXType.Int16,4,0)
          };
          Object[] prmP008G13;
          prmP008G13 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008G14;
          prmP008G14 = new Object[] {
          new ParDef("@AV41GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008G2", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV61ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G4", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[GestaoServicoTipoDemanda], T1.[ServicoClienteId] AS ServicoClienteId FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G5", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV90AuxServicoClienteId and [ClienteEnderecoId] = @AV25EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G6", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G7", "SELECT [NaturezaId], [NaturezaNome], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV88NaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G8", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV41GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G9", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV8ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G10", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV77UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G11", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G12", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV41GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008G14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G14,100, GxCacheFrequency.OFF ,false,false )
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
