using System;
namespace labs4_6
{
    interface ICaptain
    {
        string CaptainName { get; set; }
        uint CaptainAge { get; set; }
        void OneNameMethod();
    }
}
