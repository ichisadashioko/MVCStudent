
using System.Collections.Generic;

namespace StudentLib.Models
{

    public enum Province
    {
        Foreign,
        BacGiang,
        BacKan,
        CaoBang,
        HaGiang,
        LangSon,
        PhuTho,
        QuangNinh,
        ThaiNguyen,
        TuyenQuang,
        LaoCai,
        YenBai,
        DienBien,
        HoaBinh,
        LaiChau,
        SonLa,
        BacNinh,
        HaNam,
        HaiDuong,
        HungYen,
        NamDinh,
        NinhBinh,
        ThaiBinh,
        VinhPhuc,
        HaNoi,
        HaiPhong,
        HaTinh,
        NgheAn,
        QuangBinh,
        QuangTri,
        ThanhHoa,
        ThuaThienHue,
        DakLak,
        DakNong,
        GiaLai,
        KonTum,
        LamDong,
        BinhDinh,
        BinhThuan,
        KhanhHoa,
        NinhThuan,
        PhuYen,
        QuangNam,
        QuangNgai,
        DaNang,
        BaRiaVungTau,
        BinhDuong,
        BinhPhuoc,
        DongNai,
        TayNinh,
        HoChiMinh,
        AnGiang,
        BacLieu,
        BenTre,
        CaMau,
        DongThap,
        HauGiang,
        KienGiang,
        LongAn,
        SocTrang,
        TienGiang,
        TraVinh,
        VinhLong,
        CanTho,
    }

    public static class ProvinceExtension
    {
        private static readonly List<Province> MountainousProvinces = new List<Province>()
        {
            Province.BacGiang,
            Province.BacKan,
            Province.CaoBang,
            Province.HaGiang,
            Province.LangSon,
            Province.PhuTho,
            Province.QuangNinh,
            Province.ThaiNguyen,
            Province.TuyenQuang,
            Province.LaoCai,
            Province.YenBai,
            Province.DienBien,
            Province.HoaBinh,
            Province.LaiChau,
            Province.SonLa,
            Province.DakLak,
            Province.DakNong,
            Province.GiaLai,
            Province.KonTum,
            Province.LamDong,
        };
        public static bool IsMountainous(this Province province)
        {
            return MountainousProvinces.Contains(province);
        }
    }
}