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
   public class aimpressaomedicaounica : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "ContratoId");
            if ( ! entryPointCalled )
            {
               AV20ContratoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV95Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AV96Tela = (short)(Math.Round(NumberUtil.Val( GetPar( "Tela"), "."), 18, MidpointRounding.ToEven));
                  AV97AuxMedicaoId = (long)(Math.Round(NumberUtil.Val( GetPar( "AuxMedicaoId"), "."), 18, MidpointRounding.ToEven));
                  AV98Tipo = (short)(Math.Round(NumberUtil.Val( GetPar( "Tipo"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aimpressaomedicaounica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aimpressaomedicaounica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ContratoId ,
                           long aP1_Id ,
                           short aP2_Tela ,
                           long aP3_AuxMedicaoId ,
                           short aP4_Tipo )
      {
         this.AV20ContratoId = aP0_ContratoId;
         this.AV95Id = aP1_Id;
         this.AV96Tela = aP2_Tela;
         this.AV97AuxMedicaoId = aP3_AuxMedicaoId;
         this.AV98Tipo = aP4_Tipo;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ContratoId ,
                                 long aP1_Id ,
                                 short aP2_Tela ,
                                 long aP3_AuxMedicaoId ,
                                 short aP4_Tipo )
      {
         this.AV20ContratoId = aP0_ContratoId;
         this.AV95Id = aP1_Id;
         this.AV96Tela = aP2_Tela;
         this.AV97AuxMedicaoId = aP3_AuxMedicaoId;
         this.AV98Tipo = aP4_Tipo;
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
         setOutputFileName("ImpressaoMedicao.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 14947, 0, 1, 1, 0, 1, 1) )
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
            AV38SDTContexto.FromJSonString(AV8WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV30EmpresaId = AV38SDTContexto.gxTpr_Empresaid;
            AV60DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00GO2 */
            pr_default.execute(0, new Object[] {AV30EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00GO2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P00GO2_A40000EmpresaFoto_GXI[0];
               A3EmpresaCNPJ = P00GO2_A3EmpresaCNPJ[0];
               A4EmpresaContato = P00GO2_A4EmpresaContato[0];
               A15EmpresaEmail = P00GO2_A15EmpresaEmail[0];
               A2EmpresaNome = P00GO2_A2EmpresaNome[0];
               AV29EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV40Url = StringUtil.StringReplace( AV29EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV100Empresafoto_GXI = AV40Url;
               AV28EmpresaFoto = "";
               AV25EmpresaCNPJ = A3EmpresaCNPJ;
               AV26EmpresaContato = A4EmpresaContato;
               AV27EmpresaEmail = A15EmpresaEmail;
               AV31EmpresaNome = A2EmpresaNome;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00GO3 */
            pr_default.execute(1, new Object[] {AV20ContratoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A392TipoContratoId = P00GO3_A392TipoContratoId[0];
               n392TipoContratoId = P00GO3_n392TipoContratoId[0];
               A344ContratoId = P00GO3_A344ContratoId[0];
               A345ContratoNome = P00GO3_A345ContratoNome[0];
               A350ContratoDiaEnvioNota = P00GO3_A350ContratoDiaEnvioNota[0];
               A400ContratoDiasVencimento = P00GO3_A400ContratoDiasVencimento[0];
               A396ContratoDtAssinatura = P00GO3_A396ContratoDtAssinatura[0];
               A404ContratoDtFimVigencia = P00GO3_A404ContratoDtFimVigencia[0];
               A395ContratoDtInicioVigencia = P00GO3_A395ContratoDtInicioVigencia[0];
               A352ContratoFinanceiroNome = P00GO3_A352ContratoFinanceiroNome[0];
               A349ContratoPrazo = P00GO3_A349ContratoPrazo[0];
               A397ContratoValor = P00GO3_A397ContratoValor[0];
               A351ContratoVencimento = P00GO3_A351ContratoVencimento[0];
               A393TipoContratoDescricao = P00GO3_A393TipoContratoDescricao[0];
               A637ContratoModalidade = P00GO3_A637ContratoModalidade[0];
               A17ClienteId = P00GO3_A17ClienteId[0];
               A393TipoContratoDescricao = P00GO3_A393TipoContratoDescricao[0];
               AV21ContratoNome = context.GetMessage( "Nome: ", "") + StringUtil.Trim( A345ContratoNome);
               AV14ContratoDiaEnvioNota = context.GetMessage( "Dia para Envio da Nota: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A350ContratoDiaEnvioNota), 2, 0));
               AV15ContratoDiasVencimento = StringUtil.Trim( StringUtil.Str( (decimal)(A400ContratoDiasVencimento), 4, 0));
               AV16ContratoDtAssinatura = context.GetMessage( "Data da Assinatura: ", "") + StringUtil.Trim( context.localUtil.DToC( A396ContratoDtAssinatura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV17ContratoDtFimVigencia = context.GetMessage( "Fim da Vigência: ", "") + StringUtil.Trim( context.localUtil.DToC( A404ContratoDtFimVigencia, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV18ContratoDtInicioVigencia = context.GetMessage( "Inicío da Vigência: ", "") + StringUtil.Trim( context.localUtil.DToC( A395ContratoDtInicioVigencia, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV37ResponsavelNome = context.GetMessage( "Responsável Financeiro: ", "") + A352ContratoFinanceiroNome;
               AV22ContratoPrazo = context.GetMessage( "Prazo em Meses: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A349ContratoPrazo), 2, 0));
               AV23ContratoValor = context.GetMessage( "Valor: R$ ", "") + StringUtil.Trim( StringUtil.Str( A397ContratoValor, 18, 2));
               AV24ContratoVencimento = context.GetMessage( "Dia do Vencimento: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A351ContratoVencimento), 2, 0));
               AV39TipoContratoDescricao = context.GetMessage( "Tipo de Contrato: ", "") + A393TipoContratoDescricao;
               AV35Modalidade = context.GetMessage( "Modalidade: ", "") + context.GetMessage( gxdomainmodalidade.getDescription(context,A637ContratoModalidade), "");
               AV94ClienteId = A17ClienteId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00GO4 */
            pr_default.execute(2, new Object[] {AV94ClienteId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A17ClienteId = P00GO4_A17ClienteId[0];
               A624ClienteCNPJ = P00GO4_A624ClienteCNPJ[0];
               A19ClienteContato = P00GO4_A19ClienteContato[0];
               A20ClienteEmail = P00GO4_A20ClienteEmail[0];
               A18ClienteNome = P00GO4_A18ClienteNome[0];
               A118ClienteTelefone = P00GO4_A118ClienteTelefone[0];
               AV9ClienteCNPJ = context.GetMessage( "CNPJ: ", "") + A624ClienteCNPJ;
               AV10ClienteContato = context.GetMessage( "Contato: ", "") + A19ClienteContato;
               AV11ClienteEmail = A20ClienteEmail;
               AV12ClienteNome = A18ClienteNome;
               AV13ClienteTelefone = context.GetMessage( "Telefone: ", "") + A118ClienteTelefone;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            HGO0( false, 168) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ContratoPrazo, "")), 47, Gx_line+133, 400, Gx_line+148, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+166, 1000, Gx_line+166, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dados do Contrato", ""), 47, Gx_line+13, 260, Gx_line+34, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(393, Gx_line+27, 493, Gx_line+147, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ContratoDtFimVigencia, "")), 47, Gx_line+107, 400, Gx_line+122, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ContratoDtInicioVigencia, "")), 47, Gx_line+80, 400, Gx_line+95, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ContratoNome, "")), 47, Gx_line+53, 400, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ContratoValor, "")), 587, Gx_line+27, 940, Gx_line+42, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ContratoVencimento, "")), 587, Gx_line+53, 940, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TipoContratoDescricao, "")), 587, Gx_line+80, 940, Gx_line+95, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37ResponsavelNome, "")), 587, Gx_line+107, 940, Gx_line+122, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Modalidade, "")), 587, Gx_line+133, 940, Gx_line+148, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+168);
            /* Using cursor P00GO5 */
            pr_default.execute(3, new Object[] {AV97AuxMedicaoId, AV20ContratoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A556MedicaoUsuarioId = P00GO5_A556MedicaoUsuarioId[0];
               A550MedicaoId = P00GO5_A550MedicaoId[0];
               A547MedicaoContratoId = P00GO5_A547MedicaoContratoId[0];
               A557MedicaoUsuarioNome = P00GO5_A557MedicaoUsuarioNome[0];
               A551MedicaoDtHora = P00GO5_A551MedicaoDtHora[0];
               A552MedicaoMesAno = P00GO5_A552MedicaoMesAno[0];
               A557MedicaoUsuarioNome = P00GO5_A557MedicaoUsuarioNome[0];
               AV36Nome = A557MedicaoUsuarioNome;
               AV32MedicaoDtHora = A551MedicaoDtHora;
               AV34MedicaoMesAno = A552MedicaoMesAno;
               AV33MedicaoId = A550MedicaoId;
               HGO0( false, 104) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Medições", ""), 47, Gx_line+9, 260, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Mês/Ano", ""), 653, Gx_line+53, 866, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Usuário", ""), 347, Gx_line+53, 560, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Data", ""), 47, Gx_line+53, 260, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34MedicaoMesAno, "")), 653, Gx_line+80, 866, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Nome, "")), 347, Gx_line+80, 560, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV32MedicaoDtHora, "99/99/9999 99:99:99"), 47, Gx_line+80, 260, Gx_line+95, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+104);
               if ( AV98Tipo == 1 )
               {
                  HGO0( false, 42) ;
                  getPrinter().GxDrawRect(33, Gx_line+0, 993, Gx_line+40, 1, 0, 0, 0, 1, 230, 244, 247, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Profissional", ""), 47, Gx_line+13, 134, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Diferença", ""), 667, Gx_line+13, 780, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+40, 993, Gx_line+40, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+0, 993, Gx_line+0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Hora/Mês", ""), 173, Gx_line+13, 260, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Qtd", ""), 273, Gx_line+13, 326, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 360, Gx_line+13, 413, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Total", ""), 440, Gx_line+13, 493, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Medição (Horas)", ""), 520, Gx_line+13, 633, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 820, Gx_line+13, 913, Gx_line+29, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+42);
                  pr_default.dynParam(4, new Object[]{ new Object[]{
                                                       AV95Id ,
                                                       A549MedicaoFuncaoId ,
                                                       AV33MedicaoId ,
                                                       A550MedicaoId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00GO6 */
                  pr_default.execute(4, new Object[] {AV33MedicaoId, AV95Id});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A549MedicaoFuncaoId = P00GO6_A549MedicaoFuncaoId[0];
                     A550MedicaoId = P00GO6_A550MedicaoId[0];
                     A559MedicaoFuncaoNome = P00GO6_A559MedicaoFuncaoNome[0];
                     A555MedicaoDiferenca = P00GO6_A555MedicaoDiferenca[0];
                     A554MedicaoHoras = P00GO6_A554MedicaoHoras[0];
                     A570MedicaoProfissionalHoraMes = P00GO6_A570MedicaoProfissionalHoraMes[0];
                     A568MedicaoProfissionalSaldo = P00GO6_A568MedicaoProfissionalSaldo[0];
                     A569MedicaoProfissionalQtd = P00GO6_A569MedicaoProfissionalQtd[0];
                     A571MedicaoProfissionalValor = P00GO6_A571MedicaoProfissionalValor[0];
                     A559MedicaoFuncaoNome = P00GO6_A559MedicaoFuncaoNome[0];
                     A572MedicaoProfissionalTotal = (decimal)(A571MedicaoProfissionalValor*A569MedicaoProfissionalQtd);
                     AV41FuncaoNome = A559MedicaoFuncaoNome;
                     AV69MedicaoDiferenca = A555MedicaoDiferenca;
                     AV72MedicaoHoras = A554MedicaoHoras;
                     AV42HoraMes = A570MedicaoProfissionalHoraMes;
                     AV88Valor = A571MedicaoProfissionalValor;
                     AV86Total = A572MedicaoProfissionalTotal;
                     AV92MedicaoProfissionalSaldo = A568MedicaoProfissionalSaldo;
                     HGO0( false, 39) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41FuncaoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV69MedicaoDiferenca), "ZZZ9")), 667, Gx_line+13, 767, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV92MedicaoProfissionalSaldo), "ZZZZZZZZZZZ9")), 820, Gx_line+13, 928, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV72MedicaoHoras), "ZZZ9")), 527, Gx_line+13, 619, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86Total, "ZZZZZZZZZZZZZZ9.99")), 440, Gx_line+13, 498, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43MedicaoQtd, "ZZZZZZZZ9.99")), 273, Gx_line+13, 323, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88Valor, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 418, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42HoraMes), "ZZZ9")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+39);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
               }
               else if ( AV98Tipo == 2 )
               {
                  HGO0( false, 42) ;
                  getPrinter().GxDrawRect(33, Gx_line+0, 1000, Gx_line+40, 1, 0, 0, 0, 1, 230, 244, 247, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 593, Gx_line+13, 651, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Qtd Inicial", ""), 367, Gx_line+13, 447, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Qtd", ""), 487, Gx_line+13, 545, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Produto", ""), 47, Gx_line+13, 139, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Preço", ""), 173, Gx_line+13, 265, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Unidade", ""), 273, Gx_line+13, 331, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+0, 1000, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+42);
                  pr_default.dynParam(5, new Object[]{ new Object[]{
                                                       AV95Id ,
                                                       A548MedicaoProdutoId ,
                                                       AV33MedicaoId ,
                                                       A550MedicaoId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00GO7 */
                  pr_default.execute(5, new Object[] {AV33MedicaoId, AV95Id});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A548MedicaoProdutoId = P00GO7_A548MedicaoProdutoId[0];
                     A550MedicaoId = P00GO7_A550MedicaoId[0];
                     A558MedicaoProdutoNome = P00GO7_A558MedicaoProdutoNome[0];
                     A553MedicaoQtd = P00GO7_A553MedicaoQtd[0];
                     A563MedicaoProdutoPreco = P00GO7_A563MedicaoProdutoPreco[0];
                     A564MedicaoProdutoUn = P00GO7_A564MedicaoProdutoUn[0];
                     A566MedicaoProdutoQtdInicial = P00GO7_A566MedicaoProdutoQtdInicial[0];
                     A567MedicaoProdutoSaldo = P00GO7_A567MedicaoProdutoSaldo[0];
                     A558MedicaoProdutoNome = P00GO7_A558MedicaoProdutoNome[0];
                     A563MedicaoProdutoPreco = P00GO7_A563MedicaoProdutoPreco[0];
                     A564MedicaoProdutoUn = P00GO7_A564MedicaoProdutoUn[0];
                     AV80ProdutoNome = A558MedicaoProdutoNome;
                     AV83Qtd = (short)(Math.Round(A553MedicaoQtd, 18, MidpointRounding.ToEven));
                     AV81ProdutoPreco = A563MedicaoProdutoPreco;
                     AV82ProdutoUnidade = A564MedicaoProdutoUn;
                     AV90MedicaoProdutoQtdInicial = A566MedicaoProdutoQtdInicial;
                     AV91MedicaoProdutoSaldo = A567MedicaoProdutoSaldo;
                     HGO0( false, 40) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91MedicaoProdutoSaldo, "ZZZZZZZZ9.99")), 593, Gx_line+13, 685, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90MedicaoProdutoQtdInicial, "ZZZZZZZZ9.99")), 367, Gx_line+13, 450, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV83Qtd), "ZZZ9")), 487, Gx_line+13, 537, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80ProdutoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82ProdutoUnidade, "")), 273, Gx_line+13, 340, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81ProdutoPreco, "ZZZZZZZZZZZZZZ9.99")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+40);
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
               }
               else if ( AV98Tipo == 3 )
               {
                  HGO0( false, 42) ;
                  getPrinter().GxDrawRect(33, Gx_line+0, 1000, Gx_line+40, 1, 0, 0, 0, 1, 230, 244, 247, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 593, Gx_line+13, 776, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Quantidade", ""), 360, Gx_line+13, 480, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 47, Gx_line+13, 155, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Unidade de Medida", ""), 173, Gx_line+13, 306, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+0, 1000, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+42);
                  pr_default.dynParam(6, new Object[]{ new Object[]{
                                                       AV95Id ,
                                                       A612MedicaoTipoServicoId ,
                                                       AV33MedicaoId ,
                                                       A550MedicaoId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00GO8 */
                  pr_default.execute(6, new Object[] {AV33MedicaoId, AV95Id});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A614MedicaoUnidadeId = P00GO8_A614MedicaoUnidadeId[0];
                     A612MedicaoTipoServicoId = P00GO8_A612MedicaoTipoServicoId[0];
                     A550MedicaoId = P00GO8_A550MedicaoId[0];
                     A613MedicaoTipoServicoNome = P00GO8_A613MedicaoTipoServicoNome[0];
                     A616MedicaoUnidadeAbreviacao = P00GO8_A616MedicaoUnidadeAbreviacao[0];
                     A617MedicaoTipoServicoQtd = P00GO8_A617MedicaoTipoServicoQtd[0];
                     A679MedicaoTipoServicoValor = P00GO8_A679MedicaoTipoServicoValor[0];
                     A616MedicaoUnidadeAbreviacao = P00GO8_A616MedicaoUnidadeAbreviacao[0];
                     A613MedicaoTipoServicoNome = P00GO8_A613MedicaoTipoServicoNome[0];
                     A679MedicaoTipoServicoValor = P00GO8_A679MedicaoTipoServicoValor[0];
                     AV76MedicaoTipoServicoNome = A613MedicaoTipoServicoNome;
                     AV78MedicaoUnidadeNome = A616MedicaoUnidadeAbreviacao;
                     AV77MedicaoTipoServicoQtd = A617MedicaoTipoServicoQtd;
                     AV93MedicaoTipoServicoValor = A679MedicaoTipoServicoValor;
                     HGO0( false, 40) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78MedicaoUnidadeNome, "")), 173, Gx_line+13, 290, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76MedicaoTipoServicoNome, "")), 47, Gx_line+13, 154, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77MedicaoTipoServicoQtd, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 513, Gx_line+28, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93MedicaoTipoServicoValor, "ZZZZZZZZZZZZZZ9.99")), 593, Gx_line+13, 746, Gx_line+28, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+40);
                     pr_default.readNext(6);
                  }
                  pr_default.close(6);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HGO0( true, 0) ;
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

      protected void HGO0( bool bFoot ,
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
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 967, Gx_line+13, 1006, Gx_line+28, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV60DateTime, "99/99/99 99:99"), 420, Gx_line+13, 500, Gx_line+28, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+41);
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
               getPrinter().GxDrawLine(27, Gx_line+80, 994, Gx_line+80, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(27, Gx_line+220, 994, Gx_line+220, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(27, Gx_line+120, 994, Gx_line+120, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dados da Empresa", ""), 47, Gx_line+91, 260, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(393, Gx_line+133, 493, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28EmpresaFoto)) ? AV100Empresafoto_GXI : AV28EmpresaFoto);
               getPrinter().GxDrawBitMap(sImgUrl, 27, Gx_line+13, 200, Gx_line+66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpresaNome, "")), 240, Gx_line+13, 593, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25EmpresaCNPJ, "")), 240, Gx_line+27, 593, Gx_line+42, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpresaEmail, "")), 240, Gx_line+40, 593, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26EmpresaContato, "")), 240, Gx_line+53, 593, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "MEDIÇÃO DE CONTRATO", ""), 707, Gx_line+13, 994, Gx_line+34, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 945, Gx_line+40, 994, Gx_line+55, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ClienteTelefone, "")), 47, Gx_line+194, 400, Gx_line+209, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10ClienteContato, "")), 47, Gx_line+173, 400, Gx_line+188, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9ClienteCNPJ, "")), 47, Gx_line+153, 400, Gx_line+168, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ClienteNome, "")), 47, Gx_line+133, 400, Gx_line+151, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 587, Gx_line+133, 800, Gx_line+147, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11ClienteEmail, "")), 587, Gx_line+147, 854, Gx_line+162, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+227);
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
         AV38SDTContexto = new SdtSDTContexto(context);
         AV8WebSession = context.GetSession();
         AV60DateTime = (DateTime)(DateTime.MinValue);
         P00GO2_A1EmpresaId = new long[1] ;
         P00GO2_A40000EmpresaFoto_GXI = new string[] {""} ;
         P00GO2_A3EmpresaCNPJ = new string[] {""} ;
         P00GO2_A4EmpresaContato = new string[] {""} ;
         P00GO2_A15EmpresaEmail = new string[] {""} ;
         P00GO2_A2EmpresaNome = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         A3EmpresaCNPJ = "";
         A4EmpresaContato = "";
         A15EmpresaEmail = "";
         A2EmpresaNome = "";
         AV29EmpresaFotoUrl = "";
         AV40Url = "";
         AV100Empresafoto_GXI = "";
         AV28EmpresaFoto = "";
         AV25EmpresaCNPJ = "";
         AV26EmpresaContato = "";
         AV27EmpresaEmail = "";
         AV31EmpresaNome = "";
         P00GO3_A392TipoContratoId = new long[1] ;
         P00GO3_n392TipoContratoId = new bool[] {false} ;
         P00GO3_A344ContratoId = new long[1] ;
         P00GO3_A345ContratoNome = new string[] {""} ;
         P00GO3_A350ContratoDiaEnvioNota = new short[1] ;
         P00GO3_A400ContratoDiasVencimento = new short[1] ;
         P00GO3_A396ContratoDtAssinatura = new DateTime[] {DateTime.MinValue} ;
         P00GO3_A404ContratoDtFimVigencia = new DateTime[] {DateTime.MinValue} ;
         P00GO3_A395ContratoDtInicioVigencia = new DateTime[] {DateTime.MinValue} ;
         P00GO3_A352ContratoFinanceiroNome = new string[] {""} ;
         P00GO3_A349ContratoPrazo = new short[1] ;
         P00GO3_A397ContratoValor = new decimal[1] ;
         P00GO3_A351ContratoVencimento = new short[1] ;
         P00GO3_A393TipoContratoDescricao = new string[] {""} ;
         P00GO3_A637ContratoModalidade = new short[1] ;
         P00GO3_A17ClienteId = new long[1] ;
         A345ContratoNome = "";
         A396ContratoDtAssinatura = DateTime.MinValue;
         A404ContratoDtFimVigencia = DateTime.MinValue;
         A395ContratoDtInicioVigencia = DateTime.MinValue;
         A352ContratoFinanceiroNome = "";
         A393TipoContratoDescricao = "";
         AV21ContratoNome = "";
         AV14ContratoDiaEnvioNota = "";
         AV15ContratoDiasVencimento = "";
         AV16ContratoDtAssinatura = "";
         AV17ContratoDtFimVigencia = "";
         AV18ContratoDtInicioVigencia = "";
         AV37ResponsavelNome = "";
         AV22ContratoPrazo = "";
         AV23ContratoValor = "";
         AV24ContratoVencimento = "";
         AV39TipoContratoDescricao = "";
         AV35Modalidade = "";
         P00GO4_A17ClienteId = new long[1] ;
         P00GO4_A624ClienteCNPJ = new string[] {""} ;
         P00GO4_A19ClienteContato = new string[] {""} ;
         P00GO4_A20ClienteEmail = new string[] {""} ;
         P00GO4_A18ClienteNome = new string[] {""} ;
         P00GO4_A118ClienteTelefone = new string[] {""} ;
         A624ClienteCNPJ = "";
         A19ClienteContato = "";
         A20ClienteEmail = "";
         A18ClienteNome = "";
         A118ClienteTelefone = "";
         AV9ClienteCNPJ = "";
         AV10ClienteContato = "";
         AV11ClienteEmail = "";
         AV12ClienteNome = "";
         AV13ClienteTelefone = "";
         P00GO5_A556MedicaoUsuarioId = new long[1] ;
         P00GO5_A550MedicaoId = new long[1] ;
         P00GO5_A547MedicaoContratoId = new long[1] ;
         P00GO5_A557MedicaoUsuarioNome = new string[] {""} ;
         P00GO5_A551MedicaoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00GO5_A552MedicaoMesAno = new string[] {""} ;
         A557MedicaoUsuarioNome = "";
         A551MedicaoDtHora = (DateTime)(DateTime.MinValue);
         A552MedicaoMesAno = "";
         AV36Nome = "";
         AV32MedicaoDtHora = (DateTime)(DateTime.MinValue);
         AV34MedicaoMesAno = "";
         P00GO6_A549MedicaoFuncaoId = new long[1] ;
         P00GO6_A550MedicaoId = new long[1] ;
         P00GO6_A559MedicaoFuncaoNome = new string[] {""} ;
         P00GO6_A555MedicaoDiferenca = new short[1] ;
         P00GO6_A554MedicaoHoras = new short[1] ;
         P00GO6_A570MedicaoProfissionalHoraMes = new short[1] ;
         P00GO6_A568MedicaoProfissionalSaldo = new long[1] ;
         P00GO6_A569MedicaoProfissionalQtd = new short[1] ;
         P00GO6_A571MedicaoProfissionalValor = new decimal[1] ;
         A559MedicaoFuncaoNome = "";
         AV41FuncaoNome = "";
         P00GO7_A548MedicaoProdutoId = new long[1] ;
         P00GO7_A550MedicaoId = new long[1] ;
         P00GO7_A558MedicaoProdutoNome = new string[] {""} ;
         P00GO7_A553MedicaoQtd = new decimal[1] ;
         P00GO7_A563MedicaoProdutoPreco = new decimal[1] ;
         P00GO7_A564MedicaoProdutoUn = new string[] {""} ;
         P00GO7_A566MedicaoProdutoQtdInicial = new decimal[1] ;
         P00GO7_A567MedicaoProdutoSaldo = new decimal[1] ;
         A558MedicaoProdutoNome = "";
         A564MedicaoProdutoUn = "";
         AV80ProdutoNome = "";
         AV82ProdutoUnidade = "";
         P00GO8_A614MedicaoUnidadeId = new long[1] ;
         P00GO8_A612MedicaoTipoServicoId = new long[1] ;
         P00GO8_A550MedicaoId = new long[1] ;
         P00GO8_A613MedicaoTipoServicoNome = new string[] {""} ;
         P00GO8_A616MedicaoUnidadeAbreviacao = new string[] {""} ;
         P00GO8_A617MedicaoTipoServicoQtd = new decimal[1] ;
         P00GO8_A679MedicaoTipoServicoValor = new decimal[1] ;
         A613MedicaoTipoServicoNome = "";
         A616MedicaoUnidadeAbreviacao = "";
         AV76MedicaoTipoServicoNome = "";
         AV78MedicaoUnidadeNome = "";
         AV28EmpresaFoto = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpressaomedicaounica__default(),
            new Object[][] {
                new Object[] {
               P00GO2_A1EmpresaId, P00GO2_A40000EmpresaFoto_GXI, P00GO2_A3EmpresaCNPJ, P00GO2_A4EmpresaContato, P00GO2_A15EmpresaEmail, P00GO2_A2EmpresaNome
               }
               , new Object[] {
               P00GO3_A392TipoContratoId, P00GO3_n392TipoContratoId, P00GO3_A344ContratoId, P00GO3_A345ContratoNome, P00GO3_A350ContratoDiaEnvioNota, P00GO3_A400ContratoDiasVencimento, P00GO3_A396ContratoDtAssinatura, P00GO3_A404ContratoDtFimVigencia, P00GO3_A395ContratoDtInicioVigencia, P00GO3_A352ContratoFinanceiroNome,
               P00GO3_A349ContratoPrazo, P00GO3_A397ContratoValor, P00GO3_A351ContratoVencimento, P00GO3_A393TipoContratoDescricao, P00GO3_A637ContratoModalidade, P00GO3_A17ClienteId
               }
               , new Object[] {
               P00GO4_A17ClienteId, P00GO4_A624ClienteCNPJ, P00GO4_A19ClienteContato, P00GO4_A20ClienteEmail, P00GO4_A18ClienteNome, P00GO4_A118ClienteTelefone
               }
               , new Object[] {
               P00GO5_A556MedicaoUsuarioId, P00GO5_A550MedicaoId, P00GO5_A547MedicaoContratoId, P00GO5_A557MedicaoUsuarioNome, P00GO5_A551MedicaoDtHora, P00GO5_A552MedicaoMesAno
               }
               , new Object[] {
               P00GO6_A549MedicaoFuncaoId, P00GO6_A550MedicaoId, P00GO6_A559MedicaoFuncaoNome, P00GO6_A555MedicaoDiferenca, P00GO6_A554MedicaoHoras, P00GO6_A570MedicaoProfissionalHoraMes, P00GO6_A568MedicaoProfissionalSaldo, P00GO6_A569MedicaoProfissionalQtd, P00GO6_A571MedicaoProfissionalValor
               }
               , new Object[] {
               P00GO7_A548MedicaoProdutoId, P00GO7_A550MedicaoId, P00GO7_A558MedicaoProdutoNome, P00GO7_A553MedicaoQtd, P00GO7_A563MedicaoProdutoPreco, P00GO7_A564MedicaoProdutoUn, P00GO7_A566MedicaoProdutoQtdInicial, P00GO7_A567MedicaoProdutoSaldo
               }
               , new Object[] {
               P00GO8_A614MedicaoUnidadeId, P00GO8_A612MedicaoTipoServicoId, P00GO8_A550MedicaoId, P00GO8_A613MedicaoTipoServicoNome, P00GO8_A616MedicaoUnidadeAbreviacao, P00GO8_A617MedicaoTipoServicoQtd, P00GO8_A679MedicaoTipoServicoValor
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
      private short AV96Tela ;
      private short AV98Tipo ;
      private short GxWebError ;
      private short A350ContratoDiaEnvioNota ;
      private short A400ContratoDiasVencimento ;
      private short A349ContratoPrazo ;
      private short A351ContratoVencimento ;
      private short A637ContratoModalidade ;
      private short A555MedicaoDiferenca ;
      private short A554MedicaoHoras ;
      private short A570MedicaoProfissionalHoraMes ;
      private short A569MedicaoProfissionalQtd ;
      private short AV69MedicaoDiferenca ;
      private short AV72MedicaoHoras ;
      private short AV42HoraMes ;
      private short AV83Qtd ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV20ContratoId ;
      private long AV95Id ;
      private long AV97AuxMedicaoId ;
      private long AV30EmpresaId ;
      private long A1EmpresaId ;
      private long A392TipoContratoId ;
      private long A344ContratoId ;
      private long A17ClienteId ;
      private long AV94ClienteId ;
      private long A556MedicaoUsuarioId ;
      private long A550MedicaoId ;
      private long A547MedicaoContratoId ;
      private long AV33MedicaoId ;
      private long A549MedicaoFuncaoId ;
      private long A568MedicaoProfissionalSaldo ;
      private long AV92MedicaoProfissionalSaldo ;
      private long A548MedicaoProdutoId ;
      private long A612MedicaoTipoServicoId ;
      private long A614MedicaoUnidadeId ;
      private decimal A397ContratoValor ;
      private decimal A571MedicaoProfissionalValor ;
      private decimal A572MedicaoProfissionalTotal ;
      private decimal AV88Valor ;
      private decimal AV86Total ;
      private decimal AV43MedicaoQtd ;
      private decimal A553MedicaoQtd ;
      private decimal A563MedicaoProdutoPreco ;
      private decimal A566MedicaoProdutoQtdInicial ;
      private decimal A567MedicaoProdutoSaldo ;
      private decimal AV81ProdutoPreco ;
      private decimal AV90MedicaoProdutoQtdInicial ;
      private decimal AV91MedicaoProdutoSaldo ;
      private decimal A617MedicaoTipoServicoQtd ;
      private decimal A679MedicaoTipoServicoValor ;
      private decimal AV77MedicaoTipoServicoQtd ;
      private decimal AV93MedicaoTipoServicoValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A3EmpresaCNPJ ;
      private string A4EmpresaContato ;
      private string A2EmpresaNome ;
      private string AV25EmpresaCNPJ ;
      private string AV26EmpresaContato ;
      private string AV31EmpresaNome ;
      private string A345ContratoNome ;
      private string A352ContratoFinanceiroNome ;
      private string A393TipoContratoDescricao ;
      private string AV37ResponsavelNome ;
      private string AV39TipoContratoDescricao ;
      private string A624ClienteCNPJ ;
      private string A19ClienteContato ;
      private string A18ClienteNome ;
      private string A118ClienteTelefone ;
      private string AV10ClienteContato ;
      private string AV12ClienteNome ;
      private string AV13ClienteTelefone ;
      private string A557MedicaoUsuarioNome ;
      private string A552MedicaoMesAno ;
      private string AV36Nome ;
      private string AV34MedicaoMesAno ;
      private string A559MedicaoFuncaoNome ;
      private string AV41FuncaoNome ;
      private string A564MedicaoProdutoUn ;
      private string AV80ProdutoNome ;
      private string AV82ProdutoUnidade ;
      private string A613MedicaoTipoServicoNome ;
      private string A616MedicaoUnidadeAbreviacao ;
      private string AV76MedicaoTipoServicoNome ;
      private string AV78MedicaoUnidadeNome ;
      private string sImgUrl ;
      private DateTime AV60DateTime ;
      private DateTime A551MedicaoDtHora ;
      private DateTime AV32MedicaoDtHora ;
      private DateTime A396ContratoDtAssinatura ;
      private DateTime A404ContratoDtFimVigencia ;
      private DateTime A395ContratoDtInicioVigencia ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n392TipoContratoId ;
      private string A40000EmpresaFoto_GXI ;
      private string A15EmpresaEmail ;
      private string AV29EmpresaFotoUrl ;
      private string AV40Url ;
      private string AV100Empresafoto_GXI ;
      private string AV27EmpresaEmail ;
      private string AV21ContratoNome ;
      private string AV14ContratoDiaEnvioNota ;
      private string AV15ContratoDiasVencimento ;
      private string AV16ContratoDtAssinatura ;
      private string AV17ContratoDtFimVigencia ;
      private string AV18ContratoDtInicioVigencia ;
      private string AV22ContratoPrazo ;
      private string AV23ContratoValor ;
      private string AV24ContratoVencimento ;
      private string AV35Modalidade ;
      private string A20ClienteEmail ;
      private string AV9ClienteCNPJ ;
      private string AV11ClienteEmail ;
      private string A558MedicaoProdutoNome ;
      private string AV28EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV8WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV38SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00GO2_A1EmpresaId ;
      private string[] P00GO2_A40000EmpresaFoto_GXI ;
      private string[] P00GO2_A3EmpresaCNPJ ;
      private string[] P00GO2_A4EmpresaContato ;
      private string[] P00GO2_A15EmpresaEmail ;
      private string[] P00GO2_A2EmpresaNome ;
      private long[] P00GO3_A392TipoContratoId ;
      private bool[] P00GO3_n392TipoContratoId ;
      private long[] P00GO3_A344ContratoId ;
      private string[] P00GO3_A345ContratoNome ;
      private short[] P00GO3_A350ContratoDiaEnvioNota ;
      private short[] P00GO3_A400ContratoDiasVencimento ;
      private DateTime[] P00GO3_A396ContratoDtAssinatura ;
      private DateTime[] P00GO3_A404ContratoDtFimVigencia ;
      private DateTime[] P00GO3_A395ContratoDtInicioVigencia ;
      private string[] P00GO3_A352ContratoFinanceiroNome ;
      private short[] P00GO3_A349ContratoPrazo ;
      private decimal[] P00GO3_A397ContratoValor ;
      private short[] P00GO3_A351ContratoVencimento ;
      private string[] P00GO3_A393TipoContratoDescricao ;
      private short[] P00GO3_A637ContratoModalidade ;
      private long[] P00GO3_A17ClienteId ;
      private long[] P00GO4_A17ClienteId ;
      private string[] P00GO4_A624ClienteCNPJ ;
      private string[] P00GO4_A19ClienteContato ;
      private string[] P00GO4_A20ClienteEmail ;
      private string[] P00GO4_A18ClienteNome ;
      private string[] P00GO4_A118ClienteTelefone ;
      private long[] P00GO5_A556MedicaoUsuarioId ;
      private long[] P00GO5_A550MedicaoId ;
      private long[] P00GO5_A547MedicaoContratoId ;
      private string[] P00GO5_A557MedicaoUsuarioNome ;
      private DateTime[] P00GO5_A551MedicaoDtHora ;
      private string[] P00GO5_A552MedicaoMesAno ;
      private long[] P00GO6_A549MedicaoFuncaoId ;
      private long[] P00GO6_A550MedicaoId ;
      private string[] P00GO6_A559MedicaoFuncaoNome ;
      private short[] P00GO6_A555MedicaoDiferenca ;
      private short[] P00GO6_A554MedicaoHoras ;
      private short[] P00GO6_A570MedicaoProfissionalHoraMes ;
      private long[] P00GO6_A568MedicaoProfissionalSaldo ;
      private short[] P00GO6_A569MedicaoProfissionalQtd ;
      private decimal[] P00GO6_A571MedicaoProfissionalValor ;
      private long[] P00GO7_A548MedicaoProdutoId ;
      private long[] P00GO7_A550MedicaoId ;
      private string[] P00GO7_A558MedicaoProdutoNome ;
      private decimal[] P00GO7_A553MedicaoQtd ;
      private decimal[] P00GO7_A563MedicaoProdutoPreco ;
      private string[] P00GO7_A564MedicaoProdutoUn ;
      private decimal[] P00GO7_A566MedicaoProdutoQtdInicial ;
      private decimal[] P00GO7_A567MedicaoProdutoSaldo ;
      private long[] P00GO8_A614MedicaoUnidadeId ;
      private long[] P00GO8_A612MedicaoTipoServicoId ;
      private long[] P00GO8_A550MedicaoId ;
      private string[] P00GO8_A613MedicaoTipoServicoNome ;
      private string[] P00GO8_A616MedicaoUnidadeAbreviacao ;
      private decimal[] P00GO8_A617MedicaoTipoServicoQtd ;
      private decimal[] P00GO8_A679MedicaoTipoServicoValor ;
   }

   public class aimpressaomedicaounica__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GO6( IGxContext context ,
                                             long AV95Id ,
                                             long A549MedicaoFuncaoId ,
                                             long AV33MedicaoId ,
                                             long A550MedicaoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MedicaoFuncaoId] AS MedicaoFuncaoId, T1.[MedicaoId], T2.[FuncaoNome] AS MedicaoFuncaoNome, T1.[MedicaoDiferenca], T1.[MedicaoHoras], T1.[MedicaoProfissionalHoraMes], T1.[MedicaoProfissionalSaldo], T1.[MedicaoProfissionalQtd], T1.[MedicaoProfissionalValor] FROM ([MedicaoProfissional] T1 INNER JOIN [Funcao] T2 ON T2.[FuncaoId] = T1.[MedicaoFuncaoId])";
         AddWhere(sWhereString, "(T1.[MedicaoId] = @AV33MedicaoId)");
         if ( ! (0==AV95Id) )
         {
            AddWhere(sWhereString, "(T1.[MedicaoFuncaoId] = @AV95Id)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MedicaoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00GO7( IGxContext context ,
                                             long AV95Id ,
                                             long A548MedicaoProdutoId ,
                                             long AV33MedicaoId ,
                                             long A550MedicaoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MedicaoProdutoId] AS MedicaoProdutoId, T1.[MedicaoId], T2.[ProdutoDescricao] AS MedicaoProdutoNome, T1.[MedicaoQtd], T2.[ProdutoPreco] AS MedicaoProdutoPreco, T2.[ProdutoUnidade] AS MedicaoProdutoUn, T1.[MedicaoProdutoQtdInicial], T1.[MedicaoProdutoSaldo] FROM ([MedicaoProduto] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[MedicaoProdutoId])";
         AddWhere(sWhereString, "(T1.[MedicaoId] = @AV33MedicaoId)");
         if ( ! (0==AV95Id) )
         {
            AddWhere(sWhereString, "(T1.[MedicaoProdutoId] = @AV95Id)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MedicaoId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00GO8( IGxContext context ,
                                             long AV95Id ,
                                             long A612MedicaoTipoServicoId ,
                                             long AV33MedicaoId ,
                                             long A550MedicaoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[MedicaoUnidadeId] AS MedicaoUnidadeId, T1.[MedicaoTipoServicoId] AS MedicaoTipoServicoId, T1.[MedicaoId], T3.[NaturezaNome] AS MedicaoTipoServicoNome, T2.[UnidadeMedidaAbreviacao] AS MedicaoUnidadeAbreviacao, T1.[MedicaoTipoServicoQtd], T3.[NaturezaValor] AS MedicaoTipoServicoValor FROM (([MedicaoTipoServico] T1 INNER JOIN [UnidadeMedida] T2 ON T2.[UnidadeMedidaId] = T1.[MedicaoUnidadeId]) INNER JOIN [Natureza] T3 ON T3.[NaturezaId] = T1.[MedicaoTipoServicoId])";
         AddWhere(sWhereString, "(T1.[MedicaoId] = @AV33MedicaoId)");
         if ( ! (0==AV95Id) )
         {
            AddWhere(sWhereString, "(T1.[MedicaoTipoServicoId] = @AV95Id)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MedicaoId]";
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
               case 4 :
                     return conditional_P00GO6(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
               case 5 :
                     return conditional_P00GO7(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
               case 6 :
                     return conditional_P00GO8(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GO2;
          prmP00GO2 = new Object[] {
          new ParDef("@AV30EmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00GO3;
          prmP00GO3 = new Object[] {
          new ParDef("@AV20ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GO4;
          prmP00GO4 = new Object[] {
          new ParDef("@AV94ClienteId",GXType.Decimal,18,0)
          };
          Object[] prmP00GO5;
          prmP00GO5 = new Object[] {
          new ParDef("@AV97AuxMedicaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV20ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GO6;
          prmP00GO6 = new Object[] {
          new ParDef("@AV33MedicaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV95Id",GXType.Decimal,18,0)
          };
          Object[] prmP00GO7;
          prmP00GO7 = new Object[] {
          new ParDef("@AV33MedicaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV95Id",GXType.Decimal,18,0)
          };
          Object[] prmP00GO8;
          prmP00GO8 = new Object[] {
          new ParDef("@AV33MedicaoId",GXType.Decimal,18,0) ,
          new ParDef("@AV95Id",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GO2", "SELECT [EmpresaId], [EmpresaFoto_GXI], [EmpresaCNPJ], [EmpresaContato], [EmpresaEmail], [EmpresaNome] FROM [Empresa] WHERE [EmpresaId] = @AV30EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GO3", "SELECT T1.[TipoContratoId], T1.[ContratoId], T1.[ContratoNome], T1.[ContratoDiaEnvioNota], T1.[ContratoDiasVencimento], T1.[ContratoDtAssinatura], T1.[ContratoDtFimVigencia], T1.[ContratoDtInicioVigencia], T1.[ContratoFinanceiroNome], T1.[ContratoPrazo], T1.[ContratoValor], T1.[ContratoVencimento], T2.[TipoContratoDescricao], T1.[ContratoModalidade], T1.[ClienteId] FROM ([Contrato] T1 LEFT JOIN [TipoContrato] T2 ON T2.[TipoContratoId] = T1.[TipoContratoId]) WHERE T1.[ContratoId] = @AV20ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GO4", "SELECT [ClienteId], [ClienteCNPJ], [ClienteContato], [ClienteEmail], [ClienteNome], [ClienteTelefone] FROM [Cliente] WHERE [ClienteId] = @AV94ClienteId ORDER BY [ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GO5", "SELECT T1.[MedicaoUsuarioId] AS MedicaoUsuarioId, T1.[MedicaoId], T1.[MedicaoContratoId], T2.[UsuarioNome] AS MedicaoUsuarioNome, T1.[MedicaoDtHora], T1.[MedicaoMesAno] FROM ([Medicao] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[MedicaoUsuarioId]) WHERE (T1.[MedicaoId] = @AV97AuxMedicaoId) AND (T1.[MedicaoContratoId] = @AV20ContratoId) ORDER BY T1.[MedicaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GO6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GO7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GO8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GO8,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 18);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 60);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 60);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 60);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 18);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 60);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 60);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                return;
       }
    }

 }

}
