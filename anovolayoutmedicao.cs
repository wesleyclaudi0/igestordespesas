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
   public class anovolayoutmedicao : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "ContratoId");
            if ( ! entryPointCalled )
            {
               AV44ContratoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public anovolayoutmedicao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public anovolayoutmedicao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ContratoId )
      {
         this.AV44ContratoId = aP0_ContratoId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ContratoId )
      {
         this.AV44ContratoId = aP0_ContratoId;
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
         setOutputFileName("RelatorioMedicaoNovo.pdf");
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
            AV13SDTContexto.FromJSonString(AV17WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV14EmpresaId = AV13SDTContexto.gxTpr_Empresaid;
            /* Using cursor P00GN2 */
            pr_default.execute(0, new Object[] {AV14EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00GN2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P00GN2_A40000EmpresaFoto_GXI[0];
               A3EmpresaCNPJ = P00GN2_A3EmpresaCNPJ[0];
               A4EmpresaContato = P00GN2_A4EmpresaContato[0];
               A15EmpresaEmail = P00GN2_A15EmpresaEmail[0];
               A2EmpresaNome = P00GN2_A2EmpresaNome[0];
               AV15EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV16Url = StringUtil.StringReplace( AV15EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV102Empresafoto_GXI = AV16Url;
               AV8EmpresaFoto = "";
               AV10EmpresaCNPJ = A3EmpresaCNPJ;
               AV12EmpresaContato = A4EmpresaContato;
               AV11EmpresaEmail = A15EmpresaEmail;
               AV9EmpresaNome = A2EmpresaNome;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00GN3 */
            pr_default.execute(1, new Object[] {AV44ContratoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A392TipoContratoId = P00GN3_A392TipoContratoId[0];
               n392TipoContratoId = P00GN3_n392TipoContratoId[0];
               A344ContratoId = P00GN3_A344ContratoId[0];
               A345ContratoNome = P00GN3_A345ContratoNome[0];
               A350ContratoDiaEnvioNota = P00GN3_A350ContratoDiaEnvioNota[0];
               A400ContratoDiasVencimento = P00GN3_A400ContratoDiasVencimento[0];
               A396ContratoDtAssinatura = P00GN3_A396ContratoDtAssinatura[0];
               A404ContratoDtFimVigencia = P00GN3_A404ContratoDtFimVigencia[0];
               A395ContratoDtInicioVigencia = P00GN3_A395ContratoDtInicioVigencia[0];
               A352ContratoFinanceiroNome = P00GN3_A352ContratoFinanceiroNome[0];
               A349ContratoPrazo = P00GN3_A349ContratoPrazo[0];
               A397ContratoValor = P00GN3_A397ContratoValor[0];
               A351ContratoVencimento = P00GN3_A351ContratoVencimento[0];
               A393TipoContratoDescricao = P00GN3_A393TipoContratoDescricao[0];
               A637ContratoModalidade = P00GN3_A637ContratoModalidade[0];
               A17ClienteId = P00GN3_A17ClienteId[0];
               A393TipoContratoDescricao = P00GN3_A393TipoContratoDescricao[0];
               AV33ContratoNome = context.GetMessage( "Nome: ", "") + StringUtil.Trim( A345ContratoNome);
               AV24ContratoDiaEnvioNota = context.GetMessage( "Dia para Envio da Nota: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A350ContratoDiaEnvioNota), 2, 0));
               AV25ContratoDiasVencimento = StringUtil.Trim( StringUtil.Str( (decimal)(A400ContratoDiasVencimento), 4, 0));
               AV26ContratoDtAssinatura = context.GetMessage( "Data da Assinatura: ", "") + StringUtil.Trim( context.localUtil.DToC( A396ContratoDtAssinatura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV27ContratoDtFimVigencia = context.GetMessage( "Fim da Vigência: ", "") + StringUtil.Trim( context.localUtil.DToC( A404ContratoDtFimVigencia, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV28ContratoDtInicioVigencia = context.GetMessage( "Inicío da Vigência: ", "") + StringUtil.Trim( context.localUtil.DToC( A395ContratoDtInicioVigencia, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV35ResponsavelNome = context.GetMessage( "Responsável Financeiro: ", "") + A352ContratoFinanceiroNome;
               AV34ContratoPrazo = context.GetMessage( "Prazo em Meses: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A349ContratoPrazo), 2, 0));
               AV30ContratoValor = context.GetMessage( "Valor: R$ ", "") + StringUtil.Trim( StringUtil.Str( A397ContratoValor, 18, 2));
               AV31ContratoVencimento = context.GetMessage( "Dia do Vencimento: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A351ContratoVencimento), 2, 0));
               AV32TipoContratoDescricao = context.GetMessage( "Tipo de Contrato: ", "") + A393TipoContratoDescricao;
               AV40Modalidade = context.GetMessage( "Modalidade: ", "") + context.GetMessage( gxdomainmodalidade.getDescription(context,A637ContratoModalidade), "");
               AV100ClienteId = A17ClienteId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00GN4 */
            pr_default.execute(2, new Object[] {AV100ClienteId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A17ClienteId = P00GN4_A17ClienteId[0];
               A624ClienteCNPJ = P00GN4_A624ClienteCNPJ[0];
               A19ClienteContato = P00GN4_A19ClienteContato[0];
               A20ClienteEmail = P00GN4_A20ClienteEmail[0];
               A18ClienteNome = P00GN4_A18ClienteNome[0];
               A118ClienteTelefone = P00GN4_A118ClienteTelefone[0];
               AV19ClienteCNPJ = context.GetMessage( "CNPJ: ", "") + A624ClienteCNPJ;
               AV20ClienteContato = context.GetMessage( "Contato: ", "") + A19ClienteContato;
               AV22ClienteEmail = A20ClienteEmail;
               AV18ClienteNome = A18ClienteNome;
               AV23ClienteTelefone = context.GetMessage( "Telefone: ", "") + A118ClienteTelefone;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            HGN0( false, 168) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34ContratoPrazo, "")), 47, Gx_line+133, 400, Gx_line+148, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+166, 1000, Gx_line+166, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dados do Contrato", ""), 47, Gx_line+13, 260, Gx_line+34, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(393, Gx_line+27, 493, Gx_line+147, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ContratoDtFimVigencia, "")), 47, Gx_line+107, 400, Gx_line+122, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ContratoDtInicioVigencia, "")), 47, Gx_line+80, 400, Gx_line+95, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33ContratoNome, "")), 47, Gx_line+53, 400, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30ContratoValor, "")), 587, Gx_line+27, 940, Gx_line+42, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31ContratoVencimento, "")), 587, Gx_line+53, 940, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TipoContratoDescricao, "")), 587, Gx_line+80, 940, Gx_line+95, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35ResponsavelNome, "")), 587, Gx_line+107, 940, Gx_line+122, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Modalidade, "")), 587, Gx_line+133, 940, Gx_line+148, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+168);
            /* Using cursor P00GN5 */
            pr_default.execute(3, new Object[] {AV44ContratoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A556MedicaoUsuarioId = P00GN5_A556MedicaoUsuarioId[0];
               A547MedicaoContratoId = P00GN5_A547MedicaoContratoId[0];
               A557MedicaoUsuarioNome = P00GN5_A557MedicaoUsuarioNome[0];
               A551MedicaoDtHora = P00GN5_A551MedicaoDtHora[0];
               A552MedicaoMesAno = P00GN5_A552MedicaoMesAno[0];
               A550MedicaoId = P00GN5_A550MedicaoId[0];
               A557MedicaoUsuarioNome = P00GN5_A557MedicaoUsuarioNome[0];
               AV42Nome = A557MedicaoUsuarioNome;
               AV41MedicaoDtHora = A551MedicaoDtHora;
               AV43MedicaoMesAno = A552MedicaoMesAno;
               AV45MedicaoId = A550MedicaoId;
               HGN0( false, 149) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Medições", ""), 47, Gx_line+9, 260, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Mês/Ano", ""), 653, Gx_line+53, 866, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Usuário", ""), 347, Gx_line+53, 560, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Data", ""), 47, Gx_line+53, 260, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MedicaoMesAno, "")), 653, Gx_line+80, 866, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Nome, "")), 347, Gx_line+80, 560, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV41MedicaoDtHora, "99/99/9999 99:99:99"), 47, Gx_line+80, 260, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 820, Gx_line+120, 920, Gx_line+136, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Medição (Horas)", ""), 520, Gx_line+120, 637, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Total", ""), 440, Gx_line+120, 498, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 360, Gx_line+120, 418, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Qtd", ""), 273, Gx_line+120, 331, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Hora/Mês", ""), 173, Gx_line+120, 265, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profissional", ""), 47, Gx_line+120, 139, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+107, 1000, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+147, 1000, Gx_line+147, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(33, Gx_line+107, 1000, Gx_line+147, 1, 0, 0, 0, 1, 62, 157, 201, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Diferença", ""), 667, Gx_line+120, 784, Gx_line+135, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+149);
               AV107GXLvl54 = 0;
               /* Using cursor P00GN6 */
               pr_default.execute(4, new Object[] {AV45MedicaoId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A549MedicaoFuncaoId = P00GN6_A549MedicaoFuncaoId[0];
                  A550MedicaoId = P00GN6_A550MedicaoId[0];
                  A559MedicaoFuncaoNome = P00GN6_A559MedicaoFuncaoNome[0];
                  A555MedicaoDiferenca = P00GN6_A555MedicaoDiferenca[0];
                  A554MedicaoHoras = P00GN6_A554MedicaoHoras[0];
                  A570MedicaoProfissionalHoraMes = P00GN6_A570MedicaoProfissionalHoraMes[0];
                  A568MedicaoProfissionalSaldo = P00GN6_A568MedicaoProfissionalSaldo[0];
                  A569MedicaoProfissionalQtd = P00GN6_A569MedicaoProfissionalQtd[0];
                  A571MedicaoProfissionalValor = P00GN6_A571MedicaoProfissionalValor[0];
                  A559MedicaoFuncaoNome = P00GN6_A559MedicaoFuncaoNome[0];
                  A572MedicaoProfissionalTotal = (decimal)(A571MedicaoProfissionalValor*A569MedicaoProfissionalQtd);
                  AV107GXLvl54 = 1;
                  AV47FuncaoNome = A559MedicaoFuncaoNome;
                  AV75MedicaoDiferenca = A555MedicaoDiferenca;
                  AV78MedicaoHoras = A554MedicaoHoras;
                  AV49MedicaoQtd = (decimal)(A569MedicaoProfissionalQtd);
                  AV48HoraMes = A570MedicaoProfissionalHoraMes;
                  AV94Valor = A571MedicaoProfissionalValor;
                  AV92Total = A572MedicaoProfissionalTotal;
                  AV98MedicaoProfissionalSaldo = A568MedicaoProfissionalSaldo;
                  AV75MedicaoDiferenca = A555MedicaoDiferenca;
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48HoraMes), "ZZZ9")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94Valor, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 418, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49MedicaoQtd, "ZZZZZZZZ9.99")), 273, Gx_line+13, 323, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92Total, "ZZZZZZZZZZZZZZ9.99")), 440, Gx_line+13, 498, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47FuncaoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV78MedicaoHoras), "ZZZ9")), 527, Gx_line+13, 619, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV98MedicaoProfissionalSaldo), "ZZZZZZZZZZZ9")), 827, Gx_line+13, 935, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV75MedicaoDiferenca), "ZZZ9")), 667, Gx_line+13, 767, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               if ( AV107GXLvl54 == 0 )
               {
                  AV47FuncaoNome = context.GetMessage( "(Sem registros)", "");
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48HoraMes), "ZZZ9")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94Valor, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 418, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49MedicaoQtd, "ZZZZZZZZ9.99")), 273, Gx_line+13, 323, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92Total, "ZZZZZZZZZZZZZZ9.99")), 440, Gx_line+13, 498, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47FuncaoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV78MedicaoHoras), "ZZZ9")), 527, Gx_line+13, 619, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV98MedicaoProfissionalSaldo), "ZZZZZZZZZZZ9")), 827, Gx_line+13, 935, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV75MedicaoDiferenca), "ZZZ9")), 667, Gx_line+13, 767, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
               }
               HGN0( false, 42) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 593, Gx_line+13, 651, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Qtd Inicial", ""), 367, Gx_line+13, 447, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Qtd", ""), 487, Gx_line+13, 545, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Produto", ""), 47, Gx_line+13, 139, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Preço", ""), 173, Gx_line+13, 265, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Unidade", ""), 273, Gx_line+13, 331, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+0, 1000, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(33, Gx_line+0, 1000, Gx_line+40, 1, 0, 0, 0, 1, 62, 157, 201, 1, 1, 1, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               AV108GXLvl71 = 0;
               /* Using cursor P00GN7 */
               pr_default.execute(5, new Object[] {AV45MedicaoId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A548MedicaoProdutoId = P00GN7_A548MedicaoProdutoId[0];
                  A550MedicaoId = P00GN7_A550MedicaoId[0];
                  A558MedicaoProdutoNome = P00GN7_A558MedicaoProdutoNome[0];
                  A553MedicaoQtd = P00GN7_A553MedicaoQtd[0];
                  A563MedicaoProdutoPreco = P00GN7_A563MedicaoProdutoPreco[0];
                  A564MedicaoProdutoUn = P00GN7_A564MedicaoProdutoUn[0];
                  A566MedicaoProdutoQtdInicial = P00GN7_A566MedicaoProdutoQtdInicial[0];
                  A567MedicaoProdutoSaldo = P00GN7_A567MedicaoProdutoSaldo[0];
                  A558MedicaoProdutoNome = P00GN7_A558MedicaoProdutoNome[0];
                  A563MedicaoProdutoPreco = P00GN7_A563MedicaoProdutoPreco[0];
                  A564MedicaoProdutoUn = P00GN7_A564MedicaoProdutoUn[0];
                  AV108GXLvl71 = 1;
                  AV86ProdutoNome = A558MedicaoProdutoNome;
                  AV89Qtd = (short)(Math.Round(A553MedicaoQtd, 18, MidpointRounding.ToEven));
                  AV87ProdutoPreco = A563MedicaoProdutoPreco;
                  AV88ProdutoUnidade = A564MedicaoProdutoUn;
                  AV96MedicaoProdutoQtdInicial = A566MedicaoProdutoQtdInicial;
                  AV97MedicaoProdutoSaldo = A567MedicaoProdutoSaldo;
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97MedicaoProdutoSaldo, "ZZZZZZZZ9.99")), 593, Gx_line+13, 685, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96MedicaoProdutoQtdInicial, "ZZZZZZZZ9.99")), 367, Gx_line+13, 450, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV89Qtd), "ZZZ9")), 487, Gx_line+13, 537, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86ProdutoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88ProdutoUnidade, "")), 273, Gx_line+13, 340, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87ProdutoPreco, "ZZZZZZZZZZZZZZ9.99")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               if ( AV108GXLvl71 == 0 )
               {
                  AV86ProdutoNome = context.GetMessage( "(Sem registros)", "");
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97MedicaoProdutoSaldo, "ZZZZZZZZ9.99")), 593, Gx_line+13, 685, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96MedicaoProdutoQtdInicial, "ZZZZZZZZ9.99")), 367, Gx_line+13, 450, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV89Qtd), "ZZZ9")), 487, Gx_line+13, 537, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86ProdutoNome, "")), 47, Gx_line+13, 147, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88ProdutoUnidade, "")), 273, Gx_line+13, 340, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87ProdutoPreco, "ZZZZZZZZZZZZZZ9.99")), 173, Gx_line+13, 256, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
               }
               HGN0( false, 42) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 593, Gx_line+13, 776, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Quantidade", ""), 360, Gx_line+13, 480, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Serviço", ""), 47, Gx_line+13, 155, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Unidade de Medida", ""), 173, Gx_line+13, 306, Gx_line+28, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 1000, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+0, 1000, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(33, Gx_line+0, 1000, Gx_line+40, 1, 0, 0, 0, 1, 62, 157, 201, 1, 1, 1, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               AV109GXLvl85 = 0;
               /* Using cursor P00GN8 */
               pr_default.execute(6, new Object[] {AV45MedicaoId});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A612MedicaoTipoServicoId = P00GN8_A612MedicaoTipoServicoId[0];
                  A614MedicaoUnidadeId = P00GN8_A614MedicaoUnidadeId[0];
                  A550MedicaoId = P00GN8_A550MedicaoId[0];
                  A613MedicaoTipoServicoNome = P00GN8_A613MedicaoTipoServicoNome[0];
                  A616MedicaoUnidadeAbreviacao = P00GN8_A616MedicaoUnidadeAbreviacao[0];
                  A617MedicaoTipoServicoQtd = P00GN8_A617MedicaoTipoServicoQtd[0];
                  A679MedicaoTipoServicoValor = P00GN8_A679MedicaoTipoServicoValor[0];
                  A613MedicaoTipoServicoNome = P00GN8_A613MedicaoTipoServicoNome[0];
                  A679MedicaoTipoServicoValor = P00GN8_A679MedicaoTipoServicoValor[0];
                  A616MedicaoUnidadeAbreviacao = P00GN8_A616MedicaoUnidadeAbreviacao[0];
                  AV109GXLvl85 = 1;
                  AV82MedicaoTipoServicoNome = A613MedicaoTipoServicoNome;
                  AV84MedicaoUnidadeNome = A616MedicaoUnidadeAbreviacao;
                  AV83MedicaoTipoServicoQtd = A617MedicaoTipoServicoQtd;
                  AV99MedicaoTipoServicoValor = A679MedicaoTipoServicoValor;
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84MedicaoUnidadeNome, "")), 173, Gx_line+13, 290, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82MedicaoTipoServicoNome, "")), 47, Gx_line+13, 154, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83MedicaoTipoServicoQtd, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 513, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99MedicaoTipoServicoValor, "ZZZZZZZZZZZZZZ9.99")), 593, Gx_line+13, 746, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               if ( AV109GXLvl85 == 0 )
               {
                  AV82MedicaoTipoServicoNome = context.GetMessage( "(Sem Registros)", "");
                  HGN0( false, 40) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84MedicaoUnidadeNome, "")), 173, Gx_line+13, 290, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82MedicaoTipoServicoNome, "")), 47, Gx_line+13, 154, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83MedicaoTipoServicoQtd, "ZZZZZZZZZZZZZZ9.99")), 360, Gx_line+13, 513, Gx_line+28, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99MedicaoTipoServicoValor, "ZZZZZZZZZZZZZZ9.99")), 593, Gx_line+13, 746, Gx_line+28, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
               }
               /* Eject command */
               Gx_OldLine = Gx_line;
               Gx_line = (int)(P_lines+1);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HGN0( true, 0) ;
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

      protected void HGN0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV66DateTime, "99/99/99 99:99"), 420, Gx_line+13, 500, Gx_line+28, 2+256, 0, 0, 0) ;
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
               getPrinter().GxDrawRect(580, Gx_line+133, 680, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8EmpresaFoto)) ? AV102Empresafoto_GXI : AV8EmpresaFoto);
               getPrinter().GxDrawBitMap(sImgUrl, 27, Gx_line+13, 200, Gx_line+66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9EmpresaNome, "")), 240, Gx_line+13, 593, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10EmpresaCNPJ, "")), 240, Gx_line+27, 593, Gx_line+42, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11EmpresaEmail, "")), 240, Gx_line+40, 593, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12EmpresaContato, "")), 240, Gx_line+53, 593, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "MEDIÇÃO DE CONTRATO", ""), 707, Gx_line+13, 994, Gx_line+34, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 945, Gx_line+40, 994, Gx_line+55, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ClienteTelefone, "")), 47, Gx_line+194, 400, Gx_line+209, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ClienteContato, "")), 47, Gx_line+173, 400, Gx_line+188, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ClienteCNPJ, "")), 47, Gx_line+153, 400, Gx_line+168, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ClienteNome, "")), 47, Gx_line+133, 400, Gx_line+151, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 713, Gx_line+133, 926, Gx_line+147, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ClienteEmail, "")), 713, Gx_line+147, 980, Gx_line+162, 0, 0, 0, 0) ;
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
         AV13SDTContexto = new SdtSDTContexto(context);
         AV17WebSession = context.GetSession();
         P00GN2_A1EmpresaId = new long[1] ;
         P00GN2_A40000EmpresaFoto_GXI = new string[] {""} ;
         P00GN2_A3EmpresaCNPJ = new string[] {""} ;
         P00GN2_A4EmpresaContato = new string[] {""} ;
         P00GN2_A15EmpresaEmail = new string[] {""} ;
         P00GN2_A2EmpresaNome = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         A3EmpresaCNPJ = "";
         A4EmpresaContato = "";
         A15EmpresaEmail = "";
         A2EmpresaNome = "";
         AV15EmpresaFotoUrl = "";
         AV16Url = "";
         AV102Empresafoto_GXI = "";
         AV8EmpresaFoto = "";
         AV10EmpresaCNPJ = "";
         AV12EmpresaContato = "";
         AV11EmpresaEmail = "";
         AV9EmpresaNome = "";
         P00GN3_A392TipoContratoId = new long[1] ;
         P00GN3_n392TipoContratoId = new bool[] {false} ;
         P00GN3_A344ContratoId = new long[1] ;
         P00GN3_A345ContratoNome = new string[] {""} ;
         P00GN3_A350ContratoDiaEnvioNota = new short[1] ;
         P00GN3_A400ContratoDiasVencimento = new short[1] ;
         P00GN3_A396ContratoDtAssinatura = new DateTime[] {DateTime.MinValue} ;
         P00GN3_A404ContratoDtFimVigencia = new DateTime[] {DateTime.MinValue} ;
         P00GN3_A395ContratoDtInicioVigencia = new DateTime[] {DateTime.MinValue} ;
         P00GN3_A352ContratoFinanceiroNome = new string[] {""} ;
         P00GN3_A349ContratoPrazo = new short[1] ;
         P00GN3_A397ContratoValor = new decimal[1] ;
         P00GN3_A351ContratoVencimento = new short[1] ;
         P00GN3_A393TipoContratoDescricao = new string[] {""} ;
         P00GN3_A637ContratoModalidade = new short[1] ;
         P00GN3_A17ClienteId = new long[1] ;
         A345ContratoNome = "";
         A396ContratoDtAssinatura = DateTime.MinValue;
         A404ContratoDtFimVigencia = DateTime.MinValue;
         A395ContratoDtInicioVigencia = DateTime.MinValue;
         A352ContratoFinanceiroNome = "";
         A393TipoContratoDescricao = "";
         AV33ContratoNome = "";
         AV24ContratoDiaEnvioNota = "";
         AV25ContratoDiasVencimento = "";
         AV26ContratoDtAssinatura = "";
         AV27ContratoDtFimVigencia = "";
         AV28ContratoDtInicioVigencia = "";
         AV35ResponsavelNome = "";
         AV34ContratoPrazo = "";
         AV30ContratoValor = "";
         AV31ContratoVencimento = "";
         AV32TipoContratoDescricao = "";
         AV40Modalidade = "";
         P00GN4_A17ClienteId = new long[1] ;
         P00GN4_A624ClienteCNPJ = new string[] {""} ;
         P00GN4_A19ClienteContato = new string[] {""} ;
         P00GN4_A20ClienteEmail = new string[] {""} ;
         P00GN4_A18ClienteNome = new string[] {""} ;
         P00GN4_A118ClienteTelefone = new string[] {""} ;
         A624ClienteCNPJ = "";
         A19ClienteContato = "";
         A20ClienteEmail = "";
         A18ClienteNome = "";
         A118ClienteTelefone = "";
         AV19ClienteCNPJ = "";
         AV20ClienteContato = "";
         AV22ClienteEmail = "";
         AV18ClienteNome = "";
         AV23ClienteTelefone = "";
         P00GN5_A556MedicaoUsuarioId = new long[1] ;
         P00GN5_A547MedicaoContratoId = new long[1] ;
         P00GN5_A557MedicaoUsuarioNome = new string[] {""} ;
         P00GN5_A551MedicaoDtHora = new DateTime[] {DateTime.MinValue} ;
         P00GN5_A552MedicaoMesAno = new string[] {""} ;
         P00GN5_A550MedicaoId = new long[1] ;
         A557MedicaoUsuarioNome = "";
         A551MedicaoDtHora = (DateTime)(DateTime.MinValue);
         A552MedicaoMesAno = "";
         AV42Nome = "";
         AV41MedicaoDtHora = (DateTime)(DateTime.MinValue);
         AV43MedicaoMesAno = "";
         P00GN6_A549MedicaoFuncaoId = new long[1] ;
         P00GN6_A550MedicaoId = new long[1] ;
         P00GN6_A559MedicaoFuncaoNome = new string[] {""} ;
         P00GN6_A555MedicaoDiferenca = new short[1] ;
         P00GN6_A554MedicaoHoras = new short[1] ;
         P00GN6_A570MedicaoProfissionalHoraMes = new short[1] ;
         P00GN6_A568MedicaoProfissionalSaldo = new long[1] ;
         P00GN6_A569MedicaoProfissionalQtd = new short[1] ;
         P00GN6_A571MedicaoProfissionalValor = new decimal[1] ;
         A559MedicaoFuncaoNome = "";
         AV47FuncaoNome = "";
         P00GN7_A548MedicaoProdutoId = new long[1] ;
         P00GN7_A550MedicaoId = new long[1] ;
         P00GN7_A558MedicaoProdutoNome = new string[] {""} ;
         P00GN7_A553MedicaoQtd = new decimal[1] ;
         P00GN7_A563MedicaoProdutoPreco = new decimal[1] ;
         P00GN7_A564MedicaoProdutoUn = new string[] {""} ;
         P00GN7_A566MedicaoProdutoQtdInicial = new decimal[1] ;
         P00GN7_A567MedicaoProdutoSaldo = new decimal[1] ;
         A558MedicaoProdutoNome = "";
         A564MedicaoProdutoUn = "";
         AV86ProdutoNome = "";
         AV88ProdutoUnidade = "";
         P00GN8_A612MedicaoTipoServicoId = new long[1] ;
         P00GN8_A614MedicaoUnidadeId = new long[1] ;
         P00GN8_A550MedicaoId = new long[1] ;
         P00GN8_A613MedicaoTipoServicoNome = new string[] {""} ;
         P00GN8_A616MedicaoUnidadeAbreviacao = new string[] {""} ;
         P00GN8_A617MedicaoTipoServicoQtd = new decimal[1] ;
         P00GN8_A679MedicaoTipoServicoValor = new decimal[1] ;
         A613MedicaoTipoServicoNome = "";
         A616MedicaoUnidadeAbreviacao = "";
         AV82MedicaoTipoServicoNome = "";
         AV84MedicaoUnidadeNome = "";
         AV66DateTime = (DateTime)(DateTime.MinValue);
         AV8EmpresaFoto = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anovolayoutmedicao__default(),
            new Object[][] {
                new Object[] {
               P00GN2_A1EmpresaId, P00GN2_A40000EmpresaFoto_GXI, P00GN2_A3EmpresaCNPJ, P00GN2_A4EmpresaContato, P00GN2_A15EmpresaEmail, P00GN2_A2EmpresaNome
               }
               , new Object[] {
               P00GN3_A392TipoContratoId, P00GN3_n392TipoContratoId, P00GN3_A344ContratoId, P00GN3_A345ContratoNome, P00GN3_A350ContratoDiaEnvioNota, P00GN3_A400ContratoDiasVencimento, P00GN3_A396ContratoDtAssinatura, P00GN3_A404ContratoDtFimVigencia, P00GN3_A395ContratoDtInicioVigencia, P00GN3_A352ContratoFinanceiroNome,
               P00GN3_A349ContratoPrazo, P00GN3_A397ContratoValor, P00GN3_A351ContratoVencimento, P00GN3_A393TipoContratoDescricao, P00GN3_A637ContratoModalidade, P00GN3_A17ClienteId
               }
               , new Object[] {
               P00GN4_A17ClienteId, P00GN4_A624ClienteCNPJ, P00GN4_A19ClienteContato, P00GN4_A20ClienteEmail, P00GN4_A18ClienteNome, P00GN4_A118ClienteTelefone
               }
               , new Object[] {
               P00GN5_A556MedicaoUsuarioId, P00GN5_A547MedicaoContratoId, P00GN5_A557MedicaoUsuarioNome, P00GN5_A551MedicaoDtHora, P00GN5_A552MedicaoMesAno, P00GN5_A550MedicaoId
               }
               , new Object[] {
               P00GN6_A549MedicaoFuncaoId, P00GN6_A550MedicaoId, P00GN6_A559MedicaoFuncaoNome, P00GN6_A555MedicaoDiferenca, P00GN6_A554MedicaoHoras, P00GN6_A570MedicaoProfissionalHoraMes, P00GN6_A568MedicaoProfissionalSaldo, P00GN6_A569MedicaoProfissionalQtd, P00GN6_A571MedicaoProfissionalValor
               }
               , new Object[] {
               P00GN7_A548MedicaoProdutoId, P00GN7_A550MedicaoId, P00GN7_A558MedicaoProdutoNome, P00GN7_A553MedicaoQtd, P00GN7_A563MedicaoProdutoPreco, P00GN7_A564MedicaoProdutoUn, P00GN7_A566MedicaoProdutoQtdInicial, P00GN7_A567MedicaoProdutoSaldo
               }
               , new Object[] {
               P00GN8_A612MedicaoTipoServicoId, P00GN8_A614MedicaoUnidadeId, P00GN8_A550MedicaoId, P00GN8_A613MedicaoTipoServicoNome, P00GN8_A616MedicaoUnidadeAbreviacao, P00GN8_A617MedicaoTipoServicoQtd, P00GN8_A679MedicaoTipoServicoValor
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
      private short GxWebError ;
      private short A350ContratoDiaEnvioNota ;
      private short A400ContratoDiasVencimento ;
      private short A349ContratoPrazo ;
      private short A351ContratoVencimento ;
      private short A637ContratoModalidade ;
      private short AV107GXLvl54 ;
      private short A555MedicaoDiferenca ;
      private short A554MedicaoHoras ;
      private short A570MedicaoProfissionalHoraMes ;
      private short A569MedicaoProfissionalQtd ;
      private short AV75MedicaoDiferenca ;
      private short AV78MedicaoHoras ;
      private short AV48HoraMes ;
      private short AV108GXLvl71 ;
      private short AV89Qtd ;
      private short AV109GXLvl85 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV44ContratoId ;
      private long AV14EmpresaId ;
      private long A1EmpresaId ;
      private long A392TipoContratoId ;
      private long A344ContratoId ;
      private long A17ClienteId ;
      private long AV100ClienteId ;
      private long A556MedicaoUsuarioId ;
      private long A547MedicaoContratoId ;
      private long A550MedicaoId ;
      private long AV45MedicaoId ;
      private long A549MedicaoFuncaoId ;
      private long A568MedicaoProfissionalSaldo ;
      private long AV98MedicaoProfissionalSaldo ;
      private long A548MedicaoProdutoId ;
      private long A612MedicaoTipoServicoId ;
      private long A614MedicaoUnidadeId ;
      private decimal A397ContratoValor ;
      private decimal A571MedicaoProfissionalValor ;
      private decimal A572MedicaoProfissionalTotal ;
      private decimal AV49MedicaoQtd ;
      private decimal AV94Valor ;
      private decimal AV92Total ;
      private decimal A553MedicaoQtd ;
      private decimal A563MedicaoProdutoPreco ;
      private decimal A566MedicaoProdutoQtdInicial ;
      private decimal A567MedicaoProdutoSaldo ;
      private decimal AV87ProdutoPreco ;
      private decimal AV96MedicaoProdutoQtdInicial ;
      private decimal AV97MedicaoProdutoSaldo ;
      private decimal A617MedicaoTipoServicoQtd ;
      private decimal A679MedicaoTipoServicoValor ;
      private decimal AV83MedicaoTipoServicoQtd ;
      private decimal AV99MedicaoTipoServicoValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A3EmpresaCNPJ ;
      private string A4EmpresaContato ;
      private string A2EmpresaNome ;
      private string AV10EmpresaCNPJ ;
      private string AV12EmpresaContato ;
      private string AV9EmpresaNome ;
      private string A345ContratoNome ;
      private string A352ContratoFinanceiroNome ;
      private string A393TipoContratoDescricao ;
      private string AV35ResponsavelNome ;
      private string AV32TipoContratoDescricao ;
      private string A624ClienteCNPJ ;
      private string A19ClienteContato ;
      private string A18ClienteNome ;
      private string A118ClienteTelefone ;
      private string AV20ClienteContato ;
      private string AV18ClienteNome ;
      private string AV23ClienteTelefone ;
      private string A557MedicaoUsuarioNome ;
      private string A552MedicaoMesAno ;
      private string AV42Nome ;
      private string AV43MedicaoMesAno ;
      private string A559MedicaoFuncaoNome ;
      private string AV47FuncaoNome ;
      private string A564MedicaoProdutoUn ;
      private string AV86ProdutoNome ;
      private string AV88ProdutoUnidade ;
      private string A613MedicaoTipoServicoNome ;
      private string A616MedicaoUnidadeAbreviacao ;
      private string AV82MedicaoTipoServicoNome ;
      private string AV84MedicaoUnidadeNome ;
      private string sImgUrl ;
      private DateTime A551MedicaoDtHora ;
      private DateTime AV41MedicaoDtHora ;
      private DateTime AV66DateTime ;
      private DateTime A396ContratoDtAssinatura ;
      private DateTime A404ContratoDtFimVigencia ;
      private DateTime A395ContratoDtInicioVigencia ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n392TipoContratoId ;
      private string A40000EmpresaFoto_GXI ;
      private string A15EmpresaEmail ;
      private string AV15EmpresaFotoUrl ;
      private string AV16Url ;
      private string AV102Empresafoto_GXI ;
      private string AV11EmpresaEmail ;
      private string AV33ContratoNome ;
      private string AV24ContratoDiaEnvioNota ;
      private string AV25ContratoDiasVencimento ;
      private string AV26ContratoDtAssinatura ;
      private string AV27ContratoDtFimVigencia ;
      private string AV28ContratoDtInicioVigencia ;
      private string AV34ContratoPrazo ;
      private string AV30ContratoValor ;
      private string AV31ContratoVencimento ;
      private string AV40Modalidade ;
      private string A20ClienteEmail ;
      private string AV19ClienteCNPJ ;
      private string AV22ClienteEmail ;
      private string A558MedicaoProdutoNome ;
      private string AV8EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV17WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GN2_A1EmpresaId ;
      private string[] P00GN2_A40000EmpresaFoto_GXI ;
      private string[] P00GN2_A3EmpresaCNPJ ;
      private string[] P00GN2_A4EmpresaContato ;
      private string[] P00GN2_A15EmpresaEmail ;
      private string[] P00GN2_A2EmpresaNome ;
      private long[] P00GN3_A392TipoContratoId ;
      private bool[] P00GN3_n392TipoContratoId ;
      private long[] P00GN3_A344ContratoId ;
      private string[] P00GN3_A345ContratoNome ;
      private short[] P00GN3_A350ContratoDiaEnvioNota ;
      private short[] P00GN3_A400ContratoDiasVencimento ;
      private DateTime[] P00GN3_A396ContratoDtAssinatura ;
      private DateTime[] P00GN3_A404ContratoDtFimVigencia ;
      private DateTime[] P00GN3_A395ContratoDtInicioVigencia ;
      private string[] P00GN3_A352ContratoFinanceiroNome ;
      private short[] P00GN3_A349ContratoPrazo ;
      private decimal[] P00GN3_A397ContratoValor ;
      private short[] P00GN3_A351ContratoVencimento ;
      private string[] P00GN3_A393TipoContratoDescricao ;
      private short[] P00GN3_A637ContratoModalidade ;
      private long[] P00GN3_A17ClienteId ;
      private long[] P00GN4_A17ClienteId ;
      private string[] P00GN4_A624ClienteCNPJ ;
      private string[] P00GN4_A19ClienteContato ;
      private string[] P00GN4_A20ClienteEmail ;
      private string[] P00GN4_A18ClienteNome ;
      private string[] P00GN4_A118ClienteTelefone ;
      private long[] P00GN5_A556MedicaoUsuarioId ;
      private long[] P00GN5_A547MedicaoContratoId ;
      private string[] P00GN5_A557MedicaoUsuarioNome ;
      private DateTime[] P00GN5_A551MedicaoDtHora ;
      private string[] P00GN5_A552MedicaoMesAno ;
      private long[] P00GN5_A550MedicaoId ;
      private long[] P00GN6_A549MedicaoFuncaoId ;
      private long[] P00GN6_A550MedicaoId ;
      private string[] P00GN6_A559MedicaoFuncaoNome ;
      private short[] P00GN6_A555MedicaoDiferenca ;
      private short[] P00GN6_A554MedicaoHoras ;
      private short[] P00GN6_A570MedicaoProfissionalHoraMes ;
      private long[] P00GN6_A568MedicaoProfissionalSaldo ;
      private short[] P00GN6_A569MedicaoProfissionalQtd ;
      private decimal[] P00GN6_A571MedicaoProfissionalValor ;
      private long[] P00GN7_A548MedicaoProdutoId ;
      private long[] P00GN7_A550MedicaoId ;
      private string[] P00GN7_A558MedicaoProdutoNome ;
      private decimal[] P00GN7_A553MedicaoQtd ;
      private decimal[] P00GN7_A563MedicaoProdutoPreco ;
      private string[] P00GN7_A564MedicaoProdutoUn ;
      private decimal[] P00GN7_A566MedicaoProdutoQtdInicial ;
      private decimal[] P00GN7_A567MedicaoProdutoSaldo ;
      private long[] P00GN8_A612MedicaoTipoServicoId ;
      private long[] P00GN8_A614MedicaoUnidadeId ;
      private long[] P00GN8_A550MedicaoId ;
      private string[] P00GN8_A613MedicaoTipoServicoNome ;
      private string[] P00GN8_A616MedicaoUnidadeAbreviacao ;
      private decimal[] P00GN8_A617MedicaoTipoServicoQtd ;
      private decimal[] P00GN8_A679MedicaoTipoServicoValor ;
      private SdtSDTContexto AV13SDTContexto ;
   }

   public class anovolayoutmedicao__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GN2;
          prmP00GN2 = new Object[] {
          new ParDef("@AV14EmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN3;
          prmP00GN3 = new Object[] {
          new ParDef("@AV44ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN4;
          prmP00GN4 = new Object[] {
          new ParDef("@AV100ClienteId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN5;
          prmP00GN5 = new Object[] {
          new ParDef("@AV44ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN6;
          prmP00GN6 = new Object[] {
          new ParDef("@AV45MedicaoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN7;
          prmP00GN7 = new Object[] {
          new ParDef("@AV45MedicaoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GN8;
          prmP00GN8 = new Object[] {
          new ParDef("@AV45MedicaoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GN2", "SELECT [EmpresaId], [EmpresaFoto_GXI], [EmpresaCNPJ], [EmpresaContato], [EmpresaEmail], [EmpresaNome] FROM [Empresa] WHERE [EmpresaId] = @AV14EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GN3", "SELECT T1.[TipoContratoId], T1.[ContratoId], T1.[ContratoNome], T1.[ContratoDiaEnvioNota], T1.[ContratoDiasVencimento], T1.[ContratoDtAssinatura], T1.[ContratoDtFimVigencia], T1.[ContratoDtInicioVigencia], T1.[ContratoFinanceiroNome], T1.[ContratoPrazo], T1.[ContratoValor], T1.[ContratoVencimento], T2.[TipoContratoDescricao], T1.[ContratoModalidade], T1.[ClienteId] FROM ([Contrato] T1 LEFT JOIN [TipoContrato] T2 ON T2.[TipoContratoId] = T1.[TipoContratoId]) WHERE T1.[ContratoId] = @AV44ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GN4", "SELECT [ClienteId], [ClienteCNPJ], [ClienteContato], [ClienteEmail], [ClienteNome], [ClienteTelefone] FROM [Cliente] WHERE [ClienteId] = @AV100ClienteId ORDER BY [ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GN5", "SELECT T1.[MedicaoUsuarioId] AS MedicaoUsuarioId, T1.[MedicaoContratoId], T2.[UsuarioNome] AS MedicaoUsuarioNome, T1.[MedicaoDtHora], T1.[MedicaoMesAno], T1.[MedicaoId] FROM ([Medicao] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[MedicaoUsuarioId]) WHERE T1.[MedicaoContratoId] = @AV44ContratoId ORDER BY T1.[MedicaoContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GN6", "SELECT T1.[MedicaoFuncaoId] AS MedicaoFuncaoId, T1.[MedicaoId], T2.[FuncaoNome] AS MedicaoFuncaoNome, T1.[MedicaoDiferenca], T1.[MedicaoHoras], T1.[MedicaoProfissionalHoraMes], T1.[MedicaoProfissionalSaldo], T1.[MedicaoProfissionalQtd], T1.[MedicaoProfissionalValor] FROM ([MedicaoProfissional] T1 INNER JOIN [Funcao] T2 ON T2.[FuncaoId] = T1.[MedicaoFuncaoId]) WHERE T1.[MedicaoId] = @AV45MedicaoId ORDER BY T1.[MedicaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GN7", "SELECT T1.[MedicaoProdutoId] AS MedicaoProdutoId, T1.[MedicaoId], T2.[ProdutoDescricao] AS MedicaoProdutoNome, T1.[MedicaoQtd], T2.[ProdutoPreco] AS MedicaoProdutoPreco, T2.[ProdutoUnidade] AS MedicaoProdutoUn, T1.[MedicaoProdutoQtdInicial], T1.[MedicaoProdutoSaldo] FROM ([MedicaoProduto] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[MedicaoProdutoId]) WHERE T1.[MedicaoId] = @AV45MedicaoId ORDER BY T1.[MedicaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GN8", "SELECT T1.[MedicaoTipoServicoId] AS MedicaoTipoServicoId, T1.[MedicaoUnidadeId] AS MedicaoUnidadeId, T1.[MedicaoId], T2.[NaturezaNome] AS MedicaoTipoServicoNome, T3.[UnidadeMedidaAbreviacao] AS MedicaoUnidadeAbreviacao, T1.[MedicaoTipoServicoQtd], T2.[NaturezaValor] AS MedicaoTipoServicoValor FROM (([MedicaoTipoServico] T1 INNER JOIN [Natureza] T2 ON T2.[NaturezaId] = T1.[MedicaoTipoServicoId]) INNER JOIN [UnidadeMedida] T3 ON T3.[UnidadeMedidaId] = T1.[MedicaoUnidadeId]) WHERE T1.[MedicaoId] = @AV45MedicaoId ORDER BY T1.[MedicaoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GN8,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
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
