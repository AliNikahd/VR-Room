using UnityEngine;
using System.IO.Ports;

public class TestSerial : MonoBehaviour
{
    [Header("Serial Port Settings")]
    public string entryPort = "COM9";
    public int baudRate = 112500;

    private SerialPort dataStream;

    private void Start()
    {
        // Initialize the serial port
        dataStream = new SerialPort(entryPort, baudRate);

        try
        {
            dataStream.Open();
            dataStream.ReadTimeout = 50;  // optional: helps avoid blocking
            Debug.Log("Opened port " + entryPort + " at baud " + baudRate);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    private void Update()
    {
        // If user presses Space bar, send a serial message
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendSerial("SpacePressed");
        }
    }

    // Method for sending a message out over serial
    public void SendSerial(string message)
    {
        if (dataStream != null && dataStream.IsOpen)
        {
            dataStream.WriteLine(message);
            dataStream.BaseStream.Flush(); // Ensures data is sent immediately
            Debug.Log("Sent to serial: " + message);
        }
        else
        {
            Debug.LogWarning("Serial Port not open or invalid.");
        }
    }

    // Optional method for UI buttons
    public void OnMyButtonClicked()
    {
        SendSerial("ButtonClicked");
    }

    private void OnApplicationQuit()
    {
        // Clean up the port when the app quits
        if (dataStream != null && dataStream.IsOpen)
        {
            dataStream.Close();
            Debug.Log("Closed serial port.");
        }
    }
}
