import React from "react";
import "./edittodo.scss";
import { Button, TextField } from "@mui/material";
import { IToDo } from "../../types/global.types";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
import { baseUrl } from "../../constants/url.constant";

const EditTodo: React.FC = () => {
  const [newTodo, setNewTodo] = React.useState<Partial<IToDo>>({
    todoText: "",
  });

  const redirect = useNavigate();
  const { id } = useParams();

  const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTodo({
      ...newTodo,
      [event.target.name]: event.target.value,
    });
  };

  React.useEffect(() => {
    axios.get<IToDo>(`${baseUrl}/${id}`).then((response) =>
      setNewTodo({
        todoText: response.data.todoText,
      })
    );
  }, []);

  const handleSaveBtnClick = () => {
    if (newTodo.todoText === "") {
      alert("Please enter some text");
      return;
    }
    const data: Partial<IToDo> = {
      todoText: newTodo.todoText,
    };
    axios
      .put(`${baseUrl}/${id}`, data)
      .then((response) =>
        redirect("/todos", { state: { message: "Todo Updated!" } })
      )
      .catch((error) => alert("Unable to update selected Todo. Please try again."));
  };

  const handleBackBtnClick = () => {
    redirect("/todos");
  };

  return (
    <div className="edittodo">
      <h2>Edit Todo</h2>
      <TextField
        autoComplete="off"
        multiline={true}
        rows={5}
        label="What would you like to do?"
        variant="outlined"
        name="todoText"
        sx={{
          width: 250
        }}
        value={newTodo.todoText}
        onChange={changeHandler}
      />
      <div>
        <Button variant="outlined" color="primary" onClick={handleSaveBtnClick}>
          Save
        </Button>
        <Button
          variant="outlined"
          color="secondary"
          onClick={handleBackBtnClick}
        >
          Back
        </Button>
      </div>
    </div>
  );
};

export default EditTodo;
