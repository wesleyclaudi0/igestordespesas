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
   public class aprcrelatorioosmodelo3 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV76UsuarioId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV34GestaoServicoDataInicio = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataInicio"));
                  AV33GestaoServicoDataConclusao = context.localUtil.ParseDateParm( GetPar( "GestaoServicoDataConclusao"));
                  AV60ServicoEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoEmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AV58ServicoClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoClienteId"), "."), 18, MidpointRounding.ToEven));
                  AV65ServicoSetorId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoSetorId"), "."), 18, MidpointRounding.ToEven));
                  AV45GestaoServicoPrioridade = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoPrioridade"), "."), 18, MidpointRounding.ToEven));
                  AV46GestaoServicoStatus = (short)(Math.Round(NumberUtil.Val( GetPar( "GestaoServicoStatus"), "."), 18, MidpointRounding.ToEven));
                  AV56PerfilUsuario = (short)(Math.Round(NumberUtil.Val( GetPar( "PerfilUsuario"), "."), 18, MidpointRounding.ToEven));
                  AV86TecnicoLongVarChar = GetPar( "TecnicoLongVarChar");
                  AV87NaturezaLongVarChar = GetPar( "NaturezaLongVarChar");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatorioosmodelo3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatorioosmodelo3( IGxContext context )
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
         this.AV76UsuarioId = aP0_UsuarioId;
         this.AV34GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV33GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV60ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV58ServicoClienteId = aP4_ServicoClienteId;
         this.AV65ServicoSetorId = aP5_ServicoSetorId;
         this.AV45GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV46GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV56PerfilUsuario = aP8_PerfilUsuario;
         this.AV86TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV87NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         this.AV76UsuarioId = aP0_UsuarioId;
         this.AV34GestaoServicoDataInicio = aP1_GestaoServicoDataInicio;
         this.AV33GestaoServicoDataConclusao = aP2_GestaoServicoDataConclusao;
         this.AV60ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV58ServicoClienteId = aP4_ServicoClienteId;
         this.AV65ServicoSetorId = aP5_ServicoSetorId;
         this.AV45GestaoServicoPrioridade = aP6_GestaoServicoPrioridade;
         this.AV46GestaoServicoStatus = aP7_GestaoServicoStatus;
         this.AV56PerfilUsuario = aP8_PerfilUsuario;
         this.AV86TecnicoLongVarChar = aP9_TecnicoLongVarChar;
         this.AV87NaturezaLongVarChar = aP10_NaturezaLongVarChar;
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
         setOutputFileName("RelatorioOSM3.pdf");
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
            AV17DateTime = DateTimeUtil.Now( context);
            AV83ExecutanteIdCollection.FromJSonString(AV86TecnicoLongVarChar, null);
            AV80ServicoNaturezaIdCollection.FromJSonString(AV87NaturezaLongVarChar, null);
            /* Using cursor P008F2 */
            pr_default.execute(0, new Object[] {AV60ServicoEmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P008F2_A1EmpresaId[0];
               A2EmpresaNome = P008F2_A2EmpresaNome[0];
               A3EmpresaCNPJ = P008F2_A3EmpresaCNPJ[0];
               A40000EmpresaFoto_GXI = P008F2_A40000EmpresaFoto_GXI[0];
               AV18Descricao = context.GetMessage( "ORDEM DE SERVIÇO", "");
               AV23EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV19EmpresaCNPJ = StringUtil.Trim( A3EmpresaCNPJ);
               AV21EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV73Url = StringUtil.StringReplace( AV21EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV93Empresafoto_GXI = AV73Url;
               AV20EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV58ServicoClienteId ,
                                                 AV65ServicoSetorId ,
                                                 AV45GestaoServicoPrioridade ,
                                                 AV46GestaoServicoStatus ,
                                                 A34ServicoClienteId ,
                                                 A36ServicoSetorId ,
                                                 A41GestaoServicoPrioridade ,
                                                 A42GestaoServicoStatus ,
                                                 A39GestaoServicoDtHora ,
                                                 AV34GestaoServicoDataInicio ,
                                                 AV33GestaoServicoDataConclusao ,
                                                 A77ServicoEmpresaId ,
                                                 AV60ServicoEmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P008F3 */
            pr_default.execute(1, new Object[] {AV34GestaoServicoDataInicio, AV33GestaoServicoDataConclusao, AV60ServicoEmpresaId, AV58ServicoClienteId, AV65ServicoSetorId, AV45GestaoServicoPrioridade, AV46GestaoServicoStatus});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A77ServicoEmpresaId = P008F3_A77ServicoEmpresaId[0];
               A42GestaoServicoStatus = P008F3_A42GestaoServicoStatus[0];
               A41GestaoServicoPrioridade = P008F3_A41GestaoServicoPrioridade[0];
               A36ServicoSetorId = P008F3_A36ServicoSetorId[0];
               A34ServicoClienteId = P008F3_A34ServicoClienteId[0];
               A39GestaoServicoDtHora = P008F3_A39GestaoServicoDtHora[0];
               A38GestaoServicoId = P008F3_A38GestaoServicoId[0];
               A79GestaoServicoNumero = P008F3_A79GestaoServicoNumero[0];
               AV88GestaoServicoIdCollection.Add(A38GestaoServicoId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV95GXV1 = 1;
            while ( AV95GXV1 <= AV88GestaoServicoIdCollection.Count )
            {
               AV40GestaoServicoId = (long)(AV88GestaoServicoIdCollection.GetNumeric(AV95GXV1));
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
               if ( ( AV82IsExisteTipoServico ) && ( AV81IsExisteExecutante ) )
               {
                  /* Using cursor P008F4 */
                  pr_default.execute(2, new Object[] {AV40GestaoServicoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A36ServicoSetorId = P008F4_A36ServicoSetorId[0];
                     A38GestaoServicoId = P008F4_A38GestaoServicoId[0];
                     A79GestaoServicoNumero = P008F4_A79GestaoServicoNumero[0];
                     A40GestaoServicoDescricao = P008F4_A40GestaoServicoDescricao[0];
                     A35ServicoClienteNome = P008F4_A35ServicoClienteNome[0];
                     A37ServicoSetorNome = P008F4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008F4_A54ServicoNaturezaNome[0];
                     A41GestaoServicoPrioridade = P008F4_A41GestaoServicoPrioridade[0];
                     A42GestaoServicoStatus = P008F4_A42GestaoServicoStatus[0];
                     A43GestaoServicoDtProgramada = P008F4_A43GestaoServicoDtProgramada[0];
                     A39GestaoServicoDtHora = P008F4_A39GestaoServicoDtHora[0];
                     A157GestaoServicoPrecificacao = P008F4_A157GestaoServicoPrecificacao[0];
                     A53ServicoNaturezaId = P008F4_A53ServicoNaturezaId[0];
                     n53ServicoNaturezaId = P008F4_n53ServicoNaturezaId[0];
                     A129EnderecoId = P008F4_A129EnderecoId[0];
                     n129EnderecoId = P008F4_n129EnderecoId[0];
                     A322GestaoServicoTipoDemanda = P008F4_A322GestaoServicoTipoDemanda[0];
                     A34ServicoClienteId = P008F4_A34ServicoClienteId[0];
                     A37ServicoSetorNome = P008F4_A37ServicoSetorNome[0];
                     A54ServicoNaturezaNome = P008F4_A54ServicoNaturezaNome[0];
                     A35ServicoClienteNome = P008F4_A35ServicoClienteNome[0];
                     AV41GestaoServicoNumero = A79GestaoServicoNumero;
                     AV35GestaoServicoDescricao = A40GestaoServicoDescricao;
                     AV59ServicoClienteNome = A35ServicoClienteNome;
                     AV66ServicoSetorNome = A37ServicoSetorNome;
                     AV64ServicoNaturezaNome = A54ServicoNaturezaNome;
                     AV14AuxGestaoServicoPrioridade = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
                     AV15AuxGestaoServicoStatus = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
                     AV37GestaoServicoDtProgramada = A43GestaoServicoDtProgramada;
                     AV36GestaoServicoDtHora = A39GestaoServicoDtHora;
                     AV43GestaoServicoPrecificacao = A157GestaoServicoPrecificacao;
                     AV44GestaoServicoPrecificacaoVarChar = context.GetMessage( gxdomaintipoprecificacao.getDescription(context,A157GestaoServicoPrecificacao), "");
                     AV63ServicoNaturezaId = A53ServicoNaturezaId;
                     AV24EnderecoId = A129EnderecoId;
                     AV10TipoDemandaVarChar = context.GetMessage( gxdomaintipodemanda.getDescription(context,A322GestaoServicoTipoDemanda), "");
                     AV89AuxServicoClienteId = A34ServicoClienteId;
                     AV90StatusServico = A42GestaoServicoStatus;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P008F5 */
                  pr_default.execute(3, new Object[] {AV89AuxServicoClienteId, AV24EnderecoId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A106ClienteEnderecoId = P008F5_A106ClienteEnderecoId[0];
                     A17ClienteId = P008F5_A17ClienteId[0];
                     A107ClienteEnderecoLocal = P008F5_A107ClienteEnderecoLocal[0];
                     AV25EnderecoLocal = StringUtil.Trim( A107ClienteEnderecoLocal);
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  H8F0( false, 235) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Descricao, "")), 250, Gx_line+17, 475, Gx_line+50, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20EmpresaFoto)) ? AV93Empresafoto_GXI : AV20EmpresaFoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 23, Gx_line+5, 208, Gx_line+62) ;
                  getPrinter().GxDrawRect(492, Gx_line+0, 734, Gx_line+33, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Nº da OS", ""), 500, Gx_line+8, 567, Gx_line+26, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 600, Gx_line+9, 692, Gx_line+26, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Data da Abertura:", ""), 500, Gx_line+39, 617, Gx_line+57, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV36GestaoServicoDtHora, "99/99/9999 99:99:99"), 617, Gx_line+42, 717, Gx_line+59, 0, 0, 0, 0) ;
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
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14AuxGestaoServicoPrioridade, "")), 583, Gx_line+77, 725, Gx_line+92, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 500, Gx_line+107, 558, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15AuxGestaoServicoStatus, "")), 558, Gx_line+109, 700, Gx_line+124, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59ServicoClienteNome, "")), 83, Gx_line+75, 216, Gx_line+90, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Endereço:", ""), 225, Gx_line+74, 308, Gx_line+92, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25EnderecoLocal, "")), 308, Gx_line+75, 483, Gx_line+90, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 25, Gx_line+107, 75, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66ServicoSetorNome, "")), 75, Gx_line+108, 217, Gx_line+123, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Precificação:", ""), 225, Gx_line+107, 325, Gx_line+125, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44GestaoServicoPrecificacaoVarChar, "")), 325, Gx_line+108, 467, Gx_line+123, 0, 0, 0, 0) ;
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV37GestaoServicoDtProgramada, "99/99/99"), 631, Gx_line+143, 723, Gx_line+158, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Descrição:", ""), 25, Gx_line+141, 108, Gx_line+159, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35GestaoServicoDescricao, "")), 108, Gx_line+142, 466, Gx_line+159, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(217, Gx_line+100, 492, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+235);
                  /* Using cursor P008F6 */
                  pr_default.execute(4, new Object[] {AV40GestaoServicoId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A38GestaoServicoId = P008F6_A38GestaoServicoId[0];
                     A326TipoServicoNome = P008F6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008F6_A329TipoServicoEstimado[0];
                     A325TipoServicoId = P008F6_A325TipoServicoId[0];
                     A323GestaoServicoTipoId = P008F6_A323GestaoServicoTipoId[0];
                     A326TipoServicoNome = P008F6_A326TipoServicoNome[0];
                     A329TipoServicoEstimado = P008F6_A329TipoServicoEstimado[0];
                     AV64ServicoNaturezaNome = StringUtil.Trim( A326TipoServicoNome);
                     AV68TempoEstimado = StringUtil.Trim( StringUtil.Str( (decimal)(A329TipoServicoEstimado), 4, 0)) + context.GetMessage( " hora(s)", "");
                     AV91TerminoDateTime = DateTimeUtil.ResetTime( AV37GestaoServicoDtProgramada ) ;
                     AV69TerminoDate = DateTimeUtil.ResetTime(DateTimeUtil.TAdd( AV91TerminoDateTime, 3600*(A329TipoServicoEstimado)));
                     AV85NaturezaIdCollection.Add(A325TipoServicoId, 0);
                     H8F0( false, 18) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV69TerminoDate, "99/99/99"), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TempoEstimado, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64ServicoNaturezaNome, "")), 33, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+18);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  if ( AV56PerfilUsuario != 4 )
                  {
                     if ( AV43GestaoServicoPrecificacao == 2 )
                     {
                        H8F0( false, 68) ;
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
                        AV99GXV2 = 1;
                        while ( AV99GXV2 <= AV85NaturezaIdCollection.Count )
                        {
                           AV84NaturezaId = (long)(AV85NaturezaIdCollection.GetNumeric(AV99GXV2));
                           /* Using cursor P008F7 */
                           pr_default.execute(5, new Object[] {AV84NaturezaId});
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A25NaturezaId = P008F7_A25NaturezaId[0];
                              A26NaturezaNome = P008F7_A26NaturezaNome[0];
                              A162NaturezaValor = P008F7_A162NaturezaValor[0];
                              A289NaturezaCusto = P008F7_A289NaturezaCusto[0];
                              AV11TipoServicoNome = StringUtil.Trim( A26NaturezaNome);
                              AV53NaturezaValorVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A162NaturezaValor, 18, 2));
                              AV52NaturezaCustoVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( A289NaturezaCusto, 18, 2));
                              AV71Total = (decimal)(A162NaturezaValor+A289NaturezaCusto);
                              AV72TotalVarChar = context.GetMessage( "R$ ", "") + StringUtil.Trim( StringUtil.Str( AV71Total, 18, 2));
                              H8F0( false, 17) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11TipoServicoNome, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 250, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53NaturezaValorVarChar, "")), 258, Gx_line+0, 416, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52NaturezaCustoVarChar, "")), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              /* Exiting from a For First loop. */
                              if (true) break;
                           }
                           pr_default.close(5);
                           AV99GXV2 = (int)(AV99GXV2+1);
                        }
                        H8F0( false, 33) ;
                        getPrinter().GxDrawRect(483, Gx_line+0, 583, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(483, Gx_line+0, 733, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Total", ""), 492, Gx_line+0, 550, Gx_line+18, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TotalVarChar, "")), 592, Gx_line+0, 717, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+33);
                     }
                     else
                     {
                        if ( AV43GestaoServicoPrecificacao == 1 )
                        {
                           H8F0( false, 68) ;
                           getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(17, Gx_line+50, 734, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "Técnico", ""), 25, Gx_line+50, 150, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(200, Gx_line+50, 300, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "ORÇAMENTO", ""), 333, Gx_line+17, 441, Gx_line+35, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(292, Gx_line+50, 392, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr Normal", ""), 208, Gx_line+50, 283, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr 50%", ""), 308, Gx_line+50, 358, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Hr 100%", ""), 400, Gx_line+50, 467, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(367, Gx_line+50, 492, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Viagem", ""), 500, Gx_line+50, 550, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Noturno", ""), 592, Gx_line+50, 650, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(492, Gx_line+50, 584, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.GetMessage( "Diária", ""), 667, Gx_line+50, 717, Gx_line+68, 0, 0, 0, 0) ;
                           getPrinter().GxDrawRect(583, Gx_line+50, 658, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+68);
                           /* Using cursor P008F8 */
                           pr_default.execute(6, new Object[] {AV40GestaoServicoId});
                           while ( (pr_default.getStatus(6) != 101) )
                           {
                              A38GestaoServicoId = P008F8_A38GestaoServicoId[0];
                              A55ServicoExecutanteId = P008F8_A55ServicoExecutanteId[0];
                              n55ServicoExecutanteId = P008F8_n55ServicoExecutanteId[0];
                              A131GestaoServicoExecutanteId = P008F8_A131GestaoServicoExecutanteId[0];
                              AV61ServicoExecutanteIdCollection.Add(A55ServicoExecutanteId, 0);
                              pr_default.readNext(6);
                           }
                           pr_default.close(6);
                           AV102GXV3 = 1;
                           while ( AV102GXV3 <= AV61ServicoExecutanteIdCollection.Count )
                           {
                              AV8ServicoExecutanteId = (long)(AV61ServicoExecutanteIdCollection.GetNumeric(AV102GXV3));
                              /* Using cursor P008F9 */
                              pr_default.execute(7, new Object[] {AV8ServicoExecutanteId});
                              while ( (pr_default.getStatus(7) != 101) )
                              {
                                 A9UsuarioId = P008F9_A9UsuarioId[0];
                                 A173UsuarioFuncaoId = P008F9_A173UsuarioFuncaoId[0];
                                 n173UsuarioFuncaoId = P008F9_n173UsuarioFuncaoId[0];
                                 A10UsuarioNome = P008F9_A10UsuarioNome[0];
                                 AV75UsuarioFuncaoId = A173UsuarioFuncaoId;
                                 AV9TecnicoNome = StringUtil.Trim( StringUtil.Upper( A10UsuarioNome));
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(7);
                              /* Using cursor P008F10 */
                              pr_default.execute(8, new Object[] {AV75UsuarioFuncaoId});
                              while ( (pr_default.getStatus(8) != 101) )
                              {
                                 A163FuncaoId = P008F10_A163FuncaoId[0];
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(8);
                              H8F0( false, 17) ;
                              getPrinter().GxDrawRect(658, Gx_line+0, 758, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(325, Gx_line+0, 492, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 1, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(200, Gx_line+0, 300, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(392, Gx_line+0, 584, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9TecnicoNome, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29FuncaoHrNormal, "")), 208, Gx_line+0, 300, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28FuncaoHr50, "")), 308, Gx_line+0, 383, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27FuncaoHr100, "")), 400, Gx_line+0, 483, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30FuncaoNoturno, "")), 592, Gx_line+0, 659, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31FuncaoViagem, "")), 500, Gx_line+0, 575, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FuncaoDiaria, "")), 667, Gx_line+0, 734, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              AV102GXV3 = (int)(AV102GXV3+1);
                           }
                        }
                     }
                  }
                  if ( AV90StatusServico != 1 )
                  {
                     H8F0( false, 68) ;
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
                  }
                  AV105GXLvl112 = 0;
                  /* Using cursor P008F11 */
                  pr_default.execute(9, new Object[] {AV40GestaoServicoId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A133OrdemExecutanteUsuarioId = P008F11_A133OrdemExecutanteUsuarioId[0];
                     A145OrdemGestaoServicoId = P008F11_A145OrdemGestaoServicoId[0];
                     A134OrdemExecutanteUsuarioNome = P008F11_A134OrdemExecutanteUsuarioNome[0];
                     A137OrdemExecutanteHrInicio = P008F11_A137OrdemExecutanteHrInicio[0];
                     A136OrdemExecutanteDtInicio = P008F11_A136OrdemExecutanteDtInicio[0];
                     A139OrdemExecutanteHrConclusao = P008F11_A139OrdemExecutanteHrConclusao[0];
                     A140OrdemExecutanteComentario = P008F11_A140OrdemExecutanteComentario[0];
                     A142OrdemExecutanteValor = P008F11_A142OrdemExecutanteValor[0];
                     A135OrdemExecutanteId = P008F11_A135OrdemExecutanteId[0];
                     A134OrdemExecutanteUsuarioNome = P008F11_A134OrdemExecutanteUsuarioNome[0];
                     AV105GXLvl112 = 1;
                     AV62ServicoExecutanteNome = A134OrdemExecutanteUsuarioNome;
                     AV78Inicio = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
                     AV79Termino = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " às ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
                     AV32GestaoServicoComentario = StringUtil.Trim( A140OrdemExecutanteComentario);
                     if ( AV56PerfilUsuario != 4 )
                     {
                        AV47GestaoServicoValor = StringUtil.Trim( StringUtil.Str( A142OrdemExecutanteValor, 18, 2));
                     }
                     H8F0( false, 17) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47GestaoServicoValor, "")), 658, Gx_line+0, 725, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32GestaoServicoComentario, "")), 425, Gx_line+0, 642, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(600, Gx_line+0, 650, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62ServicoExecutanteNome, "")), 25, Gx_line+0, 158, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  if ( AV105GXLvl112 == 0 )
                  {
                     /* Using cursor P008F12 */
                     pr_default.execute(10, new Object[] {AV40GestaoServicoId});
                     while ( (pr_default.getStatus(10) != 101) )
                     {
                        A55ServicoExecutanteId = P008F12_A55ServicoExecutanteId[0];
                        n55ServicoExecutanteId = P008F12_n55ServicoExecutanteId[0];
                        A38GestaoServicoId = P008F12_A38GestaoServicoId[0];
                        A56ServicoExecutanteNome = P008F12_A56ServicoExecutanteNome[0];
                        A131GestaoServicoExecutanteId = P008F12_A131GestaoServicoExecutanteId[0];
                        A56ServicoExecutanteNome = P008F12_A56ServicoExecutanteNome[0];
                        AV62ServicoExecutanteNome = A56ServicoExecutanteNome;
                        H8F0( false, 17) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Termino, "")), 283, Gx_line+0, 408, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Inicio, "")), 175, Gx_line+0, 267, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47GestaoServicoValor, "")), 658, Gx_line+0, 725, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32GestaoServicoComentario, "")), 425, Gx_line+0, 642, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(117, Gx_line+0, 167, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(225, Gx_line+0, 275, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(367, Gx_line+0, 417, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(600, Gx_line+0, 650, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62ServicoExecutanteNome, "")), 25, Gx_line+0, 158, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawRect(17, Gx_line+0, 734, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        pr_default.readNext(10);
                     }
                     pr_default.close(10);
                  }
                  H8F0( false, 214) ;
                  getPrinter().GxDrawLine(92, Gx_line+133, 342, Gx_line+133, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(425, Gx_line+133, 675, Gx_line+133, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 158, Gx_line+150, 262, Gx_line+164, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 475, Gx_line+150, 610, Gx_line+164, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(17, Gx_line+0, 734, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+214);
                  /* Eject command */
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(P_lines+1);
                  AV61ServicoExecutanteIdCollection.Clear();
                  AV85NaturezaIdCollection.Clear();
               }
               AV95GXV1 = (int)(AV95GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8F0( true, 0) ;
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
         AV108GXLvl141 = 0;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              A325TipoServicoId ,
                                              AV80ServicoNaturezaIdCollection ,
                                              AV80ServicoNaturezaIdCollection.Count ,
                                              AV40GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008F13 */
         pr_default.execute(11, new Object[] {AV40GestaoServicoId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A325TipoServicoId = P008F13_A325TipoServicoId[0];
            A38GestaoServicoId = P008F13_A38GestaoServicoId[0];
            A323GestaoServicoTipoId = P008F13_A323GestaoServicoTipoId[0];
            AV108GXLvl141 = 1;
            AV82IsExisteTipoServico = true;
            pr_default.readNext(11);
         }
         pr_default.close(11);
         if ( AV108GXLvl141 == 0 )
         {
            AV82IsExisteTipoServico = false;
         }
      }

      protected void S121( )
      {
         /* 'VERIFICAEXECUTANTE' Routine */
         returnInSub = false;
         AV109GXLvl151 = 0;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              A55ServicoExecutanteId ,
                                              AV83ExecutanteIdCollection ,
                                              AV83ExecutanteIdCollection.Count ,
                                              AV40GestaoServicoId ,
                                              A38GestaoServicoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P008F14 */
         pr_default.execute(12, new Object[] {AV40GestaoServicoId});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A55ServicoExecutanteId = P008F14_A55ServicoExecutanteId[0];
            n55ServicoExecutanteId = P008F14_n55ServicoExecutanteId[0];
            A38GestaoServicoId = P008F14_A38GestaoServicoId[0];
            A131GestaoServicoExecutanteId = P008F14_A131GestaoServicoExecutanteId[0];
            AV109GXLvl151 = 1;
            AV81IsExisteExecutante = true;
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( AV109GXLvl151 == 0 )
         {
            AV81IsExisteExecutante = false;
         }
      }

      protected void H8F0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV17DateTime, "99/99/99 99:99"), 283, Gx_line+33, 466, Gx_line+48, 1, 0, 0, 0) ;
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
         AV17DateTime = (DateTime)(DateTime.MinValue);
         AV83ExecutanteIdCollection = new GxSimpleCollection<long>();
         AV80ServicoNaturezaIdCollection = new GxSimpleCollection<long>();
         P008F2_A1EmpresaId = new long[1] ;
         P008F2_A2EmpresaNome = new string[] {""} ;
         P008F2_A3EmpresaCNPJ = new string[] {""} ;
         P008F2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A3EmpresaCNPJ = "";
         A40000EmpresaFoto_GXI = "";
         AV18Descricao = "";
         AV23EmpresaNome = "";
         AV19EmpresaCNPJ = "";
         AV21EmpresaFotoUrl = "";
         AV73Url = "";
         AV93Empresafoto_GXI = "";
         AV20EmpresaFoto = "";
         A39GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         P008F3_A77ServicoEmpresaId = new long[1] ;
         P008F3_A42GestaoServicoStatus = new short[1] ;
         P008F3_A41GestaoServicoPrioridade = new short[1] ;
         P008F3_A36ServicoSetorId = new long[1] ;
         P008F3_A34ServicoClienteId = new long[1] ;
         P008F3_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008F3_A38GestaoServicoId = new long[1] ;
         P008F3_A79GestaoServicoNumero = new long[1] ;
         AV88GestaoServicoIdCollection = new GxSimpleCollection<long>();
         P008F4_A36ServicoSetorId = new long[1] ;
         P008F4_A38GestaoServicoId = new long[1] ;
         P008F4_A79GestaoServicoNumero = new long[1] ;
         P008F4_A40GestaoServicoDescricao = new string[] {""} ;
         P008F4_A35ServicoClienteNome = new string[] {""} ;
         P008F4_A37ServicoSetorNome = new string[] {""} ;
         P008F4_A54ServicoNaturezaNome = new string[] {""} ;
         P008F4_A41GestaoServicoPrioridade = new short[1] ;
         P008F4_A42GestaoServicoStatus = new short[1] ;
         P008F4_A43GestaoServicoDtProgramada = new DateTime[] {DateTime.MinValue} ;
         P008F4_A39GestaoServicoDtHora = new DateTime[] {DateTime.MinValue} ;
         P008F4_A157GestaoServicoPrecificacao = new short[1] ;
         P008F4_A53ServicoNaturezaId = new long[1] ;
         P008F4_n53ServicoNaturezaId = new bool[] {false} ;
         P008F4_A129EnderecoId = new long[1] ;
         P008F4_n129EnderecoId = new bool[] {false} ;
         P008F4_A322GestaoServicoTipoDemanda = new short[1] ;
         P008F4_A34ServicoClienteId = new long[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         A43GestaoServicoDtProgramada = DateTime.MinValue;
         AV35GestaoServicoDescricao = "";
         AV59ServicoClienteNome = "";
         AV66ServicoSetorNome = "";
         AV64ServicoNaturezaNome = "";
         AV14AuxGestaoServicoPrioridade = "";
         AV15AuxGestaoServicoStatus = "";
         AV37GestaoServicoDtProgramada = DateTime.MinValue;
         AV36GestaoServicoDtHora = (DateTime)(DateTime.MinValue);
         AV44GestaoServicoPrecificacaoVarChar = "";
         AV10TipoDemandaVarChar = "";
         P008F5_A106ClienteEnderecoId = new long[1] ;
         P008F5_A17ClienteId = new long[1] ;
         P008F5_A107ClienteEnderecoLocal = new string[] {""} ;
         A107ClienteEnderecoLocal = "";
         AV25EnderecoLocal = "";
         AV20EmpresaFoto = "";
         sImgUrl = "";
         P008F6_A38GestaoServicoId = new long[1] ;
         P008F6_A326TipoServicoNome = new string[] {""} ;
         P008F6_A329TipoServicoEstimado = new short[1] ;
         P008F6_A325TipoServicoId = new long[1] ;
         P008F6_A323GestaoServicoTipoId = new long[1] ;
         A326TipoServicoNome = "";
         AV68TempoEstimado = "";
         AV91TerminoDateTime = (DateTime)(DateTime.MinValue);
         AV69TerminoDate = DateTime.MinValue;
         AV85NaturezaIdCollection = new GxSimpleCollection<long>();
         P008F7_A25NaturezaId = new long[1] ;
         P008F7_A26NaturezaNome = new string[] {""} ;
         P008F7_A162NaturezaValor = new decimal[1] ;
         P008F7_A289NaturezaCusto = new decimal[1] ;
         A26NaturezaNome = "";
         AV11TipoServicoNome = "";
         AV53NaturezaValorVarChar = "";
         AV52NaturezaCustoVarChar = "";
         AV72TotalVarChar = "";
         P008F8_A38GestaoServicoId = new long[1] ;
         P008F8_A55ServicoExecutanteId = new long[1] ;
         P008F8_n55ServicoExecutanteId = new bool[] {false} ;
         P008F8_A131GestaoServicoExecutanteId = new long[1] ;
         AV61ServicoExecutanteIdCollection = new GxSimpleCollection<long>();
         P008F9_A9UsuarioId = new long[1] ;
         P008F9_A173UsuarioFuncaoId = new long[1] ;
         P008F9_n173UsuarioFuncaoId = new bool[] {false} ;
         P008F9_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV9TecnicoNome = "";
         P008F10_A163FuncaoId = new long[1] ;
         AV29FuncaoHrNormal = "";
         AV28FuncaoHr50 = "";
         AV27FuncaoHr100 = "";
         AV30FuncaoNoturno = "";
         AV31FuncaoViagem = "";
         AV26FuncaoDiaria = "";
         P008F11_A133OrdemExecutanteUsuarioId = new long[1] ;
         P008F11_A145OrdemGestaoServicoId = new long[1] ;
         P008F11_A134OrdemExecutanteUsuarioNome = new string[] {""} ;
         P008F11_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P008F11_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P008F11_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P008F11_A140OrdemExecutanteComentario = new string[] {""} ;
         P008F11_A142OrdemExecutanteValor = new decimal[1] ;
         P008F11_A135OrdemExecutanteId = new long[1] ;
         A134OrdemExecutanteUsuarioNome = "";
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV62ServicoExecutanteNome = "";
         AV78Inicio = "";
         AV79Termino = "";
         AV32GestaoServicoComentario = "";
         AV47GestaoServicoValor = "";
         P008F12_A55ServicoExecutanteId = new long[1] ;
         P008F12_n55ServicoExecutanteId = new bool[] {false} ;
         P008F12_A38GestaoServicoId = new long[1] ;
         P008F12_A56ServicoExecutanteNome = new string[] {""} ;
         P008F12_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         P008F13_A325TipoServicoId = new long[1] ;
         P008F13_A38GestaoServicoId = new long[1] ;
         P008F13_A323GestaoServicoTipoId = new long[1] ;
         P008F14_A55ServicoExecutanteId = new long[1] ;
         P008F14_n55ServicoExecutanteId = new bool[] {false} ;
         P008F14_A38GestaoServicoId = new long[1] ;
         P008F14_A131GestaoServicoExecutanteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatorioosmodelo3__default(),
            new Object[][] {
                new Object[] {
               P008F2_A1EmpresaId, P008F2_A2EmpresaNome, P008F2_A3EmpresaCNPJ, P008F2_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P008F3_A77ServicoEmpresaId, P008F3_A42GestaoServicoStatus, P008F3_A41GestaoServicoPrioridade, P008F3_A36ServicoSetorId, P008F3_A34ServicoClienteId, P008F3_A39GestaoServicoDtHora, P008F3_A38GestaoServicoId, P008F3_A79GestaoServicoNumero
               }
               , new Object[] {
               P008F4_A36ServicoSetorId, P008F4_A38GestaoServicoId, P008F4_A79GestaoServicoNumero, P008F4_A40GestaoServicoDescricao, P008F4_A35ServicoClienteNome, P008F4_A37ServicoSetorNome, P008F4_A54ServicoNaturezaNome, P008F4_A41GestaoServicoPrioridade, P008F4_A42GestaoServicoStatus, P008F4_A43GestaoServicoDtProgramada,
               P008F4_A39GestaoServicoDtHora, P008F4_A157GestaoServicoPrecificacao, P008F4_A53ServicoNaturezaId, P008F4_n53ServicoNaturezaId, P008F4_A129EnderecoId, P008F4_n129EnderecoId, P008F4_A322GestaoServicoTipoDemanda, P008F4_A34ServicoClienteId
               }
               , new Object[] {
               P008F5_A106ClienteEnderecoId, P008F5_A17ClienteId, P008F5_A107ClienteEnderecoLocal
               }
               , new Object[] {
               P008F6_A38GestaoServicoId, P008F6_A326TipoServicoNome, P008F6_A329TipoServicoEstimado, P008F6_A325TipoServicoId, P008F6_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008F7_A25NaturezaId, P008F7_A26NaturezaNome, P008F7_A162NaturezaValor, P008F7_A289NaturezaCusto
               }
               , new Object[] {
               P008F8_A38GestaoServicoId, P008F8_A55ServicoExecutanteId, P008F8_n55ServicoExecutanteId, P008F8_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008F9_A9UsuarioId, P008F9_A173UsuarioFuncaoId, P008F9_n173UsuarioFuncaoId, P008F9_A10UsuarioNome
               }
               , new Object[] {
               P008F10_A163FuncaoId
               }
               , new Object[] {
               P008F11_A133OrdemExecutanteUsuarioId, P008F11_A145OrdemGestaoServicoId, P008F11_A134OrdemExecutanteUsuarioNome, P008F11_A137OrdemExecutanteHrInicio, P008F11_A136OrdemExecutanteDtInicio, P008F11_A139OrdemExecutanteHrConclusao, P008F11_A140OrdemExecutanteComentario, P008F11_A142OrdemExecutanteValor, P008F11_A135OrdemExecutanteId
               }
               , new Object[] {
               P008F12_A55ServicoExecutanteId, P008F12_n55ServicoExecutanteId, P008F12_A38GestaoServicoId, P008F12_A56ServicoExecutanteNome, P008F12_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P008F13_A325TipoServicoId, P008F13_A38GestaoServicoId, P008F13_A323GestaoServicoTipoId
               }
               , new Object[] {
               P008F14_A55ServicoExecutanteId, P008F14_n55ServicoExecutanteId, P008F14_A38GestaoServicoId, P008F14_A131GestaoServicoExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV45GestaoServicoPrioridade ;
      private short AV46GestaoServicoStatus ;
      private short AV56PerfilUsuario ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short A157GestaoServicoPrecificacao ;
      private short A322GestaoServicoTipoDemanda ;
      private short AV43GestaoServicoPrecificacao ;
      private short AV90StatusServico ;
      private short A329TipoServicoEstimado ;
      private short AV105GXLvl112 ;
      private short AV108GXLvl141 ;
      private short AV109GXLvl151 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV95GXV1 ;
      private int Gx_OldLine ;
      private int AV99GXV2 ;
      private int AV102GXV3 ;
      private int AV80ServicoNaturezaIdCollection_Count ;
      private int AV83ExecutanteIdCollection_Count ;
      private long AV76UsuarioId ;
      private long AV60ServicoEmpresaId ;
      private long AV58ServicoClienteId ;
      private long AV65ServicoSetorId ;
      private long A1EmpresaId ;
      private long A34ServicoClienteId ;
      private long A36ServicoSetorId ;
      private long A77ServicoEmpresaId ;
      private long A38GestaoServicoId ;
      private long A79GestaoServicoNumero ;
      private long AV40GestaoServicoId ;
      private long A53ServicoNaturezaId ;
      private long A129EnderecoId ;
      private long AV41GestaoServicoNumero ;
      private long AV63ServicoNaturezaId ;
      private long AV24EnderecoId ;
      private long AV89AuxServicoClienteId ;
      private long A106ClienteEnderecoId ;
      private long A17ClienteId ;
      private long A325TipoServicoId ;
      private long A323GestaoServicoTipoId ;
      private long AV84NaturezaId ;
      private long A25NaturezaId ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long AV8ServicoExecutanteId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV75UsuarioFuncaoId ;
      private long A163FuncaoId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private decimal A162NaturezaValor ;
      private decimal A289NaturezaCusto ;
      private decimal AV71Total ;
      private decimal A142OrdemExecutanteValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A3EmpresaCNPJ ;
      private string AV23EmpresaNome ;
      private string AV19EmpresaCNPJ ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV59ServicoClienteNome ;
      private string AV66ServicoSetorNome ;
      private string AV64ServicoNaturezaNome ;
      private string AV14AuxGestaoServicoPrioridade ;
      private string AV15AuxGestaoServicoStatus ;
      private string A107ClienteEnderecoLocal ;
      private string AV25EnderecoLocal ;
      private string sImgUrl ;
      private string A326TipoServicoNome ;
      private string A26NaturezaNome ;
      private string AV11TipoServicoNome ;
      private string A10UsuarioNome ;
      private string AV9TecnicoNome ;
      private string A134OrdemExecutanteUsuarioNome ;
      private string AV62ServicoExecutanteNome ;
      private string AV78Inicio ;
      private string AV79Termino ;
      private string A56ServicoExecutanteNome ;
      private DateTime AV17DateTime ;
      private DateTime A39GestaoServicoDtHora ;
      private DateTime AV36GestaoServicoDtHora ;
      private DateTime AV91TerminoDateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime AV34GestaoServicoDataInicio ;
      private DateTime AV33GestaoServicoDataConclusao ;
      private DateTime A43GestaoServicoDtProgramada ;
      private DateTime AV37GestaoServicoDtProgramada ;
      private DateTime AV69TerminoDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV82IsExisteTipoServico ;
      private bool AV81IsExisteExecutante ;
      private bool n53ServicoNaturezaId ;
      private bool n129EnderecoId ;
      private bool n55ServicoExecutanteId ;
      private bool n173UsuarioFuncaoId ;
      private string AV86TecnicoLongVarChar ;
      private string AV87NaturezaLongVarChar ;
      private string A40000EmpresaFoto_GXI ;
      private string AV18Descricao ;
      private string AV21EmpresaFotoUrl ;
      private string AV73Url ;
      private string AV93Empresafoto_GXI ;
      private string A40GestaoServicoDescricao ;
      private string AV35GestaoServicoDescricao ;
      private string AV44GestaoServicoPrecificacaoVarChar ;
      private string AV10TipoDemandaVarChar ;
      private string AV68TempoEstimado ;
      private string AV53NaturezaValorVarChar ;
      private string AV52NaturezaCustoVarChar ;
      private string AV72TotalVarChar ;
      private string AV29FuncaoHrNormal ;
      private string AV28FuncaoHr50 ;
      private string AV27FuncaoHr100 ;
      private string AV30FuncaoNoturno ;
      private string AV31FuncaoViagem ;
      private string AV26FuncaoDiaria ;
      private string A140OrdemExecutanteComentario ;
      private string AV32GestaoServicoComentario ;
      private string AV47GestaoServicoValor ;
      private string AV20EmpresaFoto ;
      private string Empresafoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV83ExecutanteIdCollection ;
      private GxSimpleCollection<long> AV80ServicoNaturezaIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P008F2_A1EmpresaId ;
      private string[] P008F2_A2EmpresaNome ;
      private string[] P008F2_A3EmpresaCNPJ ;
      private string[] P008F2_A40000EmpresaFoto_GXI ;
      private long[] P008F3_A77ServicoEmpresaId ;
      private short[] P008F3_A42GestaoServicoStatus ;
      private short[] P008F3_A41GestaoServicoPrioridade ;
      private long[] P008F3_A36ServicoSetorId ;
      private long[] P008F3_A34ServicoClienteId ;
      private DateTime[] P008F3_A39GestaoServicoDtHora ;
      private long[] P008F3_A38GestaoServicoId ;
      private long[] P008F3_A79GestaoServicoNumero ;
      private GxSimpleCollection<long> AV88GestaoServicoIdCollection ;
      private long[] P008F4_A36ServicoSetorId ;
      private long[] P008F4_A38GestaoServicoId ;
      private long[] P008F4_A79GestaoServicoNumero ;
      private string[] P008F4_A40GestaoServicoDescricao ;
      private string[] P008F4_A35ServicoClienteNome ;
      private string[] P008F4_A37ServicoSetorNome ;
      private string[] P008F4_A54ServicoNaturezaNome ;
      private short[] P008F4_A41GestaoServicoPrioridade ;
      private short[] P008F4_A42GestaoServicoStatus ;
      private DateTime[] P008F4_A43GestaoServicoDtProgramada ;
      private DateTime[] P008F4_A39GestaoServicoDtHora ;
      private short[] P008F4_A157GestaoServicoPrecificacao ;
      private long[] P008F4_A53ServicoNaturezaId ;
      private bool[] P008F4_n53ServicoNaturezaId ;
      private long[] P008F4_A129EnderecoId ;
      private bool[] P008F4_n129EnderecoId ;
      private short[] P008F4_A322GestaoServicoTipoDemanda ;
      private long[] P008F4_A34ServicoClienteId ;
      private long[] P008F5_A106ClienteEnderecoId ;
      private long[] P008F5_A17ClienteId ;
      private string[] P008F5_A107ClienteEnderecoLocal ;
      private long[] P008F6_A38GestaoServicoId ;
      private string[] P008F6_A326TipoServicoNome ;
      private short[] P008F6_A329TipoServicoEstimado ;
      private long[] P008F6_A325TipoServicoId ;
      private long[] P008F6_A323GestaoServicoTipoId ;
      private GxSimpleCollection<long> AV85NaturezaIdCollection ;
      private long[] P008F7_A25NaturezaId ;
      private string[] P008F7_A26NaturezaNome ;
      private decimal[] P008F7_A162NaturezaValor ;
      private decimal[] P008F7_A289NaturezaCusto ;
      private long[] P008F8_A38GestaoServicoId ;
      private long[] P008F8_A55ServicoExecutanteId ;
      private bool[] P008F8_n55ServicoExecutanteId ;
      private long[] P008F8_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV61ServicoExecutanteIdCollection ;
      private long[] P008F9_A9UsuarioId ;
      private long[] P008F9_A173UsuarioFuncaoId ;
      private bool[] P008F9_n173UsuarioFuncaoId ;
      private string[] P008F9_A10UsuarioNome ;
      private long[] P008F10_A163FuncaoId ;
      private long[] P008F11_A133OrdemExecutanteUsuarioId ;
      private long[] P008F11_A145OrdemGestaoServicoId ;
      private string[] P008F11_A134OrdemExecutanteUsuarioNome ;
      private DateTime[] P008F11_A137OrdemExecutanteHrInicio ;
      private DateTime[] P008F11_A136OrdemExecutanteDtInicio ;
      private DateTime[] P008F11_A139OrdemExecutanteHrConclusao ;
      private string[] P008F11_A140OrdemExecutanteComentario ;
      private decimal[] P008F11_A142OrdemExecutanteValor ;
      private long[] P008F11_A135OrdemExecutanteId ;
      private long[] P008F12_A55ServicoExecutanteId ;
      private bool[] P008F12_n55ServicoExecutanteId ;
      private long[] P008F12_A38GestaoServicoId ;
      private string[] P008F12_A56ServicoExecutanteNome ;
      private long[] P008F12_A131GestaoServicoExecutanteId ;
      private long[] P008F13_A325TipoServicoId ;
      private long[] P008F13_A38GestaoServicoId ;
      private long[] P008F13_A323GestaoServicoTipoId ;
      private long[] P008F14_A55ServicoExecutanteId ;
      private bool[] P008F14_n55ServicoExecutanteId ;
      private long[] P008F14_A38GestaoServicoId ;
      private long[] P008F14_A131GestaoServicoExecutanteId ;
   }

   public class aprcrelatorioosmodelo3__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008F3( IGxContext context ,
                                             long AV58ServicoClienteId ,
                                             long AV65ServicoSetorId ,
                                             short AV45GestaoServicoPrioridade ,
                                             short AV46GestaoServicoStatus ,
                                             long A34ServicoClienteId ,
                                             long A36ServicoSetorId ,
                                             short A41GestaoServicoPrioridade ,
                                             short A42GestaoServicoStatus ,
                                             DateTime A39GestaoServicoDtHora ,
                                             DateTime AV34GestaoServicoDataInicio ,
                                             DateTime AV33GestaoServicoDataConclusao ,
                                             long A77ServicoEmpresaId ,
                                             long AV60ServicoEmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ServicoEmpresaId], [GestaoServicoStatus], [GestaoServicoPrioridade], [ServicoSetorId] AS ServicoSetorId, [ServicoClienteId] AS ServicoClienteId, [GestaoServicoDtHora], [GestaoServicoId], [GestaoServicoNumero] FROM [GestaoServico]";
         AddWhere(sWhereString, "([GestaoServicoDtHora] >= @AV34GestaoServicoDataInicio and [GestaoServicoDtHora] <= @AV33GestaoServicoDataConclusao)");
         AddWhere(sWhereString, "([ServicoEmpresaId] = @AV60ServicoEmpresaId)");
         if ( ! (0==AV58ServicoClienteId) )
         {
            AddWhere(sWhereString, "([ServicoClienteId] = @AV58ServicoClienteId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV65ServicoSetorId) )
         {
            AddWhere(sWhereString, "([ServicoSetorId] = @AV65ServicoSetorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV45GestaoServicoPrioridade) )
         {
            AddWhere(sWhereString, "([GestaoServicoPrioridade] = @AV45GestaoServicoPrioridade)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV46GestaoServicoStatus) )
         {
            AddWhere(sWhereString, "([GestaoServicoStatus] = @AV46GestaoServicoStatus)");
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

      protected Object[] conditional_P008F13( IGxContext context ,
                                              long A325TipoServicoId ,
                                              GxSimpleCollection<long> AV80ServicoNaturezaIdCollection ,
                                              int AV80ServicoNaturezaIdCollection_Count ,
                                              long AV40GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipoServicoId] AS TipoServicoId, [GestaoServicoId], [GestaoServicoTipoId] FROM [GestaoServicoTipo]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV40GestaoServicoId)");
         if ( ! ( AV80ServicoNaturezaIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80ServicoNaturezaIdCollection, "[TipoServicoId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008F14( IGxContext context ,
                                              long A55ServicoExecutanteId ,
                                              GxSimpleCollection<long> AV83ExecutanteIdCollection ,
                                              int AV83ExecutanteIdCollection_Count ,
                                              long AV40GestaoServicoId ,
                                              long A38GestaoServicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoId], [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante]";
         AddWhere(sWhereString, "([GestaoServicoId] = @AV40GestaoServicoId)");
         if ( ! ( AV83ExecutanteIdCollection_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83ExecutanteIdCollection, "[ServicoExecutanteId] IN (", ")")+")");
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
                     return conditional_P008F3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 11 :
                     return conditional_P008F13(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 12 :
                     return conditional_P008F14(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
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
          Object[] prmP008F2;
          prmP008F2 = new Object[] {
          new ParDef("@AV60ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP008F4;
          prmP008F4 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F5;
          prmP008F5 = new Object[] {
          new ParDef("@AV89AuxServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV24EnderecoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F6;
          prmP008F6 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F7;
          prmP008F7 = new Object[] {
          new ParDef("@AV84NaturezaId",GXType.Decimal,18,0)
          };
          Object[] prmP008F8;
          prmP008F8 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F9;
          prmP008F9 = new Object[] {
          new ParDef("@AV8ServicoExecutanteId",GXType.Decimal,18,0)
          };
          Object[] prmP008F10;
          prmP008F10 = new Object[] {
          new ParDef("@AV75UsuarioFuncaoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F11;
          prmP008F11 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F12;
          prmP008F12 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F3;
          prmP008F3 = new Object[] {
          new ParDef("@AV34GestaoServicoDataInicio",GXType.Date,8,0) ,
          new ParDef("@AV33GestaoServicoDataConclusao",GXType.Date,8,0) ,
          new ParDef("@AV60ServicoEmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV58ServicoClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV65ServicoSetorId",GXType.Decimal,18,0) ,
          new ParDef("@AV45GestaoServicoPrioridade",GXType.Int16,4,0) ,
          new ParDef("@AV46GestaoServicoStatus",GXType.Int16,4,0)
          };
          Object[] prmP008F13;
          prmP008F13 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP008F14;
          prmP008F14 = new Object[] {
          new ParDef("@AV40GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008F2", "SELECT [EmpresaId], [EmpresaNome], [EmpresaCNPJ], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV60ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F4", "SELECT T1.[ServicoSetorId] AS ServicoSetorId, T1.[GestaoServicoId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T4.[ClienteNome] AS ServicoClienteNome, T2.[SetorNome] AS ServicoSetorNome, T3.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus], T1.[GestaoServicoDtProgramada], T1.[GestaoServicoDtHora], T1.[GestaoServicoPrecificacao], T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[EnderecoId], T1.[GestaoServicoTipoDemanda], T1.[ServicoClienteId] AS ServicoClienteId FROM ((([GestaoServico] T1 INNER JOIN [Setor] T2 ON T2.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[ServicoNaturezaId]) INNER JOIN [Cliente] T4 ON T4.[ClienteId] = T1.[ServicoClienteId]) WHERE T1.[GestaoServicoId] = @AV40GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F5", "SELECT [ClienteEnderecoId], [ClienteId], [ClienteEnderecoLocal] FROM [ClienteEndereco] WHERE [ClienteId] = @AV89AuxServicoClienteId and [ClienteEnderecoId] = @AV24EnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F6", "SELECT T1.[GestaoServicoId], T2.[NaturezaNome] AS TipoServicoNome, T2.[NaturezaTempoEstimado] AS TipoServicoEstimado, T1.[TipoServicoId] AS TipoServicoId, T1.[GestaoServicoTipoId] FROM ([GestaoServicoTipo] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[TipoServicoId]) WHERE T1.[GestaoServicoId] = @AV40GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F7", "SELECT [NaturezaId], [NaturezaNome], [NaturezaValor], [NaturezaCusto] FROM [Natureza] WHERE [NaturezaId] = @AV84NaturezaId ORDER BY [NaturezaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F8", "SELECT [GestaoServicoId], [ServicoExecutanteId] AS ServicoExecutanteId, [GestaoServicoExecutanteId] FROM [GestaoServicoExecutante] WHERE [GestaoServicoId] = @AV40GestaoServicoId ORDER BY [GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F9", "SELECT [UsuarioId], [UsuarioFuncaoId], [UsuarioNome] FROM [Usuario] WHERE [UsuarioId] = @AV8ServicoExecutanteId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F10", "SELECT [FuncaoId] FROM [Funcao] WHERE [FuncaoId] = @AV75UsuarioFuncaoId ORDER BY [FuncaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F11", "SELECT T1.[OrdemExecutanteUsuarioId] AS OrdemExecutanteUsuarioId, T1.[OrdemGestaoServicoId], T2.[UsuarioNome] AS OrdemExecutanteUsuarioNome, T1.[OrdemExecutanteHrInicio], T1.[OrdemExecutanteDtInicio], T1.[OrdemExecutanteHrConclusao], T1.[OrdemExecutanteComentario], T1.[OrdemExecutanteValor], T1.[OrdemExecutanteId] FROM ([OrdemExecutante] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[OrdemExecutanteUsuarioId]) WHERE T1.[OrdemGestaoServicoId] = @AV40GestaoServicoId ORDER BY T1.[OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F12", "SELECT T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV40GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008F14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F14,100, GxCacheFrequency.OFF ,false,false )
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
