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
   public class acargamodulos : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public acargamodulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public acargamodulos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Gestão de Serviços", "");
         A749ModuloAtivo = true;
         A750ModuloLine = 1;
         /* Using cursor P00HT2 */
         pr_default.execute(0, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT2_A754ModuloId[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Controle de Combustível", "");
         A749ModuloAtivo = false;
         A750ModuloLine = 1;
         /* Using cursor P00HT3 */
         pr_default.execute(1, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT3_A754ModuloId[0];
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(1) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Controle de Rotas", "");
         A749ModuloAtivo = false;
         A750ModuloLine = 1;
         /* Using cursor P00HT4 */
         pr_default.execute(2, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT4_A754ModuloId[0];
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(2) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Gestão de Documentos", "");
         A749ModuloAtivo = true;
         A750ModuloLine = 1;
         /* Using cursor P00HT5 */
         pr_default.execute(3, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT5_A754ModuloId[0];
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(3) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Gestão de Contratos", "");
         A749ModuloAtivo = true;
         A750ModuloLine = 1;
         /* Using cursor P00HT6 */
         pr_default.execute(4, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT6_A754ModuloId[0];
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(4) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Modulo

         */
         A748ModuloNome = context.GetMessage( "Manutenção de Ponto", "");
         A749ModuloAtivo = true;
         A750ModuloLine = 1;
         /* Using cursor P00HT7 */
         pr_default.execute(5, new Object[] {A748ModuloNome, A749ModuloAtivo, A750ModuloLine});
         A754ModuloId = P00HT7_A754ModuloId[0];
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("Modulo");
         if ( (pr_default.getStatus(5) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /* Using cursor P00HT8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A754ModuloId = P00HT8_A754ModuloId[0];
            A748ModuloNome = P00HT8_A748ModuloNome[0];
            if ( StringUtil.StrCmp(A748ModuloNome, context.GetMessage( "Gestão de Serviços", "")) == 0 )
            {
               AV8ModuloRotinaId = 0;
               new prcpegaidmodulorotina(context ).execute(  A754ModuloId, out  AV8ModuloRotinaId) ;
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Dashboard", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT9 */
               pr_default.execute(7, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(7) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Cadastros", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT10 */
               pr_default.execute(8, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(8);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(8) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Ordem de Serviço", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT11 */
               pr_default.execute(9, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(9);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(9) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Agenda Técnica", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT12 */
               pr_default.execute(10, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(10);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(10) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Faturamento", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT13 */
               pr_default.execute(11, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(11);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(11) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Catálogo de Serviços", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT14 */
               pr_default.execute(12, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(12);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(12) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Manutenções Preventivas", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT15 */
               pr_default.execute(13, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(13);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(13) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Serviços Preventivos", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT16 */
               pr_default.execute(14, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(14);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(14) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Relatórios", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT17 */
               pr_default.execute(15, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(15);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(15) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor P00HT18 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            A754ModuloId = P00HT18_A754ModuloId[0];
            A748ModuloNome = P00HT18_A748ModuloNome[0];
            if ( StringUtil.StrCmp(A748ModuloNome, context.GetMessage( "Gestão de Documentos", "")) == 0 )
            {
               AV8ModuloRotinaId = 0;
               new prcpegaidmodulorotina(context ).execute(  A754ModuloId, out  AV8ModuloRotinaId) ;
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Indicadores", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT19 */
               pr_default.execute(17, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(17);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(17) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Função", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT20 */
               pr_default.execute(18, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(18);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(18) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Áreas", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT21 */
               pr_default.execute(19, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(19);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(19) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Tipos de Documentos", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT22 */
               pr_default.execute(20, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(20);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(20) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Documentos", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT23 */
               pr_default.execute(21, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(21);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(21) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
            }
            pr_default.readNext(16);
         }
         pr_default.close(16);
         /* Using cursor P00HT24 */
         pr_default.execute(22);
         while ( (pr_default.getStatus(22) != 101) )
         {
            A754ModuloId = P00HT24_A754ModuloId[0];
            A748ModuloNome = P00HT24_A748ModuloNome[0];
            if ( StringUtil.StrCmp(A748ModuloNome, context.GetMessage( "Gestão de Contratos", "")) == 0 )
            {
               AV8ModuloRotinaId = 0;
               new prcpegaidmodulorotina(context ).execute(  A754ModuloId, out  AV8ModuloRotinaId) ;
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Indicadores", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT25 */
               pr_default.execute(23, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(23);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(23) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Cadastros", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT26 */
               pr_default.execute(24, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(24);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(24) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Orçamentos", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT27 */
               pr_default.execute(25, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(25);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(25) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Contratos", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT28 */
               pr_default.execute(26, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(26);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(26) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Medição", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT29 */
               pr_default.execute(27, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(27);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(27) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Fluxo Financeiro", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT30 */
               pr_default.execute(28, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(28);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(28) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
               AV8ModuloRotinaId = (long)(AV8ModuloRotinaId+1);
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Relatórios", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT31 */
               pr_default.execute(29, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(29);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(29) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
            }
            pr_default.readNext(22);
         }
         pr_default.close(22);
         /* Using cursor P00HT32 */
         pr_default.execute(30);
         while ( (pr_default.getStatus(30) != 101) )
         {
            A754ModuloId = P00HT32_A754ModuloId[0];
            A748ModuloNome = P00HT32_A748ModuloNome[0];
            if ( StringUtil.StrCmp(A748ModuloNome, context.GetMessage( "Manutenção de Ponto", "")) == 0 )
            {
               AV8ModuloRotinaId = 0;
               new prcpegaidmodulorotina(context ).execute(  A754ModuloId, out  AV8ModuloRotinaId) ;
               /*
                  INSERT RECORD ON TABLE ModuloRotina

               */
               W754ModuloId = A754ModuloId;
               A751ModuloRotinaId = AV8ModuloRotinaId;
               A752ModuloRotinaNome = context.GetMessage( "Ponto Eletrônico", "");
               A753ModuloRotinaAtivo = true;
               /* Using cursor P00HT33 */
               pr_default.execute(31, new Object[] {A754ModuloId, A751ModuloRotinaId, A752ModuloRotinaNome, A753ModuloRotinaAtivo});
               pr_default.close(31);
               pr_default.SmartCacheProvider.SetUpdated("ModuloRotina");
               if ( (pr_default.getStatus(31) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A754ModuloId = W754ModuloId;
               /* End Insert */
            }
            pr_default.readNext(30);
         }
         pr_default.close(30);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("cargamodulos",pr_default);
         CloseCursors();
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
         A748ModuloNome = "";
         P00HT2_A754ModuloId = new long[1] ;
         Gx_emsg = "";
         P00HT3_A754ModuloId = new long[1] ;
         P00HT4_A754ModuloId = new long[1] ;
         P00HT5_A754ModuloId = new long[1] ;
         P00HT6_A754ModuloId = new long[1] ;
         P00HT7_A754ModuloId = new long[1] ;
         P00HT8_A754ModuloId = new long[1] ;
         P00HT8_A748ModuloNome = new string[] {""} ;
         A752ModuloRotinaNome = "";
         P00HT18_A754ModuloId = new long[1] ;
         P00HT18_A748ModuloNome = new string[] {""} ;
         P00HT24_A754ModuloId = new long[1] ;
         P00HT24_A748ModuloNome = new string[] {""} ;
         P00HT32_A754ModuloId = new long[1] ;
         P00HT32_A748ModuloNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acargamodulos__default(),
            new Object[][] {
                new Object[] {
               P00HT2_A754ModuloId
               }
               , new Object[] {
               P00HT3_A754ModuloId
               }
               , new Object[] {
               P00HT4_A754ModuloId
               }
               , new Object[] {
               P00HT5_A754ModuloId
               }
               , new Object[] {
               P00HT6_A754ModuloId
               }
               , new Object[] {
               P00HT7_A754ModuloId
               }
               , new Object[] {
               P00HT8_A754ModuloId, P00HT8_A748ModuloNome
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00HT18_A754ModuloId, P00HT18_A748ModuloNome
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00HT24_A754ModuloId, P00HT24_A748ModuloNome
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00HT32_A754ModuloId, P00HT32_A748ModuloNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A750ModuloLine ;
      private int GX_INS108 ;
      private int GX_INS109 ;
      private long A754ModuloId ;
      private long AV8ModuloRotinaId ;
      private long W754ModuloId ;
      private long A751ModuloRotinaId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A748ModuloNome ;
      private string Gx_emsg ;
      private string A752ModuloRotinaNome ;
      private bool entryPointCalled ;
      private bool A749ModuloAtivo ;
      private bool A753ModuloRotinaAtivo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00HT2_A754ModuloId ;
      private long[] P00HT3_A754ModuloId ;
      private long[] P00HT4_A754ModuloId ;
      private long[] P00HT5_A754ModuloId ;
      private long[] P00HT6_A754ModuloId ;
      private long[] P00HT7_A754ModuloId ;
      private long[] P00HT8_A754ModuloId ;
      private string[] P00HT8_A748ModuloNome ;
      private long[] P00HT18_A754ModuloId ;
      private string[] P00HT18_A748ModuloNome ;
      private long[] P00HT24_A754ModuloId ;
      private string[] P00HT24_A748ModuloNome ;
      private long[] P00HT32_A754ModuloId ;
      private string[] P00HT32_A748ModuloNome ;
   }

   public class acargamodulos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new UpdateCursor(def[31])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00HT2;
          prmP00HT2 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT3;
          prmP00HT3 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT4;
          prmP00HT4 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT5;
          prmP00HT5 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT6;
          prmP00HT6 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT7;
          prmP00HT7 = new Object[] {
          new ParDef("@ModuloNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloAtivo",GXType.Boolean,4,0) ,
          new ParDef("@ModuloLine",GXType.Int16,4,0)
          };
          Object[] prmP00HT8;
          prmP00HT8 = new Object[] {
          };
          Object[] prmP00HT9;
          prmP00HT9 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT10;
          prmP00HT10 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT11;
          prmP00HT11 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT12;
          prmP00HT12 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT13;
          prmP00HT13 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT14;
          prmP00HT14 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT15;
          prmP00HT15 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT16;
          prmP00HT16 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT17;
          prmP00HT17 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT18;
          prmP00HT18 = new Object[] {
          };
          Object[] prmP00HT19;
          prmP00HT19 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT20;
          prmP00HT20 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT21;
          prmP00HT21 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT22;
          prmP00HT22 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT23;
          prmP00HT23 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT24;
          prmP00HT24 = new Object[] {
          };
          Object[] prmP00HT25;
          prmP00HT25 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT26;
          prmP00HT26 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT27;
          prmP00HT27 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT28;
          prmP00HT28 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT29;
          prmP00HT29 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT30;
          prmP00HT30 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT31;
          prmP00HT31 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          Object[] prmP00HT32;
          prmP00HT32 = new Object[] {
          };
          Object[] prmP00HT33;
          prmP00HT33 = new Object[] {
          new ParDef("@ModuloId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaId",GXType.Decimal,18,0) ,
          new ParDef("@ModuloRotinaNome",GXType.NChar,60,0) ,
          new ParDef("@ModuloRotinaAtivo",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HT2", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT3", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT4", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT5", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT6", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT7", "INSERT INTO [Modulo]([ModuloNome], [ModuloAtivo], [ModuloLine]) VALUES(@ModuloNome, @ModuloAtivo, @ModuloLine); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00HT7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HT8", "SELECT [ModuloId], [ModuloNome] FROM [Modulo] ORDER BY [ModuloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HT8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00HT9", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT9)
             ,new CursorDef("P00HT10", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT10)
             ,new CursorDef("P00HT11", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT11)
             ,new CursorDef("P00HT12", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT12)
             ,new CursorDef("P00HT13", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT13)
             ,new CursorDef("P00HT14", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT14)
             ,new CursorDef("P00HT15", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT15)
             ,new CursorDef("P00HT16", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT16)
             ,new CursorDef("P00HT17", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT17)
             ,new CursorDef("P00HT18", "SELECT [ModuloId], [ModuloNome] FROM [Modulo] ORDER BY [ModuloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HT18,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00HT19", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT19)
             ,new CursorDef("P00HT20", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT20)
             ,new CursorDef("P00HT21", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT21)
             ,new CursorDef("P00HT22", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT22)
             ,new CursorDef("P00HT23", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT23)
             ,new CursorDef("P00HT24", "SELECT [ModuloId], [ModuloNome] FROM [Modulo] ORDER BY [ModuloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HT24,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00HT25", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT25)
             ,new CursorDef("P00HT26", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT26)
             ,new CursorDef("P00HT27", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT27)
             ,new CursorDef("P00HT28", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT28)
             ,new CursorDef("P00HT29", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT29)
             ,new CursorDef("P00HT30", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT30)
             ,new CursorDef("P00HT31", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT31)
             ,new CursorDef("P00HT32", "SELECT [ModuloId], [ModuloNome] FROM [Modulo] ORDER BY [ModuloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HT32,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00HT33", "INSERT INTO [ModuloRotina]([ModuloId], [ModuloRotinaId], [ModuloRotinaNome], [ModuloRotinaAtivo]) VALUES(@ModuloId, @ModuloRotinaId, @ModuloRotinaNome, @ModuloRotinaAtivo)", GxErrorMask.GX_NOMASK,prmP00HT33)
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
             case 22 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 60);
                return;
       }
    }

 }

}
