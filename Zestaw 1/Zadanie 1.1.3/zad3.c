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

    hwnd = CreateWindowEx( WS_EX_CLIENTEDGE, NazwaKlasy, "Zadanie 3", WS_OVERLAPPEDWINDOW,
    CW_USEDEFAULT, CW_USEDEFAULT, 440, 440, NULL, NULL, hInstance, NULL );

    //TWORZENIE UCHWYTOW DO RYSOWANIA
    HDC hdc;
    hdc = GetDC( hwnd );

    ShowWindow( hwnd, nCmdShow ); // Poka¿ okienko...
    UpdateWindow( hwnd );
    //Rysowanie kolka
    HBRUSH GreenPen, Box;
    HPEN RedPen, Smth;
    GreenPen = CreateSolidBrush( 0x00FF00 );
    RedPen = CreatePen( PS_DOT, 1, 0x0000FF );
    Box =( HBRUSH ) SelectObject( hdc, GreenPen );
    Smth =( HPEN ) SelectObject( hdc, RedPen );
    Ellipse( hdc, 10, 10, 100, 100 );
    SelectObject( hdc, Box );
    SelectObject( hdc, Smth );
    DeleteObject( RedPen );
    DeleteObject( GreenPen );
    ReleaseDC( hwnd, hdc );



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
    if(MessageBox(hwnd, "Napewno chcesz mnie zamkn¹æ?", "Okienko :)", MB_ICONQUESTION | MB_YESNO) == IDYES)
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
