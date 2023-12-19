
// Create and initialize a new trigger to configure it.
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;

BluetoothLEAdvertisementPublisher publisher = new BluetoothLEAdvertisementPublisher();

// We need to add some payload to the advertisement. A publisher without any payload
// or with invalid ones cannot be started. We only need to configure the payload once
// for any publisher.

// Add a manufacturer-specific section:
// First, create a manufacturer data section
var manufacturerData = new BluetoothLEManufacturerData();

// Then, set the company ID for the manufacturer data. Here we picked an unused value: 0xFFFE
manufacturerData.CompanyId = 0xFFF0;

// Finally set the data payload within the manufacturer-specific section
// Here, use a 16-bit UUID: 0x1234 -> {0x34, 0x12} (little-endian)
var writer = new DataWriter();
writer.WriteByte(0x6D);
writer.WriteByte(0xB6);
writer.WriteByte(0x43);
writer.WriteByte(0xCE);
writer.WriteByte(0x97);
writer.WriteByte(0xFE);
writer.WriteByte(0x42);
writer.WriteByte(0x7C);
// dynamic bit
writer.WriteByte(0xF5);
writer.WriteByte(0x94);
writer.WriteByte(0x6D);

// Make sure that the buffer length can fit within an advertisement payload. Otherwise you will get an exception.
manufacturerData.Data = writer.DetachBuffer();

// Add the manufacturer data to the advertisement publisher:
publisher.Advertisement.ManufacturerData.Add(manufacturerData);

// Extended advertisements are BT5 only stuff: doesn't work with CSR4s
//publisher.UseExtendedAdvertisement = true;

// Set the required flags (not entirely sure how these flag map to what we need)
// Disabled as this will cause a runtime exception
//publisher.Advertisement.Flags = BluetoothLEAdvertisementFlags.GeneralDiscoverableMode;

publisher.Start();

// Display the current status of the publisher
Console.WriteLine($"Published Status: {publisher.Status}, Error: {BluetoothError.Success}");

Thread.Sleep(60000);