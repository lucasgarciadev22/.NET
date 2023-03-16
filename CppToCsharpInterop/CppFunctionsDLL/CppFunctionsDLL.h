// O bloco ifdef a seguir é a forma padrão de criar macros que tornam a exportação
// de uma DLL mais simples. Todos os arquivos nessa DLL são compilados com CPPFUNCTIONSDLL_EXPORTS
// símbolo definido na linha de comando. Esse símbolo não deve ser definido em nenhum projeto
// que usa esta DLL. Desse modo, qualquer projeto cujos arquivos de origem incluem este arquivo veem
// Funções CPPFUNCTIONSDLL_API como importadas de uma DLL, enquanto esta DLL vê símbolos
// definidos com esta macro conforme são exportados.
#ifdef CPPFUNCTIONSDLL_EXPORTS
#define CPPFUNCTIONSDLL_API __declspec(dllexport)
#else
#define CPPFUNCTIONSDLL_API __declspec(dllimport)
#endif

// Esta classe é exportada da DLL
class CPPFUNCTIONSDLL_API CCppFunctionsDLL {
public:
	CCppFunctionsDLL(void);
	// TODO: adicione seus métodos aqui.
	int nCppFunctionsDLL;

	int fnCppFunctionsDLL(void);

	int Add(int firstNum, int secondNum);

	int Sub(int firstNum, int secondNum);
};
