import { useRecoilState } from "recoil"
import AppRoutes from "./routes/AppRoutes"
import { authStore } from "./store/app.store"
function App() {
  const [stateAuth] = useRecoilState(authStore)

  return (
    <div>
      <AppRoutes isAuthenticated={stateAuth != null}></AppRoutes>
    </div>
  )
}
export default App