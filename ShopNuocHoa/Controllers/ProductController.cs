
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopNuocHoa.Models;

namespace ShopNuocHoa.Controllers
{
    public class ProductController : Controller
    {
        SanPhamModels db = new SanPhamModels();
        LoaiSPModels lspModel = new LoaiSPModels();
        // GET: Product
        public ViewResult ProDetail(string id)
        {

            SanPham sp = db.get1sanPham(id);
            ViewBag.LoaiSP = lspModel.get1LSP(sp.maLoai);
            return View(sp);
        }
        public ViewResult ProCata(string id)
        {
            LoaiSP lsp;
            SanPhamModels db = new SanPhamModels();
            List<SanPham> listSp;
            List<LoaiSP> list = lspModel.getAllLSP();
            if (id == null)
            {
             
                listSp = db.getAllSP();
                ViewBag.tenLoai = "Tất cả sản phẩm";
            }
            else
            {
                lsp = lspModel.get1LSP(id);
                listSp  = db.getSanPhambyLoai(id);
                var tenlsp = lsp.tenLoai;
                ViewBag.LoaiSP = lsp;
                ViewBag.tenLoai = tenlsp;
            }
            //lay ra ten loai sp
           
          
            return View(listSp);
        }
    }
}