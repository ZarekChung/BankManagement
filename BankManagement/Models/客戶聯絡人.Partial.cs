using System.Linq;

namespace BankManagement.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	
	[MetadataType(typeof(客戶聯絡人MetaData))]
	public partial class 客戶聯絡人 :IValidatableObject
	{
		private CustomerDataEntities db = new CustomerDataEntities();
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var data = from p in db.客戶聯絡人
				where (p.Email == this.Email & p.姓名  == this.姓名)
				select p.Id;
			if(data.Count()>1)
				yield return new ValidationResult("此Email於此客戶已被註冊,請輸入其他Email");
		}
	}

	
	public partial class 客戶聯絡人MetaData
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public int 客戶Id { get; set; }
		
		[StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
		[Required]
		public string 職稱 { get; set; }
		
		[StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
		[Required]
		public string 姓名 { get; set; }
		
		[StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		
		[StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
		[Required]
		[RegularExpression(@"\d{4}-\d{6}" ,ErrorMessage = "格式必須為092X-XXXXXX")]
		public string 手機 { get; set; }
		
		[StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
		public string 電話 { get; set; }
	
		public virtual 客戶資料 客戶資料 { get; set; }
	}
}
