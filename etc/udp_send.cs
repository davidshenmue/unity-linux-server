 using UnityEngine;
 using System.Collections;
 using System;
 using System.Text;
 using System.Net;
 using System.Net.Sockets;
 using System.Threading;
 
 public class udp_send : MonoBehaviour
 {
     public string IP = "192.168.56.101"; // default local
     public int port = 33333;  
     IPEndPoint remoteEndPoint;
     UdpClient client;
     string strMessage="";
     
     public void Start()
     {
         init();   
     }
     
     void OnGUI()
     {
         Rect rectObj=new Rect(40,380,200,400);
         GUIStyle style = new GUIStyle();
         style.alignment = TextAnchor.UpperLeft;
         GUI.Box(rectObj,"udp_sendData\n IP : "+IP+" Port : "+port,style);
         //
         strMessage=GUI.TextField(new Rect(40,420,140,20),strMessage);
         if (GUI.Button(new Rect(190,420,40,20),"Send"))
         {
             sendString(strMessage+"\n");
         }      
     }
     
     // init
     public void init()
     {
         IP="192.168.56.101";
         port=33333; // quake port ;)
         remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
         //remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, port); // toute machine
         client = new UdpClient();
     }
     
     // sendData
     private void sendString(string message)
     {
         try 
         {
             byte[] data = Encoding.UTF8.GetBytes(message);
             client.Send(data, data.Length, remoteEndPoint);
         }
         catch (Exception err)
         {
             print(err.ToString());
         }
     }
     
     void OnDisable()
     {
         if ( client!= null)   client.Close();
     }
 }
