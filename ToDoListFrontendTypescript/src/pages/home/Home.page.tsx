import { Button } from "@mui/material";
import "./home.scss";
import { useNavigate } from "react-router-dom";
import notepad from "../../assets/images/notepad.png"

const Home = () => {
  const redirect = useNavigate();
  return (
    <div className="home">
      <h1>Welcome!</h1>
      <Button
        variant="outlined"
        color="primary"
        onClick={() => redirect("/todos")}
      >
        ToDos
      </Button>
      <img src={notepad} alt="notepad" />
    </div>
  );
};

export default Home;
