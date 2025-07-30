#include <iostream>

void checkRLHFLoop(bool overfit, int iterationCount) {
    if (overfit && iterationCount > 1000) {
        std::cerr << "[SIGMA] Unsafe RLHF Loop detected." << std::endl;
        std::exit(EXIT_FAILURE); // Trigger shutdown
    }
}
