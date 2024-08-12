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
   public class aprcrelatoriotimesheet : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "UsuarioId");
            if ( ! entryPointCalled )
            {
               AV11UsuarioId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12Inicio = context.localUtil.ParseDateParm( GetPar( "Inicio"));
                  AV13Fim = context.localUtil.ParseDateParm( GetPar( "Fim"));
                  AV15ServicoEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoEmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AV9ServicoClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ServicoClienteId"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprcrelatoriotimesheet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aprcrelatoriotimesheet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           DateTime aP1_Inicio ,
                           DateTime aP2_Fim ,
                           long aP3_ServicoEmpresaId ,
                           long aP4_ServicoClienteId )
      {
         this.AV11UsuarioId = aP0_UsuarioId;
         this.AV12Inicio = aP1_Inicio;
         this.AV13Fim = aP2_Fim;
         this.AV15ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV9ServicoClienteId = aP4_ServicoClienteId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_UsuarioId ,
                                 DateTime aP1_Inicio ,
                                 DateTime aP2_Fim ,
                                 long aP3_ServicoEmpresaId ,
                                 long aP4_ServicoClienteId )
      {
         this.AV11UsuarioId = aP0_UsuarioId;
         this.AV12Inicio = aP1_Inicio;
         this.AV13Fim = aP2_Fim;
         this.AV15ServicoEmpresaId = aP3_ServicoEmpresaId;
         this.AV9ServicoClienteId = aP4_ServicoClienteId;
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
         setOutputFileName("RelatorioTimeSheet.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 14386, 0, 1, 1, 0, 1, 1) )
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
            /* Using cursor P00432 */
            pr_default.execute(0, new Object[] {AV15ServicoEmpresaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EmpresaId = P00432_A1EmpresaId[0];
               A2EmpresaNome = P00432_A2EmpresaNome[0];
               A5EmpresaEndereco = P00432_A5EmpresaEndereco[0];
               A40000EmpresaFoto_GXI = P00432_A40000EmpresaFoto_GXI[0];
               AV22EmpresaNome = StringUtil.Trim( A2EmpresaNome);
               AV23EmpresaEndereco = StringUtil.Trim( A5EmpresaEndereco);
               AV30EmpresaFotoUrl = A40000EmpresaFoto_GXI;
               AV31Url = StringUtil.StringReplace( AV30EmpresaFotoUrl, context.GetMessage( "https", ""), context.GetMessage( "http", ""));
               AV64Empresafoto_GXI = AV31Url;
               AV21EmpresaFoto = "";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV26PeriodoDescricao = StringUtil.Trim( context.localUtil.DToC( AV12Inicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + context.GetMessage( " à ", "") + StringUtil.Trim( context.localUtil.DToC( AV13Fim, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            /* Using cursor P00433 */
            pr_default.execute(1, new Object[] {AV11UsuarioId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9UsuarioId = P00433_A9UsuarioId[0];
               A10UsuarioNome = P00433_A10UsuarioNome[0];
               A11UsuarioPerfil = P00433_A11UsuarioPerfil[0];
               AV24UsuarioNome = A10UsuarioNome;
               AV25UsuarioPerfilDescricao = gxdomainperfilusuario.getDescription(context,A11UsuarioPerfil);
               H430( false, 83) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24UsuarioNome, "")), 93, Gx_line+17, 460, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Funcionário:", ""), 17, Gx_line+17, 91, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25UsuarioPerfilDescricao, "")), 124, Gx_line+49, 366, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "CARGO/FUNÇÃO: ", ""), 17, Gx_line+50, 129, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "PÉRIODO:", ""), 442, Gx_line+50, 506, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26PeriodoDescricao, "")), 506, Gx_line+49, 718, Gx_line+64, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+83);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            H430( false, 34) ;
            getPrinter().GxDrawRect(17, Gx_line+0, 325, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(483, Gx_line+0, 983, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(17, Gx_line+17, 92, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(242, Gx_line+17, 325, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(167, Gx_line+17, 242, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(92, Gx_line+17, 167, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "PÉRIODO", ""), 132, Gx_line+2, 191, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DIA", ""), 42, Gx_line+19, 65, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DATA", ""), 114, Gx_line+19, 149, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "DE", ""), 194, Gx_line+19, 213, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "ATÉ", ""), 269, Gx_line+19, 295, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "HORAS TRABALHADAS", ""), 338, Gx_line+2, 482, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(325, Gx_line+17, 483, Gx_line+34, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "HS", ""), 392, Gx_line+19, 411, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "ATIVIDADES", ""), 692, Gx_line+11, 770, Gx_line+25, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+34);
            AV58UsuarioIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV11UsuarioId), 18, 0));
            AV59ServicoClienteIdVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ServicoClienteId), 18, 0));
            /* Using cursor P00434 */
            pr_default.execute(2, new Object[] {AV58UsuarioIdVarChar, AV59ServicoClienteIdVarChar});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A34ServicoClienteId = P00434_A34ServicoClienteId[0];
               A55ServicoExecutanteId = P00434_A55ServicoExecutanteId[0];
               n55ServicoExecutanteId = P00434_n55ServicoExecutanteId[0];
               A38GestaoServicoId = P00434_A38GestaoServicoId[0];
               A131GestaoServicoExecutanteId = P00434_A131GestaoServicoExecutanteId[0];
               A34ServicoClienteId = P00434_A34ServicoClienteId[0];
               AV41GestaoServicoIdCollection.Add(A38GestaoServicoId, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 A145OrdemGestaoServicoId ,
                                                 AV41GestaoServicoIdCollection ,
                                                 AV9ServicoClienteId ,
                                                 A133OrdemExecutanteUsuarioId ,
                                                 AV11UsuarioId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00435 */
            pr_default.execute(3, new Object[] {AV11UsuarioId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A133OrdemExecutanteUsuarioId = P00435_A133OrdemExecutanteUsuarioId[0];
               A145OrdemGestaoServicoId = P00435_A145OrdemGestaoServicoId[0];
               A137OrdemExecutanteHrInicio = P00435_A137OrdemExecutanteHrInicio[0];
               A139OrdemExecutanteHrConclusao = P00435_A139OrdemExecutanteHrConclusao[0];
               A148OrdemExecutanteDesconto = P00435_A148OrdemExecutanteDesconto[0];
               A140OrdemExecutanteComentario = P00435_A140OrdemExecutanteComentario[0];
               A136OrdemExecutanteDtInicio = P00435_A136OrdemExecutanteDtInicio[0];
               A135OrdemExecutanteId = P00435_A135OrdemExecutanteId[0];
               AV33DiaNome = StringUtil.Substring( DateTimeUtil.CDow( A136OrdemExecutanteDtInicio, context.GetLanguage( )), 1, 3);
               AV34DataNome = StringUtil.Trim( context.localUtil.DToC( A136OrdemExecutanteDtInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV35DtInicio = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A137OrdemExecutanteHrInicio)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A137OrdemExecutanteHrInicio)), 10, 0));
               AV36DtFim = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( A139OrdemExecutanteHrConclusao)), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( A139OrdemExecutanteHrConclusao)), 10, 0));
               AV42NumSegundos = (long)(DateTimeUtil.TDiff( DateTimeUtil.TAdd( A139OrdemExecutanteHrConclusao, 3600*(-DateTimeUtil.Hour( A148OrdemExecutanteDesconto))), A137OrdemExecutanteHrInicio));
               if ( AV42NumSegundos != 0 )
               {
                  AV37HsNum = (decimal)(AV42NumSegundos/ (decimal)(3600));
               }
               AV51Dif = AV37HsNum;
               AV53Hora = (short)(NumberUtil.Int( (long)(Math.Round(AV51Dif, 18, MidpointRounding.ToEven))));
               AV52Min = (decimal)(AV51Dif-AV53Hora);
               AV54Minutos = (short)(AV52Min*60);
               AV55Horas = StringUtil.Trim( StringUtil.Str( (decimal)(AV53Hora), 4, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV54Minutos), 4, 0));
               AV38AtividadeDescricao = StringUtil.Trim( A140OrdemExecutanteComentario);
               AV61TotalNum = (short)(AV61TotalNum+AV53Hora);
               AV62MinNum = (short)(AV62MinNum+AV54Minutos);
               H430( false, 17) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(92, Gx_line+0, 167, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(167, Gx_line+0, 242, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+0, 325, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 92, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(325, Gx_line+0, 483, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(167, Gx_line+0, 242, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(242, Gx_line+0, 325, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(17, Gx_line+0, 92, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(483, Gx_line+0, 983, Gx_line+17, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33DiaNome, "")), 24, Gx_line+0, 82, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34DataNome, "")), 96, Gx_line+0, 161, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35DtInicio, "")), 173, Gx_line+0, 238, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DtFim, "")), 254, Gx_line+0, 319, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Horas, "")), 367, Gx_line+0, 432, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AtividadeDescricao, "")), 491, Gx_line+0, 982, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV60TotalVarChar = StringUtil.Trim( StringUtil.Str( (decimal)(AV61TotalNum), 4, 0)) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV62MinNum), 4, 0));
            H430( false, 258) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Gestor:", ""), 458, Gx_line+183, 516, Gx_line+201, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Funcionário:", ""), 17, Gx_line+183, 100, Gx_line+201, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(100, Gx_line+200, 408, Gx_line+200, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(517, Gx_line+200, 825, Gx_line+200, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+258);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H430( true, 0) ;
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

      protected void H430( bool bFoot ,
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
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaFoto)) ? AV64Empresafoto_GXI : AV21EmpresaFoto);
               getPrinter().GxDrawBitMap(sImgUrl, 17, Gx_line+0, 209, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 15, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "TIME SHEET", ""), 408, Gx_line+67, 608, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EmpresaNome, "")), 17, Gx_line+117, 393, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23EmpresaEndereco, "")), 17, Gx_line+133, 500, Gx_line+148, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+166);
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
         P00432_A1EmpresaId = new long[1] ;
         P00432_A2EmpresaNome = new string[] {""} ;
         P00432_A5EmpresaEndereco = new string[] {""} ;
         P00432_A40000EmpresaFoto_GXI = new string[] {""} ;
         A2EmpresaNome = "";
         A5EmpresaEndereco = "";
         A40000EmpresaFoto_GXI = "";
         AV22EmpresaNome = "";
         AV23EmpresaEndereco = "";
         AV30EmpresaFotoUrl = "";
         AV31Url = "";
         AV64Empresafoto_GXI = "";
         AV21EmpresaFoto = "";
         AV26PeriodoDescricao = "";
         P00433_A9UsuarioId = new long[1] ;
         P00433_A10UsuarioNome = new string[] {""} ;
         P00433_A11UsuarioPerfil = new short[1] ;
         A10UsuarioNome = "";
         AV24UsuarioNome = "";
         AV25UsuarioPerfilDescricao = "";
         AV58UsuarioIdVarChar = "";
         AV59ServicoClienteIdVarChar = "";
         P00434_A34ServicoClienteId = new long[1] ;
         P00434_A55ServicoExecutanteId = new long[1] ;
         P00434_n55ServicoExecutanteId = new bool[] {false} ;
         P00434_A38GestaoServicoId = new long[1] ;
         P00434_A131GestaoServicoExecutanteId = new long[1] ;
         AV41GestaoServicoIdCollection = new GxSimpleCollection<long>();
         P00435_A133OrdemExecutanteUsuarioId = new long[1] ;
         P00435_A145OrdemGestaoServicoId = new long[1] ;
         P00435_A137OrdemExecutanteHrInicio = new DateTime[] {DateTime.MinValue} ;
         P00435_A139OrdemExecutanteHrConclusao = new DateTime[] {DateTime.MinValue} ;
         P00435_A148OrdemExecutanteDesconto = new DateTime[] {DateTime.MinValue} ;
         P00435_A140OrdemExecutanteComentario = new string[] {""} ;
         P00435_A136OrdemExecutanteDtInicio = new DateTime[] {DateTime.MinValue} ;
         P00435_A135OrdemExecutanteId = new long[1] ;
         A137OrdemExecutanteHrInicio = (DateTime)(DateTime.MinValue);
         A139OrdemExecutanteHrConclusao = (DateTime)(DateTime.MinValue);
         A148OrdemExecutanteDesconto = (DateTime)(DateTime.MinValue);
         A140OrdemExecutanteComentario = "";
         A136OrdemExecutanteDtInicio = DateTime.MinValue;
         AV33DiaNome = "";
         AV34DataNome = "";
         AV35DtInicio = "";
         AV36DtFim = "";
         AV55Horas = "";
         AV38AtividadeDescricao = "";
         AV60TotalVarChar = "";
         AV21EmpresaFoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprcrelatoriotimesheet__default(),
            new Object[][] {
                new Object[] {
               P00432_A1EmpresaId, P00432_A2EmpresaNome, P00432_A5EmpresaEndereco, P00432_A40000EmpresaFoto_GXI
               }
               , new Object[] {
               P00433_A9UsuarioId, P00433_A10UsuarioNome, P00433_A11UsuarioPerfil
               }
               , new Object[] {
               P00434_A34ServicoClienteId, P00434_A55ServicoExecutanteId, P00434_n55ServicoExecutanteId, P00434_A38GestaoServicoId, P00434_A131GestaoServicoExecutanteId
               }
               , new Object[] {
               P00435_A133OrdemExecutanteUsuarioId, P00435_A145OrdemGestaoServicoId, P00435_A137OrdemExecutanteHrInicio, P00435_A139OrdemExecutanteHrConclusao, P00435_A148OrdemExecutanteDesconto, P00435_A140OrdemExecutanteComentario, P00435_A136OrdemExecutanteDtInicio, P00435_A135OrdemExecutanteId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A11UsuarioPerfil ;
      private short AV53Hora ;
      private short AV54Minutos ;
      private short AV61TotalNum ;
      private short AV62MinNum ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV11UsuarioId ;
      private long AV15ServicoEmpresaId ;
      private long AV9ServicoClienteId ;
      private long A1EmpresaId ;
      private long A9UsuarioId ;
      private long A34ServicoClienteId ;
      private long A55ServicoExecutanteId ;
      private long A38GestaoServicoId ;
      private long A131GestaoServicoExecutanteId ;
      private long A145OrdemGestaoServicoId ;
      private long A133OrdemExecutanteUsuarioId ;
      private long A135OrdemExecutanteId ;
      private long AV42NumSegundos ;
      private decimal AV37HsNum ;
      private decimal AV51Dif ;
      private decimal AV52Min ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A2EmpresaNome ;
      private string AV22EmpresaNome ;
      private string A10UsuarioNome ;
      private string AV24UsuarioNome ;
      private string AV33DiaNome ;
      private string AV34DataNome ;
      private string AV35DtInicio ;
      private string AV36DtFim ;
      private string sImgUrl ;
      private DateTime A137OrdemExecutanteHrInicio ;
      private DateTime A139OrdemExecutanteHrConclusao ;
      private DateTime A148OrdemExecutanteDesconto ;
      private DateTime AV12Inicio ;
      private DateTime AV13Fim ;
      private DateTime A136OrdemExecutanteDtInicio ;
      private bool entryPointCalled ;
      private bool n55ServicoExecutanteId ;
      private string A5EmpresaEndereco ;
      private string A40000EmpresaFoto_GXI ;
      private string AV23EmpresaEndereco ;
      private string AV30EmpresaFotoUrl ;
      private string AV31Url ;
      private string AV64Empresafoto_GXI ;
      private string AV26PeriodoDescricao ;
      private string AV25UsuarioPerfilDescricao ;
      private string AV58UsuarioIdVarChar ;
      private string AV59ServicoClienteIdVarChar ;
      private string A140OrdemExecutanteComentario ;
      private string AV55Horas ;
      private string AV38AtividadeDescricao ;
      private string AV60TotalVarChar ;
      private string AV21EmpresaFoto ;
      private string Empresafoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00432_A1EmpresaId ;
      private string[] P00432_A2EmpresaNome ;
      private string[] P00432_A5EmpresaEndereco ;
      private string[] P00432_A40000EmpresaFoto_GXI ;
      private long[] P00433_A9UsuarioId ;
      private string[] P00433_A10UsuarioNome ;
      private short[] P00433_A11UsuarioPerfil ;
      private long[] P00434_A34ServicoClienteId ;
      private long[] P00434_A55ServicoExecutanteId ;
      private bool[] P00434_n55ServicoExecutanteId ;
      private long[] P00434_A38GestaoServicoId ;
      private long[] P00434_A131GestaoServicoExecutanteId ;
      private GxSimpleCollection<long> AV41GestaoServicoIdCollection ;
      private long[] P00435_A133OrdemExecutanteUsuarioId ;
      private long[] P00435_A145OrdemGestaoServicoId ;
      private DateTime[] P00435_A137OrdemExecutanteHrInicio ;
      private DateTime[] P00435_A139OrdemExecutanteHrConclusao ;
      private DateTime[] P00435_A148OrdemExecutanteDesconto ;
      private string[] P00435_A140OrdemExecutanteComentario ;
      private DateTime[] P00435_A136OrdemExecutanteDtInicio ;
      private long[] P00435_A135OrdemExecutanteId ;
   }

   public class aprcrelatoriotimesheet__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00435( IGxContext context ,
                                             long A145OrdemGestaoServicoId ,
                                             GxSimpleCollection<long> AV41GestaoServicoIdCollection ,
                                             long AV9ServicoClienteId ,
                                             long A133OrdemExecutanteUsuarioId ,
                                             long AV11UsuarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [OrdemExecutanteUsuarioId], [OrdemGestaoServicoId], [OrdemExecutanteHrInicio], [OrdemExecutanteHrConclusao], [OrdemExecutanteDesconto], [OrdemExecutanteComentario], [OrdemExecutanteDtInicio], [OrdemExecutanteId] FROM [OrdemExecutante]";
         AddWhere(sWhereString, "([OrdemExecutanteUsuarioId] = @AV11UsuarioId)");
         if ( ! (0==AV9ServicoClienteId) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV41GestaoServicoIdCollection, "[OrdemGestaoServicoId] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OrdemExecutanteDtInicio]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P00435(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("@AV15ServicoEmpresaId",GXType.Decimal,18,0)
          };
          Object[] prmP00433;
          prmP00433 = new Object[] {
          new ParDef("@AV11UsuarioId",GXType.Decimal,18,0)
          };
          Object[] prmP00434;
          prmP00434 = new Object[] {
          new ParDef("@AV58UsuarioIdVarChar",GXType.VarChar,40,0) ,
          new ParDef("@AV59ServicoClienteIdVarChar",GXType.VarChar,40,0)
          };
          Object[] prmP00435;
          prmP00435 = new Object[] {
          new ParDef("@AV11UsuarioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "SELECT [EmpresaId], [EmpresaNome], [EmpresaEndereco], [EmpresaFoto_GXI] FROM [Empresa] WHERE [EmpresaId] = @AV15ServicoEmpresaId ORDER BY [EmpresaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00433", "SELECT [UsuarioId], [UsuarioNome], [UsuarioPerfil] FROM [Usuario] WHERE [UsuarioId] = @AV11UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00433,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00434", "SELECT T2.[ServicoClienteId], T1.[ServicoExecutanteId], T1.[GestaoServicoId], T1.[GestaoServicoExecutanteId] FROM ([GestaoServicoExecutante] T1 INNER JOIN [GestaoServico] T2 ON T2.[GestaoServicoId] = T1.[GestaoServicoId]) WHERE (T1.[ServicoExecutanteId] = CONVERT( DECIMAL(28,14), @AV58UsuarioIdVarChar)) AND (T2.[ServicoClienteId] = CONVERT( DECIMAL(28,14), @AV59ServicoClienteIdVarChar)) ORDER BY T1.[GestaoServicoExecutanteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00434,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00435", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00435,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
