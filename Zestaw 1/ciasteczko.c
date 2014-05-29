#include <windows.h> //to jest biblioteka, ktorej potrzebuje

int WINAPI WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow ) /*Pierwsze zajmuje sie tym, ze jak otworze dwa okna tego samego programu to kazdy bedzie mial inny nr; prev no to ofc zapamietuje poprzednia; cmdline zawiera linie z ktorej program zostal otwarty, cmdshow okresla jaki ma byc stan naszego okna*/
{
    MessageBox(NULL, "Dasz pieguska?", "Wiadomosc", MB_YESNO + MB_ICONQUESTION + MB_APPLMODAL);
    return 0;
}
