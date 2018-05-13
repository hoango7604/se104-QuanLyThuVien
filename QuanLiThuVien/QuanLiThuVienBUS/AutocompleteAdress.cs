using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.NetworkInformation;


namespace QuanLiThuVienBUS
{
    public class AutocompleteAdress
    {
        public bool isConnected= false;
     
        public AutocompleteAdress()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                isConnected = true;
            }
            else
                isConnected = false;
        }   
     
       /// <summary>
       /// Tìm kiếm địa chỉ thông qua chuỗi tìm kiếm
       /// </summary>
       /// <param name="input">chuỗi địa chỉ tìm kiếm</param>
       /// <param name="DanhSachDiaChi">List kết quả trã về </param>
       /// <returns></returns>
        public bool TimKiemDiaChi(string input,ref List<string> DanhSachDiaChi)
        {
            DanhSachDiaChi = new List<string>();

            if (isConnected)
            {
                if (input.Length > 3)
                {
                    string HTTPstring = "https://maps.googleapis.com/maps/api/place/autocomplete/xml?input="+input+ "&types=geocode&language=vi&components=country:vn&key=" + System.Configuration.ConfigurationManager.AppSettings.Get("ApiKey");
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(HTTPstring);
                    XmlNode statusNode = xmlDoc.GetElementsByTagName("status")[0];
                    if (statusNode.InnerText== "ZERO_RESULTS")
                    {
                        BUS_notification.mess = "Không tồn tại địa chỉ :3 ";
                        return false;
                    }
                    foreach (XmlNode xmlPredictionNode in xmlDoc.GetElementsByTagName("prediction"))
                    {
                        foreach (XmlNode childNode in xmlPredictionNode)
                        {
                            if (childNode.Name == "description")
                            {
                                DanhSachDiaChi.Add(childNode.InnerText);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                BUS_notification.mess = "Không thể kết nối Internat. Xin vui lòng kiểm tra lại";
                return false;
            }
            return true;
        }
    }
}
