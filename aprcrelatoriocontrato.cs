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
   public class aprcrelatoriocontrato : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               AV14ContratoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatoriocontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriocontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ContratoId )
      {
         this.AV14ContratoId = aP0_ContratoId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ContratoId )
      {
         this.AV14ContratoId = aP0_ContratoId;
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
         setOutputFileName("RelatorioContrato.pdf");
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
            AV15DateTime = DateTimeUtil.Now( context);
            AV55SDTContexto.FromJSonString(AV75WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV20EmpresaId = AV55SDTContexto.gxTpr_Empresaid;
            /* Using cursor P00CT2 */
            pr_default.execute(0, new Object[] {AV20EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00CT2_A1EmpresaId[0];
               A40000EmpresaFoto_GXI = P00CT2_A40000EmpresaFoto_GXI[0];
               AV19EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV71Url = StringUtil.StringReplace( AV19EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV108Empresafoto_GXI = AV71Url;
               AV18EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00CT3 */
            pr_default.execute(1, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A17ClienteId = P00CT3_A17ClienteId[0];
               A392TipoContratoId = P00CT3_A392TipoContratoId[0];
               n392TipoContratoId = P00CT3_n392TipoContratoId[0];
               A344ContratoId = P00CT3_A344ContratoId[0];
               A345ContratoNome = P00CT3_A345ContratoNome[0];
               A346ContratoDescricao = P00CT3_A346ContratoDescricao[0];
               A350ContratoDiaEnvioNota = P00CT3_A350ContratoDiaEnvioNota[0];
               A400ContratoDiasVencimento = P00CT3_A400ContratoDiasVencimento[0];
               A396ContratoDtAssinatura = P00CT3_A396ContratoDtAssinatura[0];
               A404ContratoDtFimVigencia = P00CT3_A404ContratoDtFimVigencia[0];
               A395ContratoDtInicioVigencia = P00CT3_A395ContratoDtInicioVigencia[0];
               A353ContratoFinanceiroEmail = P00CT3_A353ContratoFinanceiroEmail[0];
               A352ContratoFinanceiroNome = P00CT3_A352ContratoFinanceiroNome[0];
               A354ContratoFinanceiroTelefone = P00CT3_A354ContratoFinanceiroTelefone[0];
               A349ContratoPrazo = P00CT3_A349ContratoPrazo[0];
               A397ContratoValor = P00CT3_A397ContratoValor[0];
               A351ContratoVencimento = P00CT3_A351ContratoVencimento[0];
               A393TipoContratoDescricao = P00CT3_A393TipoContratoDescricao[0];
               A18ClienteNome = P00CT3_A18ClienteNome[0];
               A18ClienteNome = P00CT3_A18ClienteNome[0];
               A393TipoContratoDescricao = P00CT3_A393TipoContratoDescricao[0];
               AV16Descricao = StringUtil.Trim( StringUtil.Upper( A345ContratoNome));
               AV76ContratoDescricao = A346ContratoDescricao;
               AV77ContratoDiaEnvioNota = A350ContratoDiaEnvioNota;
               AV78ContratoDiasVencimento = A400ContratoDiasVencimento;
               AV79ContratoDtAssinatura = A396ContratoDtAssinatura;
               AV80ContratoDtFimVigencia = A404ContratoDtFimVigencia;
               AV81ContratoDtInicioVigencia = A395ContratoDtInicioVigencia;
               AV82ContratoFinanceiroEmail = A353ContratoFinanceiroEmail;
               AV83ContratoFinanceiroNome = A352ContratoFinanceiroNome;
               AV84ContratoFinanceiroTelefone = A354ContratoFinanceiroTelefone;
               AV91ContratoNome = A345ContratoNome;
               AV85ContratoPrazo = A349ContratoPrazo;
               AV86ContratoValor = A397ContratoValor;
               AV87ContratoVencimento = A351ContratoVencimento;
               AV90TipoContratoDescricao = A393TipoContratoDescricao;
               AV89ClienteNome = A18ClienteNome;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            HCT0( false, 235) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Descricao, "")), 242, Gx_line+17, 484, Gx_line+50, 1, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV18EmpresaFoto)) ? AV108Empresafoto_GXI : AV18EmpresaFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 50, Gx_line+5, 208, Gx_line+62) ;
            getPrinter().GxDrawRect(492, Gx_line+0, 767, Gx_line+33, 1, 192, 192, 192, 1, 220, 220, 220, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor:", ""), 499, Gx_line+8, 550, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86ContratoValor, "ZZZZZZZZZZZZZZ9.99")), 564, Gx_line+7, 689, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Vencimento:", ""), 500, Gx_line+39, 592, Gx_line+57, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV87ContratoVencimento), "Z9")), 601, Gx_line+40, 701, Gx_line+57, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+233, 1, 0, 0, 0, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+33, 767, Gx_line+66, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 492, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(233, Gx_line+0, 491, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+100, 767, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+67, 767, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(233, Gx_line+67, 491, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+100, 217, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+67, 242, Gx_line+100, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 25, Gx_line+74, 83, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Contrato:", ""), 500, Gx_line+74, 617, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90TipoContratoDescricao, "")), 617, Gx_line+76, 750, Gx_line+91, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dia para envio da nota:", ""), 500, Gx_line+107, 658, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV77ContratoDiaEnvioNota), "Z9")), 665, Gx_line+110, 732, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89ClienteNome, "")), 83, Gx_line+77, 225, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Prazo em meses:", ""), 241, Gx_line+74, 366, Gx_line+92, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV85ContratoPrazo), "Z9")), 366, Gx_line+75, 484, Gx_line+90, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Início da Vigência:", ""), 25, Gx_line+107, 150, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV81ContratoDtInicioVigencia, "99/99/99"), 152, Gx_line+111, 227, Gx_line+126, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fim da Vigência:", ""), 240, Gx_line+107, 357, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV80ContratoDtFimVigencia, "99/99/99"), 356, Gx_line+110, 481, Gx_line+125, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "CONTATOS", ""), 317, Gx_line+183, 484, Gx_line+200, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+133, 492, Gx_line+166, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(492, Gx_line+133, 767, Gx_line+166, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email", ""), 258, Gx_line+217, 391, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+217, 767, Gx_line+234, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Telefone", ""), 492, Gx_line+217, 625, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(250, Gx_line+217, 483, Gx_line+234, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Responsável", ""), 33, Gx_line+217, 158, Gx_line+235, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data da Assinatura:", ""), 500, Gx_line+141, 633, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV79ContratoDtAssinatura, "99/99/99"), 631, Gx_line+143, 758, Gx_line+158, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Responsável Financeiro:", ""), 25, Gx_line+141, 192, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83ContratoFinanceiroNome, "")), 200, Gx_line+142, 442, Gx_line+159, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(233, Gx_line+100, 491, Gx_line+133, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+235);
            /* Using cursor P00CT4 */
            pr_default.execute(2, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A344ContratoId = P00CT4_A344ContratoId[0];
               A357ResponsavelNome = P00CT4_A357ResponsavelNome[0];
               A358ResponsavelEmail = P00CT4_A358ResponsavelEmail[0];
               A359ResponsavelTelefone = P00CT4_A359ResponsavelTelefone[0];
               A356ResponsavelId = P00CT4_A356ResponsavelId[0];
               AV92ResponsavelNome = A357ResponsavelNome;
               AV93ResponsavelEmail = A358ResponsavelEmail;
               AV94ResponsavelTelefone = A359ResponsavelTelefone;
               HCT0( false, 17) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94ResponsavelTelefone, "")), 492, Gx_line+0, 650, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93ResponsavelEmail, "")), 258, Gx_line+0, 466, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92ResponsavelNome, "")), 33, Gx_line+0, 233, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(250, Gx_line+0, 483, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HCT0( false, 68) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 767, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 117, Gx_line+50, 217, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Parcela", ""), 25, Gx_line+50, 108, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 250, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(108, Gx_line+50, 216, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Vencimento", ""), 225, Gx_line+50, 333, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "FLUXO FINANCEIRO", ""), 325, Gx_line+17, 475, Gx_line+35, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(342, Gx_line+50, 500, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor Faturado", ""), 642, Gx_line+50, 750, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Dt Faturamento", ""), 508, Gx_line+50, 625, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Faturamento Previsto", ""), 350, Gx_line+50, 500, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(500, Gx_line+50, 633, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            /* Using cursor P00CT5 */
            pr_default.execute(3, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A344ContratoId = P00CT5_A344ContratoId[0];
               A369FaturaParcela = P00CT5_A369FaturaParcela[0];
               A371FaturaValor = P00CT5_A371FaturaValor[0];
               A374FaturaDtPagamento = P00CT5_A374FaturaDtPagamento[0];
               A372FaturaValorFaturado = P00CT5_A372FaturaValorFaturado[0];
               A350ContratoDiaEnvioNota = P00CT5_A350ContratoDiaEnvioNota[0];
               A370FaturaVencimento = P00CT5_A370FaturaVencimento[0];
               A368FaturaId = P00CT5_A368FaturaId[0];
               A350ContratoDiaEnvioNota = P00CT5_A350ContratoDiaEnvioNota[0];
               A419FaturaDtPrevistaFaturamento = DateTimeUtil.DAdd( A370FaturaVencimento, (-A350ContratoDiaEnvioNota));
               AV95FaturaParcela = A369FaturaParcela;
               AV96FaturaVencimento = A370FaturaVencimento;
               AV97FaturaValor = A371FaturaValor;
               AV98DtFaturamento = DateTimeUtil.ResetTime(A374FaturaDtPagamento);
               AV99FaturaValorFaturado = A372FaturaValorFaturado;
               AV100Previsto = A419FaturaDtPrevistaFaturamento;
               HCT0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV95FaturaParcela), "Z9")), 25, Gx_line+0, 108, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 109, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(217, Gx_line+0, 342, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV96FaturaVencimento, "99/99/99"), 225, Gx_line+0, 333, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97FaturaValor, "ZZZZZZZZZZZZZZ9.99")), 117, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(342, Gx_line+0, 500, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(500, Gx_line+0, 633, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV100Previsto, "99/99/99"), 350, Gx_line+0, 458, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99FaturaValorFaturado, "ZZZZZZZZZZZZZZ9.99")), 642, Gx_line+0, 750, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV98DtFaturamento, "99/99/99"), 508, Gx_line+0, 616, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            HCT0( false, 68) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 767, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nome", ""), 25, Gx_line+50, 242, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "PRODUTOS", ""), 333, Gx_line+17, 441, Gx_line+35, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Preço", ""), 250, Gx_line+50, 325, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(242, Gx_line+50, 400, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            /* Using cursor P00CT6 */
            pr_default.execute(4, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A309ProdutoId = P00CT6_A309ProdutoId[0];
               A344ContratoId = P00CT6_A344ContratoId[0];
               A310ProdutoDescricao = P00CT6_A310ProdutoDescricao[0];
               A542ContratoProdutoPreco = P00CT6_A542ContratoProdutoPreco[0];
               A310ProdutoDescricao = P00CT6_A310ProdutoDescricao[0];
               AV102ProdutoNome = A310ProdutoDescricao;
               AV101ProdutoPreco = A542ContratoProdutoPreco;
               HCT0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102ProdutoNome, "")), 25, Gx_line+0, 242, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+0, 400, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101ProdutoPreco, "ZZZZZZZZZZZZZZ9.99")), 250, Gx_line+0, 467, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            HCT0( false, 68) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+67, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "PROFISSIONAL", ""), 333, Gx_line+17, 450, Gx_line+35, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(242, Gx_line+50, 400, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Qtd", ""), 250, Gx_line+50, 325, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Função", ""), 25, Gx_line+50, 242, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+50, 767, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Hora/Mês", ""), 342, Gx_line+50, 425, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 450, Gx_line+50, 600, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 608, Gx_line+50, 758, Gx_line+68, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+50, 442, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(442, Gx_line+50, 600, Gx_line+67, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            /* Using cursor P00CT7 */
            pr_default.execute(5, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A163FuncaoId = P00CT7_A163FuncaoId[0];
               A344ContratoId = P00CT7_A344ContratoId[0];
               A164FuncaoNome = P00CT7_A164FuncaoNome[0];
               A539ContratoProfissionalHoraMes = P00CT7_A539ContratoProfissionalHoraMes[0];
               A538ContratoProfissionalQtd = P00CT7_A538ContratoProfissionalQtd[0];
               A540ContratoProfissionalValor = P00CT7_A540ContratoProfissionalValor[0];
               A164FuncaoNome = P00CT7_A164FuncaoNome[0];
               A541ContratoProfissionalTotal = (decimal)(A540ContratoProfissionalValor*A538ContratoProfissionalQtd);
               AV103FuncaoNome = A164FuncaoNome;
               AV104Quantidade = A538ContratoProfissionalQtd;
               AV105HoraMes = A539ContratoProfissionalHoraMes;
               AV106Valor = A540ContratoProfissionalValor;
               AV69Total = A541ContratoProfissionalTotal;
               HCT0( false, 17) ;
               getPrinter().GxDrawRect(242, Gx_line+0, 400, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103FuncaoNome, "")), 25, Gx_line+0, 242, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 767, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 0, 0, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV104Quantidade), "ZZZ9")), 250, Gx_line+0, 317, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV105HoraMes), "ZZZ9")), 342, Gx_line+0, 434, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106Valor, "ZZZZZZZZZZZZZZ9.99")), 450, Gx_line+0, 592, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Total, "ZZZZZZZZZZZZZZ9.99")), 608, Gx_line+0, 716, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(442, Gx_line+0, 600, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 442, Gx_line+17, 1, 192, 192, 192, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            HCT0( false, 28) ;
            getPrinter().GxDrawLine(17, Gx_line+0, 767, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCT0( true, 0) ;
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

      protected void HCT0( bool bFoot ,
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
                  getPrinter().GxDrawText(context.localUtil.Format( AV15DateTime, "99/99/99 99:99"), 283, Gx_line+33, 466, Gx_line+48, 1, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 717, Gx_line+33, 756, Gx_line+48, 2+256, 0, 0, 0) ;
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
         AV15DateTime = (DateTime)(DateTime.MinValue);
         AV55SDTContexto = new SdtSDTContexto(context);
         AV75WebSession = context.GetSession();
         P00CT2_A1EmpresaId = new long[1] ;
         P00CT2_A40000EmpresaFoto_GXI = new string[] {""} ;
         A40000EmpresaFoto_GXI = "";
         AV19EmpresaFotoUrl = "";
         AV71Url = "";
         AV108Empresafoto_GXI = "";
         AV18EmpresaFoto = "";
         P00CT3_A17ClienteId = new long[1] ;
         P00CT3_A392TipoContratoId = new long[1] ;
         P00CT3_n392TipoContratoId = new bool[] {false} ;
         P00CT3_A344ContratoId = new long[1] ;
         P00CT3_A345ContratoNome = new string[] {""} ;
         P00CT3_A346ContratoDescricao = new string[] {""} ;
         P00CT3_A350ContratoDiaEnvioNota = new short[1] ;
         P00CT3_A400ContratoDiasVencimento = new short[1] ;
         P00CT3_A396ContratoDtAssinatura = new DateTime[] {DateTime.MinValue} ;
         P00CT3_A404ContratoDtFimVigencia = new DateTime[] {DateTime.MinValue} ;
         P00CT3_A395ContratoDtInicioVigencia = new DateTime[] {DateTime.MinValue} ;
         P00CT3_A353ContratoFinanceiroEmail = new string[] {""} ;
         P00CT3_A352ContratoFinanceiroNome = new string[] {""} ;
         P00CT3_A354ContratoFinanceiroTelefone = new string[] {""} ;
         P00CT3_A349ContratoPrazo = new short[1] ;
         P00CT3_A397ContratoValor = new decimal[1] ;
         P00CT3_A351ContratoVencimento = new short[1] ;
         P00CT3_A393TipoContratoDescricao = new string[] {""} ;
         P00CT3_A18ClienteNome = new string[] {""} ;
         A345ContratoNome = "";
         A346ContratoDescricao = "";
         A396ContratoDtAssinatura = DateTime.MinValue;
         A404ContratoDtFimVigencia = DateTime.MinValue;
         A395ContratoDtInicioVigencia = DateTime.MinValue;
         A353ContratoFinanceiroEmail = "";
         A352ContratoFinanceiroNome = "";
         A354ContratoFinanceiroTelefone = "";
         A393TipoContratoDescricao = "";
         A18ClienteNome = "";
         AV16Descricao = "";
         AV76ContratoDescricao = "";
         AV79ContratoDtAssinatura = DateTime.MinValue;
         AV80ContratoDtFimVigencia = DateTime.MinValue;
         AV81ContratoDtInicioVigencia = DateTime.MinValue;
         AV82ContratoFinanceiroEmail = "";
         AV83ContratoFinanceiroNome = "";
         AV84ContratoFinanceiroTelefone = "";
         AV91ContratoNome = "";
         AV90TipoContratoDescricao = "";
         AV89ClienteNome = "";
         AV18EmpresaFoto = "";
         sImgUrl = "";
         P00CT4_A344ContratoId = new long[1] ;
         P00CT4_A357ResponsavelNome = new string[] {""} ;
         P00CT4_A358ResponsavelEmail = new string[] {""} ;
         P00CT4_A359ResponsavelTelefone = new string[] {""} ;
         P00CT4_A356ResponsavelId = new long[1] ;
         A357ResponsavelNome = "";
         A358ResponsavelEmail = "";
         A359ResponsavelTelefone = "";
         AV92ResponsavelNome = "";
         AV93ResponsavelEmail = "";
         AV94ResponsavelTelefone = "";
         P00CT5_A344ContratoId = new long[1] ;
         P00CT5_A369FaturaParcela = new short[1] ;
         P00CT5_A371FaturaValor = new decimal[1] ;
         P00CT5_A374FaturaDtPagamento = new DateTime[] {DateTime.MinValue} ;
         P00CT5_A372FaturaValorFaturado = new decimal[1] ;
         P00CT5_A350ContratoDiaEnvioNota = new short[1] ;
         P00CT5_A370FaturaVencimento = new DateTime[] {DateTime.MinValue} ;
         P00CT5_A368FaturaId = new long[1] ;
         A374FaturaDtPagamento = (DateTime)(DateTime.MinValue);
         A370FaturaVencimento = DateTime.MinValue;
         A419FaturaDtPrevistaFaturamento = DateTime.MinValue;
         AV96FaturaVencimento = DateTime.MinValue;
         AV98DtFaturamento = DateTime.MinValue;
         AV100Previsto = DateTime.MinValue;
         P00CT6_A309ProdutoId = new long[1] ;
         P00CT6_A344ContratoId = new long[1] ;
         P00CT6_A310ProdutoDescricao = new string[] {""} ;
         P00CT6_A542ContratoProdutoPreco = new decimal[1] ;
         A310ProdutoDescricao = "";
         AV102ProdutoNome = "";
         P00CT7_A163FuncaoId = new long[1] ;
         P00CT7_A344ContratoId = new long[1] ;
         P00CT7_A164FuncaoNome = new string[] {""} ;
         P00CT7_A539ContratoProfissionalHoraMes = new short[1] ;
         P00CT7_A538ContratoProfissionalQtd = new short[1] ;
         P00CT7_A540ContratoProfissionalValor = new decimal[1] ;
         A164FuncaoNome = "";
         AV103FuncaoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriocontrato__default(),
            new Object[][] {
                new Object[] {
               P00CT2_A1EmpresaId, P00CT2_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00CT3_A17ClienteId, P00CT3_A392TipoContratoId, P00CT3_n392TipoContratoId, P00CT3_A344ContratoId, P00CT3_A345ContratoNome, P00CT3_A346ContratoDescricao, P00CT3_A350ContratoDiaEnvioNota, P00CT3_A400ContratoDiasVencimento, P00CT3_A396ContratoDtAssinatura, P00CT3_A404ContratoDtFimVigencia,
               P00CT3_A395ContratoDtInicioVigencia, P00CT3_A353ContratoFinanceiroEmail, P00CT3_A352ContratoFinanceiroNome, P00CT3_A354ContratoFinanceiroTelefone, P00CT3_A349ContratoPrazo, P00CT3_A397ContratoValor, P00CT3_A351ContratoVencimento, P00CT3_A393TipoContratoDescricao, P00CT3_A18ClienteNome
               }
               , new Object[] {
               P00CT4_A344ContratoId, P00CT4_A357ResponsavelNome, P00CT4_A358ResponsavelEmail, P00CT4_A359ResponsavelTelefone, P00CT4_A356ResponsavelId
               }
               , new Object[] {
               P00CT5_A344ContratoId, P00CT5_A369FaturaParcela, P00CT5_A371FaturaValor, P00CT5_A374FaturaDtPagamento, P00CT5_A372FaturaValorFaturado, P00CT5_A350ContratoDiaEnvioNota, P00CT5_A370FaturaVencimento, P00CT5_A368FaturaId
               }
               , new Object[] {
               P00CT6_A309ProdutoId, P00CT6_A344ContratoId, P00CT6_A310ProdutoDescricao, P00CT6_A542ContratoProdutoPreco
               }
               , new Object[] {
               P00CT7_A163FuncaoId, P00CT7_A344ContratoId, P00CT7_A164FuncaoNome, P00CT7_A539ContratoProfissionalHoraMes, P00CT7_A538ContratoProfissionalQtd, P00CT7_A540ContratoProfissionalValor
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A350ContratoDiaEnvioNota ;
      private short A400ContratoDiasVencimento ;
      private short A349ContratoPrazo ;
      private short A351ContratoVencimento ;
      private short AV77ContratoDiaEnvioNota ;
      private short AV78ContratoDiasVencimento ;
      private short AV85ContratoPrazo ;
      private short AV87ContratoVencimento ;
      private short A369FaturaParcela ;
      private short AV95FaturaParcela ;
      private short A539ContratoProfissionalHoraMes ;
      private short A538ContratoProfissionalQtd ;
      private short AV104Quantidade ;
      private short AV105HoraMes ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV14ContratoId ;
      private long AV20EmpresaId ;
      private long A1EmpresaId ;
      private long A17ClienteId ;
      private long A392TipoContratoId ;
      private long A344ContratoId ;
      private long A356ResponsavelId ;
      private long A368FaturaId ;
      private long A309ProdutoId ;
      private long A163FuncaoId ;
      private decimal A397ContratoValor ;
      private decimal AV86ContratoValor ;
      private decimal A371FaturaValor ;
      private decimal A372FaturaValorFaturado ;
      private decimal AV97FaturaValor ;
      private decimal AV99FaturaValorFaturado ;
      private decimal A542ContratoProdutoPreco ;
      private decimal AV101ProdutoPreco ;
      private decimal A540ContratoProfissionalValor ;
      private decimal A541ContratoProfissionalTotal ;
      private decimal AV106Valor ;
      private decimal AV69Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A345ContratoNome ;
      private string A352ContratoFinanceiroNome ;
      private string A354ContratoFinanceiroTelefone ;
      private string A393TipoContratoDescricao ;
      private string A18ClienteNome ;
      private string AV83ContratoFinanceiroNome ;
      private string AV84ContratoFinanceiroTelefone ;
      private string AV91ContratoNome ;
      private string AV90TipoContratoDescricao ;
      private string AV89ClienteNome ;
      private string sImgUrl ;
      private string A357ResponsavelNome ;
      private string A359ResponsavelTelefone ;
      private string AV92ResponsavelNome ;
      private string AV94ResponsavelTelefone ;
      private string AV102ProdutoNome ;
      private string A164FuncaoNome ;
      private string AV103FuncaoNome ;
      private DateTime AV15DateTime ;
      private DateTime A374FaturaDtPagamento ;
      private DateTime A396ContratoDtAssinatura ;
      private DateTime A404ContratoDtFimVigencia ;
      private DateTime A395ContratoDtInicioVigencia ;
      private DateTime AV79ContratoDtAssinatura ;
      private DateTime AV80ContratoDtFimVigencia ;
      private DateTime AV81ContratoDtInicioVigencia ;
      private DateTime A370FaturaVencimento ;
      private DateTime A419FaturaDtPrevistaFaturamento ;
      private DateTime AV96FaturaVencimento ;
      private DateTime AV98DtFaturamento ;
      private DateTime AV100Previsto ;
      private bool entryPointCalled ;
      private bool n392TipoContratoId ;
      private string A40000EmpresaFoto_GXI ;
      private string AV19EmpresaFotoUrl ;
      private string AV71Url ;
      private string AV108Empresafoto_GXI ;
      private string A346ContratoDescricao ;
      private string A353ContratoFinanceiroEmail ;
      private string AV16Descricao ;
      private string AV76ContratoDescricao ;
      private string AV82ContratoFinanceiroEmail ;
      private string A358ResponsavelEmail ;
      private string AV93ResponsavelEmail ;
      private string A310ProdutoDescricao ;
      private string AV18EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV75WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV55SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00CT2_A1EmpresaId ;
      private string[] P00CT2_A40000EmpresaFoto_GXI ;
      private long[] P00CT3_A17ClienteId ;
      private long[] P00CT3_A392TipoContratoId ;
      private bool[] P00CT3_n392TipoContratoId ;
      private long[] P00CT3_A344ContratoId ;
      private string[] P00CT3_A345ContratoNome ;
      private string[] P00CT3_A346ContratoDescricao ;
      private short[] P00CT3_A350ContratoDiaEnvioNota ;
      private short[] P00CT3_A400ContratoDiasVencimento ;
      private DateTime[] P00CT3_A396ContratoDtAssinatura ;
      private DateTime[] P00CT3_A404ContratoDtFimVigencia ;
      private DateTime[] P00CT3_A395ContratoDtInicioVigencia ;
      private string[] P00CT3_A353ContratoFinanceiroEmail ;
      private string[] P00CT3_A352ContratoFinanceiroNome ;
      private string[] P00CT3_A354ContratoFinanceiroTelefone ;
      private short[] P00CT3_A349ContratoPrazo ;
      private decimal[] P00CT3_A397ContratoValor ;
      private short[] P00CT3_A351ContratoVencimento ;
      private string[] P00CT3_A393TipoContratoDescricao ;
      private string[] P00CT3_A18ClienteNome ;
      private long[] P00CT4_A344ContratoId ;
      private string[] P00CT4_A357ResponsavelNome ;
      private string[] P00CT4_A358ResponsavelEmail ;
      private string[] P00CT4_A359ResponsavelTelefone ;
      private long[] P00CT4_A356ResponsavelId ;
      private long[] P00CT5_A344ContratoId ;
      private short[] P00CT5_A369FaturaParcela ;
      private decimal[] P00CT5_A371FaturaValor ;
      private DateTime[] P00CT5_A374FaturaDtPagamento ;
      private decimal[] P00CT5_A372FaturaValorFaturado ;
      private short[] P00CT5_A350ContratoDiaEnvioNota ;
      private DateTime[] P00CT5_A370FaturaVencimento ;
      private long[] P00CT5_A368FaturaId ;
      private long[] P00CT6_A309ProdutoId ;
      private long[] P00CT6_A344ContratoId ;
      private string[] P00CT6_A310ProdutoDescricao ;
      private decimal[] P00CT6_A542ContratoProdutoPreco ;
      private long[] P00CT7_A163FuncaoId ;
      private long[] P00CT7_A344ContratoId ;
      private string[] P00CT7_A164FuncaoNome ;
      private short[] P00CT7_A539ContratoProfissionalHoraMes ;
      private short[] P00CT7_A538ContratoProfissionalQtd ;
      private decimal[] P00CT7_A540ContratoProfissionalValor ;
   }

   public class aprcrelatoriocontrato__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CT2;
          prmP00CT2 = new Object[] {
          new ParDef("@AV20EmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00CT3;
          prmP00CT3 = new Object[] {
          new ParDef("@AV14ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CT4;
          prmP00CT4 = new Object[] {
          new ParDef("@AV14ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CT5;
          prmP00CT5 = new Object[] {
          new ParDef("@AV14ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CT6;
          prmP00CT6 = new Object[] {
          new ParDef("@AV14ContratoId",GXType.Decimal,18,0)
          };
          Object[] prmP00CT7;
          prmP00CT7 = new Object[] {
          new ParDef("@AV14ContratoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CT2", "SELECT [EmpresaId], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV20EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CT3", "SELECT T1.[ClienteId], T1.[TipoContratoId], T1.[ContratoId], T1.[ContratoNome], T1.[ContratoDescricao], T1.[ContratoDiaEnvioNota], T1.[ContratoDiasVencimento], T1.[ContratoDtAssinatura], T1.[ContratoDtFimVigencia], T1.[ContratoDtInicioVigencia], T1.[ContratoFinanceiroEmail], T1.[ContratoFinanceiroNome], T1.[ContratoFinanceiroTelefone], T1.[ContratoPrazo], T1.[ContratoValor], T1.[ContratoVencimento], T3.[TipoContratoDescricao], T2.[ClienteNome] FROM (([Contrato] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteId]) LEFT JOIN [TipoContrato] T3 ON T3.[TipoContratoId] = T1.[TipoContratoId]) WHERE T1.[ContratoId] = @AV14ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CT4", "SELECT [ContratoId], [ResponsavelNome], [ResponsavelEmail], [ResponsavelTelefone], [ResponsavelId] FROM [ContratoResponsavel] WHERE [ContratoId] = @AV14ContratoId ORDER BY [ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CT5", "SELECT T1.[ContratoId], T1.[FaturaParcela], T1.[FaturaValor], T1.[FaturaDtPagamento], T1.[FaturaValorFaturado], T2.[ContratoDiaEnvioNota], T1.[FaturaVencimento], T1.[FaturaId] FROM ([ContratoFaturamento] T1 INNER JOIN [Contrato] T2 ON T2.[ContratoId] = T1.[ContratoId]) WHERE T1.[ContratoId] = @AV14ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CT6", "SELECT T1.[ProdutoId], T1.[ContratoId], T2.[ProdutoDescricao], T1.[ContratoProdutoPreco] FROM ([ContratoProduto] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) WHERE T1.[ContratoId] = @AV14ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CT7", "SELECT T1.[FuncaoId], T1.[ContratoId], T2.[FuncaoNome], T1.[ContratoProfissionalHoraMes], T1.[ContratoProfissionalQtd], T1.[ContratoProfissionalValor] FROM ([ContratoProfissional] T1 INNER JOIN [Funcao] T2 ON T2.[FuncaoId] = T1.[FuncaoId]) WHERE T1.[ContratoId] = @AV14ContratoId ORDER BY T1.[ContratoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT7,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 60);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 60);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((short[]) buf[16])[0] = rslt.getShort(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 60);
                ((string[]) buf[18])[0] = rslt.getString(18, 60);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
