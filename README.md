# VigenereEncryptor
Test task solution

Реализовать систему шифрования методом Винжера:
Сигнатура метода шифрования:
string Encrypt(string source, string key);

Сигнатура метода расшифрования:
string Decrypt(string encrypted, string key);

Плюсом будет, если кандидат реализует сигнатуры:
Сигнатура метода шифрования:
IEnumerable<string> Encrypt(IEnumerable<string>source, string key);

Сигнатура метода расшифрования:
IEnumerable<string> Decrypt(IEnumerable<string> encrypted, string key);

Требования к решениям:
1) Основное ядро должно быть написано кандидатом.
2) Предоставляемый код должен собираться и работать.
3) Функционал должен быть покрыт минимальным набором тестов.
4) Стиль кодирования должно соответствовать МS и Code Style Guide (STS)
