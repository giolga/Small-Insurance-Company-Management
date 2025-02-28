# Small-Insurance-Company-Management
პროექტის დანიშნულება:  მცირე სადაზღვევო კომპანიის მართვის პროგრამა 
პროექტის მოკლე აღწერა: სადაზღვევო კომპანიას ყავს ავტორიზებული მომხმარებელი 
(უმცროსი სადაზღვევო მრჩეველი, უფროსი სადაზღვევო მრჩეველი, მენეჯერი). მენეჯერს 
უნდა შეეძლოს ახალი სადაზღვევო პროდუქტის დარეგისტრირება სისტემაში. სისტემას 
გააჩნია მხოლოდ სამი კატეგორიის პროდუქტი: ჯანმრთელობის დაზღვევა, სამოგზაურო 
დაზღვევა, ავტომობილის დაზღვევა. დასაშვებია მხოლოდ ორი სახის ოპერაცია: 
სადაზღვევო პროდუქტის გაყიდვა და სადაზღვევო ლიმიტის გაზრდა/შემცირება (პაკეტის 
ცვლილება).  
მოცემული დავალების ფარგლებში შესასრულებები ამოცანები: 
1. 
შექმენით სადაზღვევო პროდუქტების მართვის ვებ-სერვისი (გამოიყენეთ 
ASP.NET WEB API ტექნოლოგია) შემდეგი ფუნქციებით: 
➢ სადაზღვევო პროდუქტის დამატება; 
➢ სადაზღვევო პროდუქტის რედაქტირება; 
➢ სადაზღვევო პროდუქტის გაყიდვა; 
➢ შეძენილი სადაზღვევო პროდუქტის ლიმიტის გაზრდა/შემცირება (პაკეტის 
ცვლილება); 
➢ სადაზღვევო პაკეტის შესახებ სრული ინფორმაციის მიღება უნიკალური 
იდენტიფიკატორის მეშვეობით; 
სადაზღვევო პროდუქტის მოდელზე გაითვალისწინეთ შემდეგი ვალიდაციები: 
• უნიკალური იდენტიფიკატორი (ავტომატურად გენერირებული, დადებითი 
მთელი რიცხვი) 
• დასახელება (ტექსტური, სავალდებულო, მინიმუმ 15 და მაქსიმუმ 50 
სიმბოლო) 
• კატეგორია (იდენტიფიკატორი ცნობარიდან, დასაშვები მნიშვნელობები: 
ჯანმრთელობის დაზღვევა, სამოგზაურო დაზღვევა, ავტომობილის 
დაზღვევა) 
• ტიპი (იდენტიფიკატორი ცნობარიდან, დასაშვები მნიშვნელობები: 
სილვერი, გოლდი, პლატინიუმი) 
• სახეობა (იდენტიფიკატორი ცნობარიდან, დასაშვები მნიშვნელობები: 
ოჯახური, ინდივიდუალური, კორპორატიული) 
• სადაზღვევო პრემია (ავტომატურად გამოთვლადი თანხობრივი ველი. 
დამოკიდებულია როგორც სადაზღვევო პროდუქტის კატეგორიასა და 
ტიპზე, ასევე სადაზღვევო პროდუქტის სახეობაზე. მაგალითად, 
ჯანმრთელობის დაზღვევა „გოლდი“ ოჯახური შეიძლება ღირდეს თვეში 100 
ლარი) 
• მომსახურების პირობების სრული აღწერა (ტექსტური, მინიმუმ 1000 
სიმბოლო) 
მოცემული ამოცანის ფარგლებში სადაზღვევო პროდუქტებისა და მომხმარებლების 
ცხრილებს შორის არსებობს კავშირი ბევრი - ბევრთან, რაც ნიშნავს იმას, რომ ერთ 
პროდუქტს შეიძლება ყავდეს რამდენიმე მფლობელი და ერთ მომხმარებელს 
შეიძლება ქონდეს რამდენიმე სადაზღვევო პროდუქტი შეძენილი. ეს პირობა 
აუცილებლად გასათვალისწინებელია ბაზის მოდელის აგების დროს. 
2. 
ვებ-სერვისის დეველოპმენტისას ყურადღება მიაქციეთ შემდეგ საკითხებს: 
➢ ყველა ოპერაციის შესრულების დროს გათვალისწინებული უნდა იყოს 
ვალიდაციები და შეცდომების მართვა; 
➢ მონაცემები უნდა ინახებოდეს მონაცემთა ბაზაში (MS SQL).  
➢ გამოიყენეთ EF Code First მიდგომა. 
➢ CRUD ოპერაციები შესაბამის Action-მეთოდებში. Action-მეთოდების 
დასაბრუნებელ მნიშვნელობებად გამოიყენეთ სხვადასხვა ტიპი და 
კომენტარების სახით ახსენით. 
➢ სასურველია Repository და Unit of work პატერნების გამოყენება. 
➢ Request/Response Data Format-ი JSON; 
