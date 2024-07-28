using System;
using System.Security.Cryptography;
using System.Text;

public static class Crypter
{
    //new RSACryptoServiceProvider().ToXmlString(true) - get new private key
    private static string key = "<RSAKeyValue><Modulus>uVYUst/+50fR41eYQ+OYu4lCRGvWxVr+KAZvTr6Q5xEFcaEVCgnCiDWGHlrvjkHdl8wNyiJ6OqYP2Ii/Yxd8qiBbFt8KK4HyVFawSSk+WE2wN6sgx8fRHYq6QG0/9OMewS8TqN/h1Xze1Pwx/dGHE8S7UU29p3M3x3x1u7FPb20=</Modulus><Exponent>AQAB</Exponent><P>8EuqPYrECVItL6sZvquVB1mQ9k3wSbwGy80jyQfwLD+lN9wakJC7a9Zp/vPENxCvC0YcNqDf2WZkpaQZXmv98w==</P><Q>xXLnLkTQ2BiayM61iiiQR5gH1F6QRBcZ32ezI2aGltgwavjlvZ4DfUWFXcCCC7azN+4i41vlZkOYkLfSNe5VHw==</Q><DP>vuoO7uhiSlmM5xOU18VxGS7TGq3fnGWULLXmmaEB89X5SYFJZdRn5AytmE9KdMl/mYBxiAGW+B3/Fw9izH8Wew==</DP><DQ>RjaDARAVmBK/0BK5ucSM8fidKCbsdFomqCwPJtKJn9CG/zM9Nz2ejgiP0XPoitPQTV5QZ7tBCymUcjn79ZOoDw==</DQ><InverseQ>aIlFaLrjYUvqLrTcvPv6lkwVAAOeNSrMARxkVdoYpEve7Ku+M6moU5r+pWFFXQjmWbOMyea8usIjwdR3KTQs9Q==</InverseQ><D>Ko1oDTW+qc1klET9UcEExTIbg+galI9ywS/RCIxaaqMO0+r/EKHzByD63SdVzxyySvLvy5Qk6ihMhRPIlXDED0sDCuTM896BoKnU6iCrYW/5xjKUn/HhrdiIIhQQhVvHGvfFPyDMtIdSfTQkQivFOXUa1QQK6iSaDnIP5Sdw44U=</D></RSAKeyValue>";

    public static string Decrypt(string text)
    {
        byte[] decrContent = null;

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(key);
        decrContent = rsa.Decrypt(Convert.FromBase64String(text), true);

        return ToString(decrContent);
    }

    private static string ToString(byte[] decrContent) => Encoding.UTF8.GetString(decrContent);
    private static byte[] ToByte(string text) => Encoding.UTF8.GetBytes(text);

    public static string Encrypt(string text)
    {
        byte[] encContent = null;

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(key);
        encContent = rsa.Encrypt(ToByte(text), true);

        return Convert.ToBase64String(encContent);
    }
}