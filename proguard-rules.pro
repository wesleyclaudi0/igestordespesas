# Add project specific ProGuard rules here.
# By default, the flags in this file are appended to flags specified
# in C:\Develop\Tools\android-sdk/tools/proguard/proguard-android.txt
# You can edit the include path and order by changing the proguardFiles
# directive in build.gradle.
#
# For more details, see
#   http://developer.android.com/guide/developing/tools/proguard.html

# Keep all public methods and fields for these classes

# Keep all External Object implementations
-keep public class * extends com.genexus.android.core.externalapi.ExternalApi {
    *;
}

# Keep client information for offline
-keep class  com.genexus.android.device.ClientInformation { *; }


-dontnote com.genexus.xml.GXXMLSerializable
-dontnote com.android.vending.licensing.ILicensingService

# Classes for offline apps with encrypt database. keep sqlcipher
-keep class net.sqlcipher.** {
    *;
}

-keep class net.sqlcipher.database.** {
    *;
}

# Classes for sync api offline
-keep class com.genexuscore.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem {
    *;
}

# Temporary until include PDFReportItext in another jar with reference to itextpdf 
-dontwarn com.genexus.reports.PDFReportItext

# Otherwise android.util.Xml.asAttributeSet would not be found (needed by MenuInflater.inflate)
-keep class org.xmlpull.v1.** { *; }

# For getLocation to work in offline code
-keep class org.apache.xerces.impl.dv.ObjectFactory { *; }
-keep class org.apache.xerces.impl.dv.dtd.DTDDVFactoryImpl { *; }

# Flex Grid doesn't work otherwise as its constructor is invoked through reflection
-keepclassmembers class * extends com.genexus.android.controls.grids.flex.GxFlexLayout {
    public protected <init>(...);
}

# These classes throw R8 warnings after migrating to API 34 although they come from offline standard Java classes
-dontwarn org.locationtech.jts.geom.impl.CoordinateArraySequenceFactory
-dontwarn org.locationtech.jts.geom.PrecisionModel
-dontwarn org.locationtech.jts.geom.CoordinateSequenceFactory
