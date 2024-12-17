﻿using System.Net;
using System.Text;

namespace FoodWebMVC.Models;

internal class PaymentRequest
{
	public static string sendPaymentRequest(string endpoint, string postJsonString)
	{
		try
		{
			var httpWReq = (HttpWebRequest)WebRequest.Create(endpoint);

			var postData = postJsonString;

			var data = Encoding.UTF8.GetBytes(postData);

			httpWReq.ProtocolVersion = HttpVersion.Version11;
			httpWReq.Method = "POST";
			httpWReq.ContentType = "application/json";

			httpWReq.ContentLength = data.Length;
			httpWReq.ReadWriteTimeout = 30000;
			httpWReq.Timeout = 15000;
			var stream = httpWReq.GetRequestStream();
			stream.Write(data, 0, data.Length);
			stream.Close();

			var response = (HttpWebResponse)httpWReq.GetResponse();

			var jsonresponse = "";

			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				string temp = null;
				while ((temp = reader.ReadLine()) != null) jsonresponse += temp;
			}


			//todo parse it
			return jsonresponse;
			//return new MomoResponse(mtid, jsonresponse);
		}
		catch (WebException e)
		{
			return e.Message;
		}
	}
}