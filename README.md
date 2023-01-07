- [Implementation Ed448 And AES 256bitWith Digital Signature For Secure Electronic Health Record Application](#implementation-ed448-and-aes-256bitwith-digital-signature-for-secure-electronic-health-record-application)
  - [Tổng quan cơ sở lý thuyết](#tổng-quan-cơ-sở-lý-thuyết)
  - [Tổng quan công nghệ sử dụng](#tổng-quan-công-nghệ-sử-dụng)
  - [Tổng quan hệ thống](#tổng-quan-hệ-thống)
  - [Tổng quan giao diện hệ thống](#tổng-quan-giao-diện-hệ-thống)
  - [Kết luận](#kết-luận)

# Implementation Ed448 And AES 256bitWith Digital Signature For Secure Electronic Health Record Application

## Tổng quan cơ sở lý thuyết
- **1. Lý thuyết chữ ký số :**
    Việc dùng mã xác thực (MAC) có thể bảo vệ hai bên tham gia trong phiên giao tiếp với nhau khỏi sự xâm phạm của bên thứ ba. Tuy nhiên, biện pháp này không thể bảo vệ chính hai bên tham gia lẫn nhau. Ví dụ: A có thể tạo một thông điệp và tự tạo một mã xác thực dựa trên khoá chia sẻ giữa A và B, sau đó, A nói rằng tin nhắn này là do B gửi, B không có khả năng chứng minh điều này là sai. 
    Giải pháp để giải quyết vấn đề này là chữ ký số. Chữ ký số có khả năng:
    - Xác minh người ký và thời điểm ký
    - Xác thực thông điệp tại thời điểm ký
    - Có thể xác minh bởi bên thứ ba nhằm giải quyết trong trường hợp xảy ra tranh cãi giữa hai bên.

    Dưới đây là ảnh mô tả đơn giản quá trình tạo và giải mã chữ ký số:
    
    ![](https://i.imgur.com/Imq8tLp.png)

    Có hai kỹ thuật tạo chữ ký số: ký trực tiếp và ký qua bên thứ ba. Ở project này ta sẽ nói về những mô hình tạo chữ ký số theo kỹ thuật ký trực tiếp.
    - Ký trực tiếp (Direct Digital Signatrue): quá trình tạo chữ ký số và xác thực chỉ diễn ra giữa hai bên tham gia, đòi hỏi bên nhận phải biết public-key của bên gửi. Ảnh mô tả ở trên là về kỹ thuật này. Vấn đề cần quan tâm là sự bảo mật private-key của người gửi, cũng như cần phải có sự xác thực người ký để tránh trường hợp bị đánh cắp private-key, hoặc thoái thác trách nhiệm.

    Yêu cầu chữ ký số:
    - Chữ ký phải dựa vào thông điệp cần được ký.
    - Chữ ký phải chứa thông tin duy nhất của người gửi để tránh giả mạo và thoái thác.
    - Dễ dàng tạo chữ ký.
    - Dễ xác thực chữ ký.
    - Khó khăn giả mạo chữ ký.
    
    Đặc điểm chữ ký số:
    - Tính xác thực: bảo đảm người ký là người tạo ra nó.
    - Tính không thể thoái thác: người ký không thể phủ nhận thông tin đã ký.
    - Tính toàn vẹn: thông điệp không thể bị thay đổi, chỉnh sửa.
    - Tính không thể dùng lại: một chữ ký số không thể dùng cho một tìa liệu khác.
    - Tính an toàn: không thể giả mạo chữ ký nếu không biết thông tin bí mật tạo chữ ký.

- **2. Ed448**
    
    Ed448 là EdDSA signature scheme sử dụng SHA-3 và Curve448. Nó cũng đã được phê duyệt trong dự thảo của tiêu chuẩn FIPS    186-5. Một vài tham số quan trọng của Ed448 được liệt kê trong bảng sau

    ![](https://i.imgur.com/uj5foOR.png)

    - **Key Generation (for signer)**
        - Private key (privKey): là một số nguyên 57 bytes, được tạo bằng cách random
        - Public key (pubKey): pubKey = privKey*B
    - **Sign (message m)**
        - r = hash(hash(privKey) + m) mod L
        - R = r*B
        - h = hash(R = pubKey + m) mod L
        - S = (r + h*privKey) mod L
        --> Signature {R, S}
    - **Verify (message m, pubKey, signature {R, S})**
        - h = hash(R + pubKey + m) mod L
        - P1 = S*B
        - P2 = R + h*pubKey
        - Kiểm tra P1 == P2
        --> Trả về hợp lệ / không hợp lệ
        
- **3. AES-256**
    Advanced Encryption Standard ra đời năm 1997. Đến năm 2001, Rijndael được chọn làm chuẩn mới cho AES.
    Tất cả các phép toán của AES được thực hiện trên đơn vị 8-bit (1byte) và finite field GF(2^8).
    Cấu trúc cơ bản của AES-256:
    - AES là block cipher, với mỗi block là 128-bits
    - Key size: 256 bits
    - 14 rounds tính toán.
    - Mỗi block là một ma trận vuông 4x4, gọi là ma trận trạng thái
    
    **Tổng quát các bước mã hoá của AES:**
    - 1.KeyExpansion – 256-bits key sẽ được chia thành 8 words để tính toán 128-bits key cho 15 rounds (bao gồm cả initial round), sử dụng AES key schedule [5]. Mỗi key round là tách biệt nhau
    - 2.Initial round: Mỗi byte của ma trận trạng thái cộng với mỗi byte tương ứng của round key, sử dụng bitwise xor
    - 3. 13 round tiếp theo, thực hiện theo thứ tự các bước sau ở mỗi round:
        - SubBytes – bước này thay thế mỗi byte trong ma trận trạng thái bằng một byte khác dựa theo substitution box . 
        - ShiftRows – thực hiện shift left circular với 3 hàng cuối của ma trận đơn vị lần lượt với số byte cần shift là 1-byte, 2-byte, 3-byte.
        - MixColumns – mỗi byte của một column trong ma trận trạng thái sẽ được ánh xạ thành một giá trị khác tương ứng thông qua phép toán nhân ma trận.
        - AddRoundKey – mỗi byte của ma trận trạng thái cộng với mỗi byte tương ứng của round key, sử dụng bitwise xor.
    - 4.Round cuối cùng:
        - SubBytes
        - ShiftRows
        - AddRoundKey
- **X509**

    X.509 là một tiêu chuẩn của Liên minh Viễn thông Quốc Tế, viết tắt là ITU (Tiếng Anh: International Telecommunication Union) định dạng chuẩn cho chứng chỉ khóa công khai.
    Mỗi chứng chỉ chứa khóa công khai của người dùng và được ký bằng khóa riêng của tổ chức cấp chứng chỉ đáng tin cậy.
    X.509 là một tiêu chuẩn quan trọng vì cấu trúc chứng chỉ và các giao thức cation authenti được định nghĩa trong X.509 được sử dụng trong nhiều ngữ cảnh khác nhau.
    Định dạng của chứng chỉ, bao gồm các yếu tố sau đây:
    - Version: Phân biệt giữa các phiên bản của định dạng chứng chỉ.
    - Serial number: Một giá trị số nguyên duy nhất trong CA phát hành được liên kết rõ ràng với từng chứng chỉ.
    - Signature algorithm identifier: Thuật toán được sử dụng để ký chứng chỉ cùng với các tham số liên quan. Bởi vì thông tin này được lặp lại trong trường chữ ký ở cuối chứng chỉ nên trường này cũng ít cần thiết.
    - Issuer name: Tên của CA đã tạo và ký chứng chỉ này.
    - Period of validity: Bao gồm hai ngày: ngày đầu tiên và ngày cuối cùng mà chứng chỉ có hiệu lực.
    - Subject name: Tên của người dùng mà chứng chỉ này đề cập đến. Nghĩa là, chứng chỉ này xác nhận khóa công khai của chủ thể nắm giữ khóa riêng tương ứng.
    - Subject’s public-key information: Khóa công khai của chủ thể, thuật toán mà khóa này sẽ được sử dụng, cùng các tham số liên quan.
    - Issuer unique identifier: Chuỗi bit tùy chọn được sử dụng để xác định duy nhất CA phát hành trong trường hợp tên X.500 đã được sử dụng lại cho các thực thể khác nhau.
    - Subject unique identifier: Chuỗi bit tùy chọn được sử dụng để xác định duy nhất chủ thể trong trường hợp tên X.500 đã được sử dụng lại cho các thực thể khác nhau.
    - Extensions: Tập hợp một hoặc nhiều trường phần mở rộng (version 3).
    - Signature: Bao gồm tất cả các trường khác của chứng chỉ. Một thành phần của trường này là chữ ký số của các trường khác của chứng chỉ. Trường này bao gồm từ định danh thuật toán chữ ký.

    CA ký chứng chỉ bằng khóa riêng của nó. Nếu khóa công khai tương ứng được người dùng biết, thì người dùng đó có thể xác minh rằng chứng chỉ do CA ký là hợp lệ.

- **Hash function**

    Hàm băm (hash function) là giải thuật nhằm sinh ra các giá trị băm tương ứng với mỗi khối dữ liệu (có thể là một chuỗi ký tự, một đối tượng trong lập trình hướng đối tượng, v.v...). Giá trị băm đóng vai gần như một khóa để phân biệt các khối dữ liệu, tuy nhiên, người ta chấp nhận hiện tượng trùng khóa hay còn gọi là đụng độ và cố gắng cải thiện giải thuật để giảm thiểu sự đụng độ đó. Sau khi băm thì sẽ ra được một khối dữ liệu có kích thước cố định nên sẽ dễ dàng cho việc tính toán và đồng thời đây là các hàm một chiều nên sẽ rất dễ tính ra giá trị băm nhưng khi tính ngược lại thì lại rất khó.
    Cụ thể trong bài dùng đến 2 hàm hash đó là SHA512 và SHAKE256
    - SHA512 :
        - Output size : 512bits
        - Block size : 1024bits 
        - Rounds : 80
        - Operations : and, xor, or, rot, shr, add (mod 264).
    - SHAKE256:
        - Output size : bất kỳ
        - Block size : 1088 bits 
        - Rounds : 24
        - Operations : and, or, rot, not.
## Tổng quan công nghệ sử dụng 

- Ngôn ngữ lập trình: C#
- Các thư viện hỗ trợ mã hoá và digital signature: 
    - Waher.Security.EllipticCurves (C#)(Ed448,ECDSA)
    - System.Security.Cryptography.Aes(C#)
    - System.Security.Cryptography.X509Certificates(C#)
    - System.Security.Cryptography(C#)(Hash function).
- Database: MySQL

## Tổng quan hệ thống 

- **Kiến trúc hệ thống**

![](https://i.imgur.com/lLJbtT3.png)

- Bên tạo dữ liệu: Người tạo dữ liệu là bác sĩ. Mỗi bác sĩ sẽ có một tài khoản riêng trong bệnh viện. Mỗi lần tạo hồ sơ cho một bệnh nhân, tài khoản của bác sĩ sẽ được cấp một key pair public/private duy nhất không lặp lại để tạo chữ ký.
- Cloud Server: Là nơi lưu trữ thông tin tài khoản của bác sĩ, bệnh nhân cũng như hồ sơ y tế. Cloud server còn lưu trữ key AES và IV để quản lý quyền truy cập hồ sơ của các tài khoản. Do một nhà cung cấp dịch vụ lưu trữ Cloud cung cấp (hiện thực project thì dùng MYSQL local)
- Trusted third-party: Cung cấp một Digital Certificate cho public key hiện tại của tài khoản bác sĩ.
- Bên truy xuất dữ liệu: Người truy xuất dữ liệu là bác sĩ và bệnh nhân.

**Một vấn đề của chữ ký số gặp phải đó là việc phân phối public key. Làm sao khi truy xuất dữ liệu, chúng ta có thể chắc chắn rằng đó là public key của người ký mà không bị thay đổi? Nếu không thể chắc chắng biết được public key là của ai thì ý nghĩa của signature sẽ không còn**
--> Chính vì vậy, project sử dụng Digital signature để lưu trữ public key. Trên tiền đề tin tưởng bên thứ ba cung cấp Certificate, chúng ta có thể biết được public key là của ai.
**Một vấn đề nữa đó là key AES và IV dùng để mã hoá hồ sơ được lưu ở Cloud Server. Tuy nhiên, làm sao để bảo mật 2 loại dữ liệu này?**
--> Giải pháp đó là sử dụng hỗ trợ phần cứng Trusted PlatForm Module (TPM) đã mã hoá 2 loại dữ liệu này.

- **Thiết kế cơ sở dữ liệu**

![](https://i.imgur.com/IFGNPqz.png)

- **Quy trình tạo hồ sơ:**

    ![](https://i.imgur.com/EHE0DyQ.png)

- **Quy trình xác thực hồ sơ:**

    ![](https://i.imgur.com/wo61v4B.png)

## Tổng quan giao diện hệ thống

- Giao diện đăng ký :

    ![](https://i.imgur.com/PWJu8kD.png)

- Giao diện đăng nhập :

    ![](https://i.imgur.com/7Pppn6s.png)

- Giao diện chính của bác sĩ:

    ![](https://i.imgur.com/gvspabN.png)


- Giao diện tạo hồ sơ thành công :

    ![](https://i.imgur.com/AJSLACj.png)

- Giao diện certificate khi nhấn xem, sửa hoặc xóa :

    ![](https://i.imgur.com/OdcbxWI.png)

- Giao diện bệnh nhân : 
    
    ![](https://i.imgur.com/FGRKgPS.png)

- Giao diện chi tiết hồ sơ bệnh nhân :

    ![](https://i.imgur.com/6WRjXvP.png)

- Giao diện thông tin certificate :

    ![](https://i.imgur.com/YUMuWEw.png)

- Giao diện bên certificate :

    ![](https://i.imgur.com/Wnl6Y6T.png)

## Kết luận 

- Hoàn thành triển khai được hệ thống quản lý các hồ sơ chăm sóc sức khỏe với các mục tiêu:
    - Phân quyền truy cập đến các hồ sơ sức khoẻ khác nhau thông qua đăng ký, đăng nhập tài khoản.
    - Cho phép đưa các hồ sơ sức khoẻ lên cơ sở dữ liệu lưu trữ một cách bảo mật.
    - Bảo đảm về các yêu cầu bảo mật: tính xác thực, bảo mật, toàn vẹn và chống thoái thác.
    - Hỗ trợ sử dụng digital certificate để lưu trữ public key nhằm cung cấp thông tin định danh cho khóa công khai của bác sĩ là người ký chữ ký số.

- Còn thiếu sót:
    - Mô hình chỉ triển khai được ở dạng local và chưa thể triển khai mô hình cloud.
    - Vì triển khai ở dạng local nên việc đồng bộ cơ sở dữ liệu cũng là một điều khó khăn.
