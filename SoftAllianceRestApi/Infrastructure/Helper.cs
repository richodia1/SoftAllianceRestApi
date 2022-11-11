using System.Text;

namespace SoftAllianceRestApi.Infrastructure
{
    public static class Helper
    {
        public static string GetBase64from(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }
    }
}
