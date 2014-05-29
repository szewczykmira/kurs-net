//Miroslawa Szewczyk - zad 2
#include <windows.h>
LPSTR NazwaKlasy = "Klasa Okienka";
MSG Komunikat;

LRESULT CALLBACK WndProc( HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam );

int WINAPI WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow )
{

    // WYPE£NIANIE STRUKTURY
    WNDCLASSEX wc;

    wc.cbSize = sizeof( WNDCLASSEX );
    wc.style = 0;
    wc.lpfnWndProc = WndProc;
    wc.cbClsExtra = 0;
    wc.cbWndExtra = 0;
    wc.hInstance = hInstance;
    wc.hIcon = LoadIcon( NULL, IDI_APPLICATION );
    wc.hCursor = LoadCursor( NULL, IDC_ARROW );
    wc.hbrBackground =( HBRUSH )( COLOR_WINDOW + 1 );
    wc.lpszMenuName = NULL;
    wc.lpszClassName = NazwaKlasy;
    wc.hIconSm = LoadIcon( NULL, IDI_APPLICATION );
    //Rejestrowanie klasy okna
     RegisterClassEx(&wc);

    // TWORZENIE OKNA
    HWND hwnd;

    hwnd = CreateWindowEx( WS_EX_CLIENTEDGE, NazwaKlasy, "Zadanie 2", WS_OVERLAPPEDWINDOW,
    CW_USEDEFAULT, CW_USEDEFAULT, 440, 440, NULL, NULL, hInstance, NULL );

    //TWORZENIE UCHWYTOW DO RYSOWANIA
    HDC hdc;
    hdc = GetDC( hwnd );

    ShowWindow( hwnd, nCmdShow ); // Poka¿ okienko...
    UpdateWindow( hwnd );
    //rysujemy linie OX
    POINT stary, old;
    MoveToEx(hdc, 0, 210, &stary);
    LineTo( hdc, 440, 210 );
    //Rysujemy linie OY
    MoveToEx(hdc,220,0, &old);
    LineTo(hdc,220,420);
    HPEN CzerwonePioro, Box;
    CzerwonePioro = CreatePen( PS_SOLID, 1, 0x0000FF );
    Box =( HPEN ) SelectObject( hdc, CzerwonePioro );
    SelectObject( hdc, CzerwonePioro );
    MoveToEx(hdc,0,0,&old);
    LineTo(hdc,220,210);
    LineTo(hdc,440,0);

    // Petla komunikatow
    while( GetMessage( & Komunikat, NULL, 0, 0 ) )
    {
        TranslateMessage( & Komunikat );
        DispatchMessage( & Komunikat );
    }
    return Komunikat.wParam;
}

// OBS£UGA ZDARZEÑ
LRESULT CALLBACK WndProc( HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam )
{
    switch( msg )
    {
    case WM_CLOSE:
    if(MessageBox(hwnd, "Napewno chcesz mnie zamknac?", "Okienko :)", MB_ICONQUESTION | MB_YESNO) == IDYES)
         DestroyWindow(hwnd);
        break;

    case WM_DESTROY:
        PostQuitMessage( 0 );
        break;

        default:
        return DefWindowProc( hwnd, msg, wParam, lParam );
    }

    return 0;
}
