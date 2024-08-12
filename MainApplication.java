package com.artech.igestorappdespesas.appdespesas;
import android.content.Context;
import androidx.multidex.MultiDex;

import com.artech.base.services.AndroidContext;
import com.artech.base.services.IGxProcedure;

import com.genexus.android.ContextImpl;
import com.genexus.android.core.application.MyApplication;
import com.genexus.android.core.base.metadata.GenexusApplication;
import com.genexus.android.core.base.services.Services;
import com.genexus.android.core.providers.EntityDataProvider;

import com.genexus.Application;
import com.genexus.ClientContext;

public class MainApplication extends MyApplication
{
	@Override
	public final void onCreate()
	{
		GenexusApplication application = new GenexusApplication();
		application.setName("igestorappdespesas");
		application.setApiUri("https://k924iiwnek.execute-api.sa-east-1.amazonaws.com/v1/");
		application.setAppEntry("AppDespesas");
		application.setMajorVersion(1);
		application.setMinorVersion(3);

		// Extensibility Point for Logging
 

		// Security
		application.setSecure(true);
		application.setEnableAnonymousUser(false);
		application.setClientId("577419518e3f4281835d91b925e6fa83");
		application.setLoginObject("LoginSD");
		application.setNotAuthorizedObject("GAMSDNotAuthorized");
		application.setChangePasswordObject("GAMSDChangePassword");
		//application.setCompleteUserDataObject("");

		application.setAllowWebViewExecuteJavascripts(true);
		application.setAllowWebViewExecuteLocalFiles(true);

		application.setShareSessionToWebView(false);

		// Dynamic Url		
		application.setUseDynamicUrl(false);
		application.setDynamicUrlAppId("iGestorAppDespesas");
		application.setDynamicUrlPanel("");

		// Notifications
		application.setUseNotification(false);
		application.setNotificationSenderId("");
		application.setNotificationRegistrationHandler("(none)");

		setApp(application);

		registerModule(new com.genexus.android.ui.animation.AnimationModule());

		registerModule(new com.genexus.android.core.externalobjects.CoreExternalObjectsModule());

		registerModule(new com.genexus.android.core.usercontrols.CoreUserControlsModule());

		registerModule(new com.genexus.android.controls.filepicker.FilePickerModule());

		registerModule(new com.genexus.android.controls.maps.google.GoogleMapsModule());

		registerModule(new com.genexus.android.location.LocationModule());

		registerModule(new com.genexus.android.qrscanner.QRScannerModule());

		registerModule(new com.genexus.android.controls.grids.smart.SmartGridModule());

		registerModule(new com.genexus.android.controls.ViewPagersModule());

		registerModule(new com.workwithplus.WorkWithPlusModule());


	

		super.onCreate();

		

    }

	@Override
	public Class<? extends com.genexus.android.core.services.EntityService> getEntityServiceClass()
	{
		return AppEntityService.class;
	}

	@Override
	public EntityDataProvider getProvider()
	{
		return new AppEntityDataProvider();
	}

	@Override
	protected void attachBaseContext(Context base)
	{
		super.attachBaseContext(base);
		MultiDex.install(this);
	}

}
