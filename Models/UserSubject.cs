namespace test_4.Models;

public class UserSubject
{
   
        public UserSubject() {}
        public UserSubject(string userName, string name)
        {
                UserName = userName;
                Name = name;
        }

    

        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }
  
       
 

    
}