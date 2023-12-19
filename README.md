# GattAdvertisementTest

This is a quick test to see if the Bluetooth Advertisement features exposed by the Windows SDK can be used to control MuSe/LoveSpouce/etc devices

## Conclusion

Nope.

Whilst it is possible to craft and publish the manufacturer data required, the SDK prevents you from changing the flags required to get the devices to read the advertisement as a command.

This is explicitly called out in https://learn.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher.advertisement?view=winrt-22621#windows-devices-bluetooth-advertisement-bluetoothleadvertisementpublisher-advertisement:
```
When configuring the publisher object, you can't add restricted section types (BluetoothLEAdvertisementPublisher.Advertisement.Flags and BluetoothLEAdvertisementPublisher.Advertisement.LocalName). Trying to set those property values results in a runtime exception. You can still set the manufacturer data section, or any other sections not defined by the list of restrictions.
```
