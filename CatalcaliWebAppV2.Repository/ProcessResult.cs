using CatalcaliWebAppV2.Entities;

using System.Collections.Generic;


namespace CatalcaliWebAppV2.Repository
{
    public class ProcessResult<T>
    {
        public Result<int> GetResult(DataContext db)
        {
            Result<int> result = new Result<int>();
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                result.Message = "İşlem Tamamlandı";
                result.IsCompleted = true;
                result.ProccesResult = sonuc;
            }
            else
            {
                result.Message = "İşlem Tamamlanamadı";
                result.IsCompleted = false;
                result.ProccesResult = sonuc;
            }
            return result;
        }
        public Result<List<T>> GetList(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data != null)
            {
                result.Message = "İşlem Tamamlandı";
                result.IsCompleted = true;
                result.ProccesResult = data;
            }
            else
            {
                result.Message = "İşlem Tamamlanamadı";
                result.IsCompleted = false;
                result.ProccesResult = data;
            }
            return result;
        }
        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data != null)
            {
                result.Message = "İşlem Tamamlandı";
                result.IsCompleted = true;
                result.ProccesResult = data;
            }
            else
            {
                result.Message = "İşlem Tamamlanamadı";
                result.IsCompleted = false;
                result.ProccesResult = data;
            }
            return result;
        }
    }
}
