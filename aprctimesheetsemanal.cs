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
   public class aprctimesheetsemanal : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "GestaoServicoId");
            if ( ! entryPointCalled )
            {
               AV8GestaoServicoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV43Date = context.localUtil.ParseDateParm( GetPar( "Date"));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprctimesheetsemanal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprctimesheetsemanal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_GestaoServicoId ,
                           DateTime aP1_Date )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV43Date = aP1_Date;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_GestaoServicoId ,
                                 DateTime aP1_Date )
      {
         this.AV8GestaoServicoId = aP0_GestaoServicoId;
         this.AV43Date = aP1_Date;
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
         setOutputFileName("TimeSheetSemanal.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            AV11SDTContexto.FromJSonString(AV10WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
            AV12EmpresaId = AV11SDTContexto.gxTpr_Empresaid;
            AV13DateTime = DateTimeUtil.Now( context);
            /* Using cursor P00C82 */
            pr_default.execute(0, new Object[] {AV12EmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00C82_A1EmpresaId[0];
               A2EmpresaNome = P00C82_A2EmpresaNome[0];
               A5EmpresaEndereco = P00C82_A5EmpresaEndereco[0];
               A4EmpresaContato = P00C82_A4EmpresaContato[0];
               A40000EmpresaFoto_GXI = P00C82_A40000EmpresaFoto_GXI[0];
               AV14EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV15EmpresaEndereco = StringUtil.Trim( A5EmpresaEndereco);
               AV35EmpresaContato = A4EmpresaContato;
               AV16EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV17Url = StringUtil.StringReplace( AV16EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV64Empresafoto_GXI = AV17Url;
               AV9EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00C83 */
            pr_default.execute(1, new Object[] {AV8GestaoServicoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A34ServicoClienteId = P00C83_A34ServicoClienteId[0];
               A36ServicoSetorId = P00C83_A36ServicoSetorId[0];
               A53ServicoNaturezaId = P00C83_A53ServicoNaturezaId[0];
               n53ServicoNaturezaId = P00C83_n53ServicoNaturezaId[0];
               A38GestaoServicoId = P00C83_A38GestaoServicoId[0];
               A79GestaoServicoNumero = P00C83_A79GestaoServicoNumero[0];
               A40GestaoServicoDescricao = P00C83_A40GestaoServicoDescricao[0];
               A35ServicoClienteNome = P00C83_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00C83_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00C83_A54ServicoNaturezaNome[0];
               A41GestaoServicoPrioridade = P00C83_A41GestaoServicoPrioridade[0];
               A42GestaoServicoStatus = P00C83_A42GestaoServicoStatus[0];
               A35ServicoClienteNome = P00C83_A35ServicoClienteNome[0];
               A37ServicoSetorNome = P00C83_A37ServicoSetorNome[0];
               A54ServicoNaturezaNome = P00C83_A54ServicoNaturezaNome[0];
               AV18GestaoServicoNumero = A79GestaoServicoNumero;
               AV25GestaoServicoDescricao = A40GestaoServicoDescricao;
               AV19ServicoClienteNome = A35ServicoClienteNome;
               AV20ServicoSetorNome = A37ServicoSetorNome;
               AV29ServicoNaturezaNome = A54ServicoNaturezaNome;
               AV21GestaoServicoPrioridadeDescricao = context.GetMessage( gxdomainprioridadeservico.getDescription(context,A41GestaoServicoPrioridade), "");
               AV22GestaoServicoStatusDescricao = context.GetMessage( gxdomainstatusservico.getDescription(context,A42GestaoServicoStatus), "");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00C84 */
            pr_default.execute(2, new Object[] {AV8GestaoServicoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A38GestaoServicoId = P00C84_A38GestaoServicoId[0];
               A56ServicoExecutanteNome = P00C84_A56ServicoExecutanteNome[0];
               A55ServicoExecutanteId = P00C84_A55ServicoExecutanteId[0];
               n55ServicoExecutanteId = P00C84_n55ServicoExecutanteId[0];
               A131GestaoServicoExecutanteId = P00C84_A131GestaoServicoExecutanteId[0];
               A56ServicoExecutanteNome = P00C84_A56ServicoExecutanteNome[0];
               AV23TecnicoNome = A56ServicoExecutanteNome;
               new prcretornafuncao(context ).execute(  A55ServicoExecutanteId, out  AV24FuncaoNome) ;
               HC80( false, 17) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+0, 775, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TecnicoNome, "")), 258, Gx_line+1, 733, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FuncaoNome, "")), 33, Gx_line+1, 233, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HC80( false, 50) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(125, Gx_line+17, 142, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(667, Gx_line+17, 684, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(333, Gx_line+17, 350, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(200, Gx_line+17, 217, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "JORNADA", ""), 242, Gx_line+17, 303, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DATA", ""), 142, Gx_line+28, 177, Gx_line+42, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DIA", ""), 58, Gx_line+28, 81, Gx_line+42, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DESCRIÇÃO", ""), 450, Gx_line+27, 525, Gx_line+41, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "HORAS", ""), 699, Gx_line+27, 746, Gx_line+44, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "FIM", ""), 283, Gx_line+33, 306, Gx_line+47, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "INICIO", ""), 217, Gx_line+33, 258, Gx_line+47, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+50);
            AV56AuxDate = AV43Date;
            AV42i = 1;
            while ( AV42i <= 7 )
            {
               AV53SDTData = new SdtSDTData(context);
               AV53SDTData.gxTpr_Diasemana = DateTimeUtil.CDow( AV56AuxDate, context.GetLanguage( ));
               /* Using cursor P00C85 */
               pr_default.execute(3, new Object[] {AV8GestaoServicoId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A136OrdemExecutanteDtInicio = P00C85_A136OrdemExecutanteDtInicio[0];
                  A145OrdemGestaoServicoId = P00C85_A145OrdemGestaoServicoId[0];
                  A137OrdemExecutanteHrInicio = P00C85_A137OrdemExecutanteHrInicio[0];
                  A148OrdemExecutanteDesconto = P00C85_A148OrdemExecutanteDesconto[0];
                  A139OrdemExecutanteHrConclusao = P00C85_A139OrdemExecutanteHrConclusao[0];
                  A140OrdemExecutanteComentario = P00C85_A140OrdemExecutanteComentario[0];
                  A135OrdemExecutanteId = P00C85_A135OrdemExecutanteId[0];
                  if ( StringUtil.StrCmp(DateTimeUtil.CDow( A136OrdemExecutanteDtInicio, context.GetLanguage( )), AV53SDTData.gxTpr_Diasemana) == 0 )
                  {
                     AV53SDTData = new SdtSDTData(context);
                     AV53SDTData.gxTpr_Diasemana = DateTimeUtil.CDow( AV56AuxDate, context.GetLanguage( ));
                     AV47NumSegundos = (long)(DateTimeUtil.TDiff( DateTimeUtil.TAdd( A139OrdemExecutanteHrConclusao, 3600*(-DateTimeUtil.Hour( A148OrdemExecutanteDesconto))), A137OrdemExecutanteHrInicio));
                     if ( AV47NumSegundos != 0 )
                     {
                        AV48HsNum = (decimal)(AV47NumSegundos/ (decimal)(3600));
                     }
                     AV49Dif = AV48HsNum;
                     AV50Hora = (short)(NumberUtil.Int( (long)(Math.Round(AV49Dif, 18, MidpointRounding.ToEven))));
                     AV51Min = (decimal)(AV49Dif-AV50Hora);
                     AV52Minutos = (short)(AV51Min*60);
                     AV46Horas = StringUtil.Trim( StringUtil.Str( (decimal)(AV50Hora), 4, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV52Minutos), 4, 0));
                     AV53SDTData.gxTpr_Date = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
                     AV53SDTData.gxTpr_Inicio = A137OrdemExecutanteHrInicio;
                     AV53SDTData.gxTpr_Fim = A139OrdemExecutanteHrConclusao;
                     AV53SDTData.gxTpr_Descricao = StringUtil.Trim( A140OrdemExecutanteComentario);
                     AV53SDTData.gxTpr_Horas = AV46Horas;
                     AV54SDTDataCollection.Add(AV53SDTData, 0);
                     AV58IsExiste = true;
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               if ( ! AV58IsExiste )
               {
                  AV54SDTDataCollection.Add(AV53SDTData, 0);
               }
               AV58IsExiste = false;
               AV56AuxDate = DateTimeUtil.DAdd( AV43Date, (AV42i));
               AV42i = (short)(AV42i+1);
            }
            AV68GXV1 = 1;
            while ( AV68GXV1 <= AV54SDTDataCollection.Count )
            {
               AV53SDTData = ((SdtSDTData)AV54SDTDataCollection.Item(AV68GXV1));
               AV62HoraTamanho = (short)(StringUtil.Len( AV53SDTData.gxTpr_Horas));
               AV38DiaSemanaVarChar = AV53SDTData.gxTpr_Diasemana;
               AV40Data = AV53SDTData.gxTpr_Date;
               AV41InicioDate = AV53SDTData.gxTpr_Inicio;
               AV44FimDate = AV53SDTData.gxTpr_Fim;
               if ( AV62HoraTamanho == 3 )
               {
                  AV46Horas = AV53SDTData.gxTpr_Horas + "0";
               }
               else
               {
                  AV46Horas = AV53SDTData.gxTpr_Horas;
               }
               HC80( false, 17) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38DiaSemanaVarChar, "")), 33, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(125, Gx_line+0, 142, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(200, Gx_line+0, 217, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(333, Gx_line+0, 350, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(667, Gx_line+0, 684, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Data, "")), 133, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV41InicioDate, "99:99"), 208, Gx_line+0, 258, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV44FimDate, "99:99"), 266, Gx_line+0, 324, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45HoraDescricao, "")), 342, Gx_line+0, 659, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Horas, "")), 683, Gx_line+0, 759, Gx_line+15, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV68GXV1 = (int)(AV68GXV1+1);
            }
            HC80( false, 50) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 775, Gx_line+50, 1, 0, 0, 0, 1, 192, 192, 192, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "DESCRIÇÃO DAS ATIVIDADES", ""), 283, Gx_line+28, 469, Gx_line+43, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+50);
            /* Using cursor P00C86 */
            pr_default.execute(4, new Object[] {AV8GestaoServicoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A145OrdemGestaoServicoId = P00C86_A145OrdemGestaoServicoId[0];
               A140OrdemExecutanteComentario = P00C86_A140OrdemExecutanteComentario[0];
               A135OrdemExecutanteId = P00C86_A135OrdemExecutanteId[0];
               AV33Contador = (short)(AV33Contador+1);
               AV34AtividadeDescricao = StringUtil.Trim( A140OrdemExecutanteComentario);
               HC80( false, 17) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 775, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 75, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33Contador), "ZZZ9")), 33, Gx_line+0, 58, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34AtividadeDescricao, "")), 83, Gx_line+0, 771, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            HC80( false, 331) ;
            getPrinter().GxDrawRect(17, Gx_line+183, 775, Gx_line+266, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Responsável", ""), 33, Gx_line+200, 168, Gx_line+214, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data", ""), 683, Gx_line+200, 708, Gx_line+214, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Assinatura do Cliente", ""), 408, Gx_line+200, 512, Gx_line+214, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Data", ""), 300, Gx_line+200, 325, Gx_line+214, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+250, 258, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(300, Gx_line+250, 367, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(408, Gx_line+250, 633, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(683, Gx_line+250, 758, Gx_line+250, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15EmpresaEndereco, "")), 125, Gx_line+283, 663, Gx_line+298, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpresaContato, "")), 233, Gx_line+300, 529, Gx_line+315, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+331);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC80( true, 0) ;
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

      protected void HC80( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 15, true, true, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "TIME SHEET", ""), 33, Gx_line+83, 175, Gx_line+109, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9EmpresaFoto)) ? AV64Empresafoto_GXI : AV9EmpresaFoto);
               getPrinter().GxDrawBitMap(sImgUrl, 242, Gx_line+17, 559, Gx_line+117) ;
               getPrinter().GxDrawRect(17, Gx_line+133, 775, Gx_line+250, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+133, 775, Gx_line+150, 1, 0, 0, 0, 1, 192, 192, 192, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+183, 242, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+200, 242, Gx_line+217, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Setor:", ""), 33, Gx_line+201, 69, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente:", ""), 33, Gx_line+184, 79, Gx_line+198, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Número da OS:", ""), 33, Gx_line+153, 124, Gx_line+170, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Prioridade:", ""), 33, Gx_line+218, 98, Gx_line+232, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Status:", ""), 33, Gx_line+234, 76, Gx_line+248, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+217, 242, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+150, 775, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+217, 775, Gx_line+234, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+200, 775, Gx_line+217, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+183, 775, Gx_line+200, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+167, 775, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18GestaoServicoNumero), "ZZZZZZZZZZZZZZZZZ9")), 258, Gx_line+153, 372, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ServicoClienteNome, "")), 258, Gx_line+184, 572, Gx_line+199, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ServicoSetorNome, "")), 258, Gx_line+201, 572, Gx_line+216, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21GestaoServicoPrioridadeDescricao, "")), 258, Gx_line+218, 412, Gx_line+233, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22GestaoServicoStatusDescricao, "")), 258, Gx_line+236, 412, Gx_line+251, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+267, 775, Gx_line+284, 1, 0, 0, 0, 1, 192, 192, 192, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+283, 775, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+283, 775, Gx_line+300, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 1, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "ORDEM DE SERVIÇO", ""), 317, Gx_line+134, 447, Gx_line+151, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "TÉCNICO", ""), 342, Gx_line+268, 399, Gx_line+285, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "NOME", ""), 258, Gx_line+286, 297, Gx_line+301, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "FUNÇÃO", ""), 33, Gx_line+286, 86, Gx_line+300, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Descrição da OS:", ""), 33, Gx_line+168, 138, Gx_line+182, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+167, 242, Gx_line+184, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+233, 242, Gx_line+250, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25GestaoServicoDescricao, "")), 258, Gx_line+168, 729, Gx_line+183, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+301);
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, true, 58, 14, 72, 123,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 18, 21, 30, 35, 35, 55, 45, 14, 21, 21, 25, 37, 18, 21, 18, 18, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 21, 21, 37, 37, 37, 38, 61, 45, 45, 45, 45, 42, 38, 49, 45, 17, 35, 45, 38, 52, 45, 49, 42, 49, 45, 42, 38, 45, 42, 59, 42, 42, 38, 21, 18, 23, 37, 35, 21, 35, 38, 35, 38, 35, 21, 38, 38, 18, 18, 35, 18, 56, 38, 38, 38, 38, 25, 35, 21, 38, 35, 49, 35, 35, 32, 25, 17, 25, 37, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 18, 21, 36, 35, 35, 35, 17, 35, 21, 46, 23, 35, 37, 21, 46, 35, 25, 35, 21, 21, 21, 36, 35, 21, 21, 21, 23, 35, 53, 53, 53, 38, 45, 45, 45, 45, 45, 45, 63, 45, 42, 42, 42, 42, 18, 18, 18, 18, 45, 45, 49, 49, 49, 49, 49, 37, 49, 45, 45, 45, 45, 42, 42, 38, 35, 35, 35, 35, 35, 35, 56, 35, 35, 35, 35, 35, 18, 18, 18, 18, 38, 38, 38, 38, 38, 38, 38, 35, 38, 38, 38, 38, 38, 35, 38, 35}) ;
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
         AV11SDTContexto = new SdtSDTContexto(context);
         AV10WebSession = context.GetSession();
         AV13DateTime = (DateTime)(DateTime.MinValue);
         P00C82_A1EmpresaId = new long[1] ;
         P00C82_A2EmpresaNome = new string[] {""} ;
         P00C82_A5EmpresaEndereco = new string[] {""} ;
         P00C82_A4EmpresaContato = new string[] {""} ;
         P00C82_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A5EmpresaEndereco = "";
         A4EmpresaContato = "";
         A40000EmpresaFoto_GXI = "";
         AV14EmpresaNome = "";
         AV15EmpresaEndereco = "";
         AV35EmpresaContato = "";
         AV16EmpresaFotoUrl = "";
         AV17Url = "";
         AV64Empresafoto_GXI = "";
         AV9EmpresaFoto = "";
         P00C83_A34ServicoClienteId = new long[1] ;
         P00C83_A36ServicoSetorId = new long[1] ;
         P00C83_A53ServicoNaturezaId = new long[1] ;
         P00C83_n53ServicoNaturezaId = new bool[] {false} ;
         P00C83_A38GestaoServicoId = new long[1] ;
         P00C83_A79GestaoServicoNumero = new long[1] ;
         P00C83_A40GestaoServicoDescricao = new string[] {""} ;
         P00C83_A35ServicoClienteNome = new string[] {""} ;
         P00C83_A37ServicoSetorNome = new string[] {""} ;
         P00C83_A54ServicoNaturezaNome = new string[] {""} ;
         P00C83_A41GestaoServicoPrioridade = new short[1] ;
         P00C83_A42GestaoServicoStatus = new short[1] ;
         A40GestaoServicoDescricao = "";
         A35ServicoClienteNome = "";
         A37ServicoSetorNome = "";
         A54ServicoNaturezaNome = "";
         AV25GestaoServicoDescricao = "";
         AV19ServicoClienteNome = "";
         AV20ServicoSetorNome = "";
         AV29ServicoNaturezaNome = "";
         AV21GestaoServicoPrioridadeDescricao = "";
         AV22GestaoServicoStatusDescricao = "";
         P00C84_A38GestaoServicoId = new long[1] ;
         P00C84_A56ServicoExecutanteNome = new string[] {""} ;
         P00C84_A55ServicoExecutanteId = new long[1] ;
         P00C84_n55ServicoExecutanteId = new bool[] {false} ;
         P00C84_A131GestaoServicoExecutanteId = new long[1] ;
         A56ServicoExecutanteNome = "";
         AV23TecnicoNome = "";
         AV24FuncaoNome = "";
         AV56AuxDate = DateTime.MinValue;
         AV53SDTData = new SdtSDTData(context);
         P00C85_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P00C85_A145OrdemGestaoServicoId = new long[1] ;
         P00C85_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P00C85_A148OrdemExecutanteDesconto = new DateTime[] {DateTime.MinValue} ;
         P00C85_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P00C85_A140OrdemExecutanteComentario = new string[] {""} ;
         P00C85_A135OrdemExecutanteId = new long[1] ;
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A148OrdemExecutanteDesconto = (DateTime)(DateTime.MinValue);
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         AV46Horas = "";
         AV54SDTDataCollection = new GXBaseCollection<SdtSDTData>( context, "SDTData", "iServiceKB");
         AV38DiaSemanaVarChar = "";
         AV40Data = "";
         AV41InicioDate = (DateTime)(DateTime.MinValue);
         AV44FimDate = (DateTime)(DateTime.MinValue);
         AV45HoraDescricao = "";
         P00C86_A145OrdemGestaoServicoId = new long[1] ;
         P00C86_A140OrdemExecutanteComentario = new string[] {""} ;
         P00C86_A135OrdemExecutanteId = new long[1] ;
         AV34AtividadeDescricao = "";
         AV9EmpresaFoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprctimesheetsemanal__default(),
            new Object[][] {
                new Object[] {
               P00C82_A1EmpresaId, P00C82_A2EmpresaNome, P00C82_A5EmpresaEndereco, P00C82_A4EmpresaContato, P00C82_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00C83_A34ServicoClienteId, P00C83_A36ServicoSetorId, P00C83_A53ServicoNaturezaId, P00C83_n53ServicoNaturezaId, P00C83_A38GestaoServicoId, P00C83_A79GestaoServicoNumero, P00C83_A40GestaoServicoDescricao, P00C83_A35ServicoClienteNome, P00C83_A37ServicoSetorNome, P00C83_A54ServicoNaturezaNome,
               P00C83_A41GestaoServicoPrioridade, P00C83_A42GestaoServicoStatus
               }
               , new Object[] {
               P00C84_A38GestaoServicoId, P00C84_A56ServicoExecutanteNome, P00C84_A55ServicoExecutanteId, P00C84_n55ServicoExecutanteId, P00C84_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00C85_A136OrdemExecutanteDtInicio, P00C85_A145OrdemGestaoServicoId, P00C85_A137OrdemExecutanteHrInicio, P00C85_A148OrdemExecutanteDesconto, P00C85_A139OrdemExecutanteHrConclusao, P00C85_A140OrdemExecutanteComentario, P00C85_A135OrdemExecutanteId
               }
               , new Object[] {
               P00C86_A145OrdemGestaoServicoId, P00C86_A140OrdemExecutanteComentario, P00C86_A135OrdemExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A41GestaoServicoPrioridade ;
      private short A42GestaoServicoStatus ;
      private short AV42i ;
      private short AV50Hora ;
      private short AV52Minutos ;
      private short AV62HoraTamanho ;
      private short AV33Contador ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV68GXV1 ;
      private long AV8GestaoServicoId ;
      private long AV12EmpresaId ;
      private long A1EmpresaId ;
      private long A34ServicoClienteId ;
      private long A36ServicoSetorId ;
      private long A53ServicoNaturezaId ;
      private long A38GestaoServicoId ;
      private long A79GestaoServicoNumero ;
      private long AV18GestaoServicoNumero ;
      private long A55ServicoExecutanteId ;
      private long A131GestaoServicoExecutanteId ;
      private long A145OrdemGestaoServicoId ;
      private long A135OrdemExecutanteId ;
      private long AV47NumSegundos ;
      private decimal AV48HsNum ;
      private decimal AV49Dif ;
      private decimal AV51Min ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string A4EmpresaContato ;
      private string AV14EmpresaNome ;
      private string AV35EmpresaContato ;
      private string A35ServicoClienteNome ;
      private string A37ServicoSetorNome ;
      private string A54ServicoNaturezaNome ;
      private string AV19ServicoClienteNome ;
      private string AV20ServicoSetorNome ;
      private string AV29ServicoNaturezaNome ;
      private string A56ServicoExecutanteNome ;
      private string AV23TecnicoNome ;
      private string AV24FuncaoNome ;
      private string sImgUrl ;
      private DateTime AV13DateTime ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A148OrdemExecutanteDesconto ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime AV41InicioDate ;
      private DateTime AV44FimDate ;
      private DateTime AV43Date ;
      private DateTime AV56AuxDate ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n53ServicoNaturezaId ;
      private bool n55ServicoExecutanteId ;
      private bool AV58IsExiste ;
      private string A5EmpresaEndereco ;
      private string A40000EmpresaFoto_GXI ;
      private string AV15EmpresaEndereco ;
      private string AV16EmpresaFotoUrl ;
      private string AV17Url ;
      private string AV64Empresafoto_GXI ;
      private string A40GestaoServicoDescricao ;
      private string AV25GestaoServicoDescricao ;
      private string AV21GestaoServicoPrioridadeDescricao ;
      private string AV22GestaoServicoStatusDescricao ;
      private string A140OrdemExecutanteComentario ;
      private string AV46Horas ;
      private string AV38DiaSemanaVarChar ;
      private string AV40Data ;
      private string AV45HoraDescricao ;
      private string AV34AtividadeDescricao ;
      private string AV9EmpresaFoto ;
      private string Empresafoto ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDTContexto AV11SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00C82_A1EmpresaId ;
      private string[] P00C82_A2EmpresaNome ;
      private string[] P00C82_A5EmpresaEndereco ;
      private string[] P00C82_A4EmpresaContato ;
      private string[] P00C82_A40000EmpresaFoto_GXI ;
      private long[] P00C83_A34ServicoClienteId ;
      private long[] P00C83_A36ServicoSetorId ;
      private long[] P00C83_A53ServicoNaturezaId ;
      private bool[] P00C83_n53ServicoNaturezaId ;
      private long[] P00C83_A38GestaoServicoId ;
      private long[] P00C83_A79GestaoServicoNumero ;
      private string[] P00C83_A40GestaoServicoDescricao ;
      private string[] P00C83_A35ServicoClienteNome ;
      private string[] P00C83_A37ServicoSetorNome ;
      private string[] P00C83_A54ServicoNaturezaNome ;
      private short[] P00C83_A41GestaoServicoPrioridade ;
      private short[] P00C83_A42GestaoServicoStatus ;
      private long[] P00C84_A38GestaoServicoId ;
      private string[] P00C84_A56ServicoExecutanteNome ;
      private long[] P00C84_A55ServicoExecutanteId ;
      private bool[] P00C84_n55ServicoExecutanteId ;
      private long[] P00C84_A131GestaoServicoExecutanteId ;
      private SdtSDTData AV53SDTData ;
      private DateTime[] P00C85_A136OrdemExecutanteDtInicio ;
      private long[] P00C85_A145OrdemGestaoServicoId ;
      private DateTime[] P00C85_A137OrdemExecutanteHrInicio ;
      private DateTime[] P00C85_A148OrdemExecutanteDesconto ;
      private DateTime[] P00C85_A139OrdemExecutanteHrConclusao ;
      private string[] P00C85_A140OrdemExecutanteComentario ;
      private long[] P00C85_A135OrdemExecutanteId ;
      private GXBaseCollection<SdtSDTData> AV54SDTDataCollection ;
      private long[] P00C86_A145OrdemGestaoServicoId ;
      private string[] P00C86_A140OrdemExecutanteComentario ;
      private long[] P00C86_A135OrdemExecutanteId ;
   }

   public class aprctimesheetsemanal__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C82;
          prmP00C82 = new Object[] {
          new ParDef("@AV12EmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00C83;
          prmP00C83 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C84;
          prmP00C84 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C85;
          prmP00C85 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00C86;
          prmP00C86 = new Object[] {
          new ParDef("@AV8GestaoServicoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C82", "SELECT [EmpresaId], [EmpresaNome], [EmpresaEndereco], [EmpresaContato], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV12EmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C82,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C83", "SELECT T1.[ServicoClienteId] AS ServicoClienteId, T1.[ServicoSetorId] AS ServicoSetorId, T1.[ServicoNaturezaId] AS ServicoNaturezaId, T1.[GestaoServicoId], T1.[GestaoServicoNumero], T1.[GestaoServicoDescricao], T2.[ClienteNome] AS ServicoClienteNome, T3.[SetorNome] AS ServicoSetorNome, T4.[NaturezaNome] AS ServicoNaturezaNome, T1.[GestaoServicoPrioridade], T1.[GestaoServicoStatus] FROM ((([GestaoServico] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ServicoClienteId]) INNER JOIN [Setor] T3 ON T3.[SetorId] = T1.[ServicoSetorId]) LEFT JOIN [Natureza] T4 ON T4.[NaturezaId] = T1.[ServicoNaturezaId]) WHERE T1.[GestaoServicoId] = @AV8GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C83,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C84", "SELECT T1.[GestaoServicoId], T2.[UsuarioNome] AS ServicoExecutanteNome, T1.[ServicoExecutanteId] AS ServicoExecutanteId, T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 LEFT JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[ServicoExecutanteId]) WHERE T1.[GestaoServicoId] = @AV8GestaoServicoId ORDER BY T1.[GestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C84,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C85", "SELECT [OrdemExecutanteDtInicio], [OrdemGestaoServicoId], [OrdemExecutanteHrInicio], [OrdemExecutanteDesconto], [OrdemExecutanteHrConclusao], [OrdemExecutanteComentario], [OrdemExecutanteId] FROM [OrdemExecutante] WHERE [OrdemGestaoServicoId] = @AV8GestaoServicoId ORDER BY [OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C85,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C86", "SELECT [OrdemGestaoServicoId], [OrdemExecutanteComentario], [OrdemExecutanteId] FROM [OrdemExecutante] WHERE [OrdemGestaoServicoId] = @AV8GestaoServicoId ORDER BY [OrdemGestaoServicoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C86,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 60);
                ((string[]) buf[8])[0] = rslt.getString(8, 60);
                ((string[]) buf[9])[0] = rslt.getString(9, 60);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
