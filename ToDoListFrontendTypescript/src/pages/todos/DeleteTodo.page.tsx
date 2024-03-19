import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import { baseUrl } from "../../constants/url.constant";
import { Button } from "@mui/material";
import "./deletetodo.scss";

const DeleteTodo = () => {
  const redirect = useNavigate();
  const { id } = useParams();

  const handleDeleteBtnClick = () => {
    axios
      .delete(`${baseUrl}/${id}`)
      .then((response) =>
        redirect("/todos", { state: { message: "Todo Deleted!" } })
      )
      .catch((error) =>
        alert("Unable to delete selected Todo. Please try again.")
      );
  };

  const handleBackBtnClick = () => {
    redirect("/todos");
  };

  return (
    <div className="deletetodo">
      <h2>Delete Todo?</h2>
      <h4>Are you sure that you want to delete this Todo?</h4>
      <div>
        <Button
          variant="outlined"
          color="error"
          onClick={handleDeleteBtnClick}
        >
          Yes, please delete it.
        </Button>
        <Button
          variant="outlined"
          color="secondary"
          onClick={handleBackBtnClick}
        >
          No, take me back
        </Button>
      </div>
    </div>
  );
};

export default DeleteTodo;
