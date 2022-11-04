using SmartphoneSimulator.Models;

Iphone iphone = new Iphone("9988547885", "Iphone 12", "88888-00-000000-8.", 128);

iphone.Call();
iphone.ReceiveCall();
iphone.InstallApp("WhatsApp");

Nokia nokia = new Nokia("888484898","Nokia Lumia 520","000000-88-888888-0.",64);

nokia.Call();
nokia.ReceiveCall();
nokia.InstallApp("Facebook");